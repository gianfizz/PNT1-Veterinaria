using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Veterinaria.Models
{
    public class Cliente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Range(10000000, 99999999)]
        [Display(Name = "DNI")]
        [Required (ErrorMessage = "Ingresar un numero de DNI valido.")]
        public int Dni { get; set; }

        [Required (ErrorMessage = "Nombre es obligatorio.")]
        public string Nombre { get; set; }

        [Required (ErrorMessage = "Apellido es obligatorio.")]
        public string Apellido { get; set; }

        [Display (Name = "Nombre de la Mascota")]
        [Required (ErrorMessage = "Nombre de mascota es obligatorio.")]
        public string NombreMascota { get; set; }

        [Display(Name = "Tipo de Animal")]
        [EnumDataType(typeof(AnimalesQueAtiende))]
        [Required(ErrorMessage = "Tipo de mascota es obligatorio.")]
        public AnimalesQueAtiende TipoAnimal { get; set; }
    }
}
