using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Titulos.BData.Data.Entity;

namespace Titulos.BData.Data
{
    public class Context : DbContext
    {
        //private int myVar;

        //public int MyProperty
        //{
        //    get { return myVar; }
        //    set { myVar = value; }
        //}

        //public DbSet<Persona> Personas { get; set; }

        public DbSet<Persona> Personas => Set<Persona>();

        public Context(DbContextOptions options) : base(options)
        {
        }
    }
}
