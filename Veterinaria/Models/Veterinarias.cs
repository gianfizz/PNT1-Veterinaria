using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models
{
    public class Veterinarias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Servicio> Servicios { get; set; }
        public Doctor Doctor { get; set; }
    }
}
