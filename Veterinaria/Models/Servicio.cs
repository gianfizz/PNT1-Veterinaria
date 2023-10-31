using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Models
{
    public class Servicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime Fecha { get; set; }
        public string DetalleServicio { get; set; }
    }
}
