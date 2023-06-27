using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Titulos.BData.Data.Entity
{
    [Index(nameof(CodProfesion), Name = "Profesion_CodProfesion_UQ", IsUnique = true)]
    public class Profesion
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El CODIGO DE LA PROFESION es Obligatorio")]
        [MaxLength(3, ErrorMessage = "Solo se aceptan hasta {1} caracteres en el {0}")]
        [Display(Name = "Código")]
        public string CodProfesion { get; set; }

        [Required(ErrorMessage = "El CODIGO DE LA PROFESION es Obligatorio")]
        [MaxLength(100, ErrorMessage = "Solo se aceptan hasta 100 caracteres en el CODIGO DE LA PROFESION")]
        public string Titulo { get; set; }

        public List<Especialidad> Especialidades { get; set; } = new List<Especialidad>();
    }
}
