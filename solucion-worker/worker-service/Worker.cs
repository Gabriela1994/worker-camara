using DataAccess.Models;
using DataAccess.Servicios;
using Microsoft.EntityFrameworkCore;
using worker_service.Clases;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace worker_service
{
    public class Worker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<Worker> _logger;

        public Worker(IServiceProvider serviceProvider, ILogger<Worker> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                using (var client = new HttpClient())
                {
                    var url = "http://localhost:5090/api/Vehiculo/evaluar-infracciones";

                    var json = File.ReadAllText("eventos-camara.json");
                    var infracciones = JsonConvert.DeserializeObject<List<EventoCamara>>(json);

                    var response = await client.PostAsJsonAsync(url, infracciones);

                    if (response.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Solicitud enviada con �xito.");
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode}");
                    }
                }
                await Task.Delay(10000, stoppingToken);
            }

        }
    }
}