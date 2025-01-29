using DataAccess.Servicios;
using worker_service.Clases;
using Newtonsoft.Json;
using System.Text;

namespace worker_service
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;
        private static readonly HttpClient client = new HttpClient();

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Random random = new Random();
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dataService = scope.ServiceProvider.GetRequiredService<DataService>();
                    var camaras = await dataService.ObtenerCamarasAsync(stoppingToken);

                    if (camaras == null || !camaras.Any())
                    {
                        _logger.LogWarning("No se encontraron cámaras en la base de datos.");
                        continue;
                    }

                    List<string> colores = new List<string> { "amarillo", "verde", "rojo" };
                    List<string> tipoVehiculo = new List<string> { "Automovil", "Moto", "Bicicleta" };
                    List<string> patentes = new List<string> { "KBO22P", "JGL45XF", "YJS28WE", "UJG31ED", "CLK65RA", "KSLA456", "JSKL352", "LKPP255", "HSJK778", "ZLAK466" };
                    List<EventoCamara> listaEventos = new List<EventoCamara>();

                    foreach (var camara in camaras)
                    {
                        for (int i = 0; i < patentes.Count; i++)
                        {
                            _logger.LogInformation($"Cámara: {camara.Id}");
                            EventoCamara evento = new EventoCamara
                            {
                                Fecha = "2023-11-23T14:30:00Z",
                                Hora = "08:30",
                                Patente = patentes[random.Next(patentes.Count)],
                                Latitud = camara.Latitud,
                                Longitud = camara.Longitud,
                                PoseeCasco = random.Next(0, 2) == 1,
                                Luces = random.Next(0, 2) == 1,
                                ColorSemaforo = colores[random.Next(colores.Count)],
                                Velocidad = random.Next(10, 200),
                                TipoVehiculo = tipoVehiculo[random.Next(tipoVehiculo.Count)],
                            };
                            listaEventos.Add(evento);
                        }
                    }

                    try
                    {
                        var ConvertirJsonEventos = new StringContent(JsonConvert.SerializeObject(listaEventos), Encoding.UTF8, "application/json");
                        var response = await client.PostAsync("http://localhost:5090/api/Vehiculo/evaluar-infracciones", ConvertirJsonEventos);

                        if (response.IsSuccessStatusCode)
                        {
                            _logger.LogInformation("Solicitud enviada con éxito.");
                        }
                        else
                        {
                            var errorMessage = await response.Content.ReadAsStringAsync();
                            _logger.LogError($"Error en la solicitud: {response.StatusCode} - {errorMessage}");
                        }
                    }
                    catch (Exception ex)
                    {
                        _logger.LogError(ex, "Error al enviar los eventos.");
                    }
                }

                await Task.Delay(10000, stoppingToken);
            }
        }
    }
}
