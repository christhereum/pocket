using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PocketApi.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Adelantos",
                columns: table => new
                {
                    Id = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Legajo = table.Column<int>(type: "int", nullable: false),
                    Monto = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Fecha_Cancelacion = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Adelantos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Legajo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tipo_Empleado = table.Column<string>(type: "VARCHAR(1)", maxLength: 1, nullable: false),
                    Dni = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Apellido = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Sueldo = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Legajo);
                });

            migrationBuilder.CreateTable(
                name: "Pagos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id_Adelanto = table.Column<string>(type: "VARCHAR(10)", maxLength: 10, nullable: false),
                    Monto = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tipos_Empleado",
                columns: table => new
                {
                    Id = table.Column<string>(type: "CHAR(1)", maxLength: 1, nullable: false),
                    Descripcion = table.Column<string>(type: "VARCHAR(50)", maxLength: 50, nullable: false),
                    Porcentaje_Adelanto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tipos_Empleado", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Adelantos");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "Pagos");

            migrationBuilder.DropTable(
                name: "Tipos_Empleado");
        }
    }
}
