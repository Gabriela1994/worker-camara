namespace worker_service.Clases
{
    public class EventoCamara
    {

        public string Fecha { get; set; }
        public string Hora { get; set; }
        public string Latitud { get; set; }
        public string Longitud { get; set; }
        public string Patente { get; set; }
        public bool Luces { get; set; }
        public int Velocidad { get; set; }
        public string TipoVehiculo { get; set; }
        public bool? PoseeCasco { get; set; }
        public string ColorSemaforo { get; set; }

        public EventoCamara()
        {

        }

        public EventoCamara(string fecha, string hora, string latitud, string longitud, string patente, bool luces, int velocidad, string tipoVehiculo, bool poseeCasco, string colorSemaforo)
        {
            Fecha = fecha;
            Hora = hora;
            Latitud = latitud;
            Longitud = longitud;
            Patente = patente;
            Luces = luces;
            Velocidad = velocidad;
            TipoVehiculo = tipoVehiculo;
            PoseeCasco = poseeCasco;
            ColorSemaforo = colorSemaforo;
            Fecha = fecha;
            Hora = hora;
            Patente = patente;
            Luces = luces;
            Velocidad = velocidad;
            TipoVehiculo = tipoVehiculo;
            PoseeCasco = poseeCasco;
            ColorSemaforo = colorSemaforo;
        }
    }
}
