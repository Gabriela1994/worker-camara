using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    [Table("EstadoCamara")]
    public partial class EstadoCamara
    {
        public EstadoCamara()
        {
            Camaras = new HashSet<Camara>();
        }

        [Key]
        public int Id { get; set; }
        [Column("nombre")]
        [StringLength(50)]
        [Unicode(false)]
        public string? Nombre { get; set; }
        [Column("descripcion", TypeName = "text")]
        public string? Descripcion { get; set; }

        [InverseProperty("IdEstadoCamaraNavigation")]
        public virtual ICollection<Camara> Camaras { get; set; }
    }
}
