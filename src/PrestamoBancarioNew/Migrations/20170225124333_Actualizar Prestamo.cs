using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PrestamoBancarioNew.Migrations
{
    public partial class ActualizarPrestamo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InfoPrestamo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmortizacionAcumulada = table.Column<double>(nullable: false),
                    AmortizacionPrincipal = table.Column<double>(nullable: false),
                    Capital = table.Column<double>(nullable: false),
                    Cuota = table.Column<double>(nullable: false),
                    Intereses = table.Column<double>(nullable: false),
                    Mes = table.Column<int>(nullable: false),
                    PrestamoId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InfoPrestamo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InfoPrestamo_Prestamo_PrestamoId",
                        column: x => x.PrestamoId,
                        principalTable: "Prestamo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InfoPrestamo_PrestamoId",
                table: "InfoPrestamo",
                column: "PrestamoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InfoPrestamo");
        }
    }
}
