using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Titulos.Shared.DTO
{
    public class ProfesionDTO
    {
        [Required(ErrorMessage = "El CODIGO DE LA PROFESION es Obligatorio")]
        [MaxLength(3, ErrorMessage = "Solo se aceptan hasta {1} caracteres en el {0}")]
        public string CodProfesion { get; set; } = "";

        [Required(ErrorMessage = "El CODIGO DE LA PROFESION es Obligatorio")]
        [MaxLength(100, ErrorMessage = "Solo se aceptan hasta 100 caracteres en el CODIGO DE LA PROFESION")]
        public string Titulo { get; set; } = "";
    }
}
