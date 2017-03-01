using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrestamoBancarioNew.Migrations
{
    public partial class Modified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Prestamo_ClienteId",
                table: "Prestamo",
                column: "ClienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Prestamo_Cliente_ClienteId",
                table: "Prestamo",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Prestamo_Cliente_ClienteId",
                table: "Prestamo");

            migrationBuilder.DropIndex(
                name: "IX_Prestamo_ClienteId",
                table: "Prestamo");
        }
    }
}
