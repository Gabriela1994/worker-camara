using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class EstadoCamara
    {
        public EstadoCamara()
        {
            Camaras = new HashSet<Camara>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Descripcion { get; set; }

        public virtual ICollection<Camara> Camaras { get; set; }
    }
}
