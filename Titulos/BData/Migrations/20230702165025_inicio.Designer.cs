﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Titulos.BData.Data;

#nullable disable

namespace Titulos.BData.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20230702165025_inicio")]
    partial class inicio
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Titulos.BData.Data.Entity.Especialidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodEspecialidad")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("DescEspecialidad")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("ProfesionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProfesionId");

                    b.HasIndex(new[] { "CodEspecialidad" }, "Especialidad_CodEspecialidad_UQ")
                        .IsUnique();

                    b.ToTable("Especialidades");
                });

            modelBuilder.Entity("Titulos.BData.Data.Entity.Matricula", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("EspecialidadId")
                        .HasColumnType("int");

                    b.Property<string>("NumMatricula")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal>("Pago")
                        .HasColumnType("Decimal(10,8)");

                    b.Property<int>("PersonaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PersonaId");

                    b.HasIndex(new[] { "EspecialidadId", "PersonaId" }, "Matricula_EspecialidadId_PersonaId_UQ")
                        .IsUnique();

                    b.ToTable("Matriculas");
                });

            modelBuilder.Entity("Titulos.BData.Data.Entity.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Domicilio")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "DNI" }, "Persona_DNI_UQ")
                        .IsUnique();

                    b.ToTable("Personas");
                });

            modelBuilder.Entity("Titulos.BData.Data.Entity.Profesion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("CodProfesion")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CodProfesion" }, "Profesion_CodProfesion_UQ")
                        .IsUnique();

                    b.ToTable("Profesiones");
                });

            modelBuilder.Entity("Titulos.BData.Data.Entity.Especialidad", b =>
                {
                    b.HasOne("Titulos.BData.Data.Entity.Profesion", "Profesion")
                        .WithMany("Especialidades")
                        .HasForeignKey("ProfesionId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Profesion");
                });

            modelBuilder.Entity("Titulos.BData.Data.Entity.Matricula", b =>
                {
                    b.HasOne("Titulos.BData.Data.Entity.Especialidad", "Especialidad")
                        .WithMany("Matriculas")
                        .HasForeignKey("EspecialidadId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Titulos.BData.Data.Entity.Persona", "Persona")
                        .WithMany("Matriculas")
                        .HasForeignKey("PersonaId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Especialidad");

                    b.Navigation("Persona");
                });

            modelBuilder.Entity("Titulos.BData.Data.Entity.Especialidad", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Titulos.BData.Data.Entity.Persona", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("Titulos.BData.Data.Entity.Profesion", b =>
                {
                    b.Navigation("Especialidades");
                });
#pragma warning restore 612, 618
        }
    }
}