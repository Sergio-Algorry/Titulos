using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Titulos.BData.Data.Entity
{
    public class Persona
    {
        public int Id { get; set; }
        public string DNI { get; set; } = "";
        public string Nombre { get; set; } = "";
        public string Apellido { get; set; } = "";
    }
}
