using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titulos.BData.Data.Entity
{
    [Index(nameof(EspecialidadId), nameof(PersonaId), Name = "Matricula_EspecialidadId_PersonaId_UQ", IsUnique = true)]
    public class Matricula
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El Número de la Matricula es Obligatorio")]
        [MaxLength(20, ErrorMessage = "Solo se aceptan hasta 20 caracteres en el Número de la Matricula")]
        public string NumMatricula { get; set; }

        [Required(ErrorMessage = "El Pago de la Matricula es Obligatorio")]
        public Decimal Pago { get; set; }

        [Required(ErrorMessage = "La Especialidad es Obligatorio")]
        public int EspecialidadId { get; set; }
        public Especialidad Especialidad { get; set; }

        [Required(ErrorMessage = "La Persona es Obligatoria")]
        public int PersonaId { get; set; }
        public Persona Persona { get; set; }
    }
}
