using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Models
{
    [Table("Camara")]
    public partial class Camara
    {
        [Key]
        public int Id { get; set; }

        [Column("latitud")]
        public double? Latitud { get; set; }

        [Column("longitud")]
        public double? Longitud { get; set; }

        [NotMapped]
        public string Coordenada => $"{Latitud}, {Longitud}";

        [Column("numero_camara")]
        public int? NumeroCamara { get; set; }
        [Column("descripcion", TypeName = "text")]
        public string? Descripcion { get; set; }
        public int? IdEstadoCamara { get; set; }

        [ForeignKey("IdEstadoCamara")]
        [InverseProperty("Camaras")]
        [JsonIgnore]
        public virtual EstadoCamara? IdEstadoCamaraNavigation { get; set; }
    }
}
