// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Proyecto_P.Data;

namespace Proyecto_P.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("Proyecto_P.Models.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("CantidadCajas")
                        .HasColumnType("integer");

                    b.Property<int>("CantidadProductosPorCajas")
                        .HasColumnType("integer");

                    b.Property<int>("CantidadProductosTotal")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("NombreProducto")
                        .HasColumnType("text");

                    b.Property<decimal>("PrecioPorCajas")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PrecioPorProducto")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PrecioTotal")
                        .HasColumnType("numeric");

                    b.Property<string>("Proveedor")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DataProducto");
                });
#pragma warning restore 612, 618
        }
    }
}
