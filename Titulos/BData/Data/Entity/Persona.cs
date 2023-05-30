using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titulos.BData.Data.Entity
{
    [Index(nameof(DNI), Name = "Persona_DNI_UQ", IsUnique=true)]
    public class Persona
    {
        public int Id { get; set; }
        
        [Required(ErrorMessage = "El DNI es Obligatorio")]
        [MaxLength(10, ErrorMessage = "Solo se aceptan hasta 10 caracteres en el DNI")]
        public string DNI { get; set; }
        
        [Required(ErrorMessage = "El NOMBRE es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el NOMBRE")]
        public string Nombre { get; set; }
        
        [Required(ErrorMessage = "El APELLIDO es Obligatorio")]
        [MaxLength(50, ErrorMessage = "Solo se aceptan hasta 50 caracteres en el APELLIDO")]
        public string Apellido { get; set; }
        
        [MaxLength(150, ErrorMessage = "Solo se aceptan hasta 150 caracteres en el DOMICILIO")]
        public string? Domicilio { get; set; }

        public List<Matricula> Matriculas { get; set; } = new List<Matricula>();


    }
}
