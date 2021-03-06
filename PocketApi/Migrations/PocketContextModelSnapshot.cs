// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PocketApi.Models;

namespace PocketApi.Migrations
{
    [DbContext(typeof(PocketContext))]
    partial class PocketContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PocketApi.Models.Adelanto", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Fecha_Cancelacion")
                        .HasColumnType("datetime2");

                    b.Property<int>("Legajo")
                        .HasColumnType("int");

                    b.Property<decimal>("Monto")
                        .HasColumnType("DECIMAL(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Adelantos");
                });

            modelBuilder.Entity("PocketApi.Models.Empleado", b =>
                {
                    b.Property<int>("Legajo")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Dni")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Sueldo")
                        .HasColumnType("int");

                    b.Property<string>("Tipo_Empleado")
                        .IsRequired()
                        .HasMaxLength(1)
                        .HasColumnType("VARCHAR(1)");

                    b.HasKey("Legajo");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("PocketApi.Models.Pago", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<string>("Id_Adelanto")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("VARCHAR(10)");

                    b.Property<decimal>("Monto")
                        .HasColumnType("DECIMAL(10,2)");

                    b.HasKey("Id");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("PocketApi.Models.Tipo_Empleado", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(1)
                        .HasColumnType("CHAR(1)");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)");

                    b.Property<int>("Porcentaje_Adelanto")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tipos_Empleado");
                });
#pragma warning restore 612, 618
        }
    }
}
