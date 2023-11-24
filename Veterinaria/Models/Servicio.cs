using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Veterinaria.Models
{
    public class Servicio
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("Cliente")]
        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "Debe indicar un cliente.")]
        public int ClienteId { get; set; }
        [Display(Name = "Nombre del Cliente")]
        public Cliente NombreCliente { get; set; }

        [ForeignKey("Doctor")]
        [Display(Name = "Doctor")]
        [Required(ErrorMessage = "Debe indicar un doctor.")]
        public int DoctorId { get; set; }
        [Display(Name = "Nombre del Doctor")]
        public Doctor NombreDoctor { get; set; }

        [Required(ErrorMessage = "Fecha es obligatoria.")]
        public DateTime Fecha { get; set; }

        [Display(Name = "Detalle del Servicio")]
        [Required(ErrorMessage = "Detalle del Servicio es obligatorio.")]
        public string DetalleServicio { get; set; }
    }
}
