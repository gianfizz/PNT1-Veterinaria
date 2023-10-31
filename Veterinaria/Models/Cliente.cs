using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Dni { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreMascota { get; set; }
        [EnumDataType(typeof(AnimalesQueAtiende))]
        public AnimalesQueAtiende TipoAnimal { get; set; }
    }
}
