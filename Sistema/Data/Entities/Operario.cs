using System;
using System.ComponentModel.DataAnnotations;

namespace Sistema.Data.Entities
{
    public class Operario
    {
        public int Id { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]
        [Required]
        public string Nombres { get; set; }

        [MaxLength(50, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]
        [Required]
        public string Apellidos { get; set; }

        [MaxLength(4, ErrorMessage = "El campo {0} solo puede contener {1} caracteres.")]
        [Required]
        public string Iniciales { get; set; }

        [Display(Name = "Fecha de ingreso")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime FechaIngreso { get; set; }

        [Display(Name = "Salario por hora")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = false)]
        public decimal SalarioHora { get; set; }

        [Display(Name = "Esta activo?")]
        public bool Estado { get; set; }
    }
}
