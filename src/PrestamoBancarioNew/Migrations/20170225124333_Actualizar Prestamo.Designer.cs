using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using PrestamoBancarioNew.Data;

namespace PrestamoBancarioNew.Migrations
{
    [DbContext(typeof(PrestamoBancarioDbContext))]
    [Migration("20170225124333_Actualizar Prestamo")]
    partial class ActualizarPrestamo
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrestamoBancarioNew.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Apellido");

                    b.Property<string>("Cedula");

                    b.Property<string>("Nombre");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("PrestamoBancarioNew.Models.InfoPrestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("AmortizacionAcumulada");

                    b.Property<double>("AmortizacionPrincipal");

                    b.Property<double>("Capital");

                    b.Property<double>("Cuota");

                    b.Property<double>("Intereses");

                    b.Property<int>("Mes");

                    b.Property<int>("PrestamoId");

                    b.HasKey("Id");

                    b.HasIndex("PrestamoId");

                    b.ToTable("InfoPrestamo");
                });

            modelBuilder.Entity("PrestamoBancarioNew.Models.Prestamo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Capital");

                    b.Property<int>("ClienteId");

                    b.Property<int>("Plazo");

                    b.Property<double>("Tasa");

                    b.HasKey("Id");

                    b.HasIndex("ClienteId");

                    b.ToTable("Prestamo");
                });

            modelBuilder.Entity("PrestamoBancarioNew.Models.InfoPrestamo", b =>
                {
                    b.HasOne("PrestamoBancarioNew.Models.Prestamo", "Prestamo")
                        .WithMany("InfoPrestamos")
                        .HasForeignKey("PrestamoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PrestamoBancarioNew.Models.Prestamo", b =>
                {
                    b.HasOne("PrestamoBancarioNew.Models.Cliente", "Cliente")
                        .WithMany("Prestamos")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
