﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titulos.Shared.DTO
{
    public class EspecialidadDTO
    {
        [Required(ErrorMessage = "El Código de la Especialidad es Obligatorio")]
        [MaxLength(3, ErrorMessage = "Solo se aceptan hasta 3 caracteres en el Código de la Especialidad")]
        public string CodEspecialidad { get; set; }

        [Required(ErrorMessage = "La Descripción de la Especialidad es Obligatorio")]
        [MaxLength(40, ErrorMessage = "Solo se aceptan hasta 40 caracteres en la Descripción de la Especialidad")]
        public string DescEspecialidad { get; set; }

        [Required(ErrorMessage = "La Profesión de la Especialidad es Obligatorio")]
        public int ProfesionId { get; set; }
    }
}
