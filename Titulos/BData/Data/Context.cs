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
        public DbSet<Profesion> Profesiones => Set<Profesion>();

        public DbSet<Persona> Personas => Set<Persona>();

        public DbSet<Especialidad> Especialidades => Set<Especialidad>();

        public DbSet<Matricula> Matriculas => Set<Matricula>();

        public Context(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Matricula>(o =>
            {
                o.Property(b => b.Pago).HasColumnType("Decimal(10,8)");
            });

            var cascadeFKs = modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetForeignKeys())
                .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade);

            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restrict;
            }

            base.OnModelCreating(modelBuilder);
        }


    }
}
