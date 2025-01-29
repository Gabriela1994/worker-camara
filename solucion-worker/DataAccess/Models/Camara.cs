using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Camara
    {
        public int Id { get; set; }
        public string? Latitud { get; set; }
        public string? Longitud { get; set; }
        public int? NumeroCamara { get; set; }
        public string? Descripcion { get; set; }
        public int? IdEstadoCamara { get; set; }

        public virtual EstadoCamara? IdEstadoCamaraNavigation { get; set; }
    }
}
