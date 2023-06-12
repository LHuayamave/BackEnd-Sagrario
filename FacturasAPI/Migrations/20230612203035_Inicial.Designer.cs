﻿// <auto-generated />
using System;
using FacturasAPI;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FacturasAPI.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230612203035_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FacturasAPI.Entidad.FacturaCabecera", b =>
                {
                    b.Property<int>("IdFactura")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdFactura"), 1L, 1);

                    b.Property<string>("DireccionEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaVencimiento")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreCliente")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NombreEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroFactura")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TelefonoEmpresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("IdFactura");

                    b.ToTable("Facturasabecera");
                });

            modelBuilder.Entity("FacturasAPI.Entidad.FacturaDetalle", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("FacturasDetalle");
                });

            modelBuilder.Entity("FacturasAPI.Entidad.FacturaDetalleProducto", b =>
                {
                    b.Property<int>("FacturaDetalleId")
                        .HasColumnType("int");

                    b.Property<int>("ProductoId")
                        .HasColumnType("int");

                    b.HasKey("FacturaDetalleId", "ProductoId");

                    b.HasIndex("ProductoId");

                    b.ToTable("FacturasDetalleProducto");
                });

            modelBuilder.Entity("FacturasAPI.Entidad.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PrecioUnitario")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("FacturasAPI.Entidad.FacturaDetalle", b =>
                {
                    b.HasOne("FacturasAPI.Entidad.FacturaCabecera", "FacturaCabecera")
                        .WithOne("FacturaDetalle")
                        .HasForeignKey("FacturasAPI.Entidad.FacturaDetalle", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacturaCabecera");
                });

            modelBuilder.Entity("FacturasAPI.Entidad.FacturaDetalleProducto", b =>
                {
                    b.HasOne("FacturasAPI.Entidad.FacturaDetalle", "FacturaDetalle")
                        .WithMany("FacturaDetalleProductos")
                        .HasForeignKey("FacturaDetalleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FacturasAPI.Entidad.Producto", "Producto")
                        .WithMany("FacturaDetalleProductos")
                        .HasForeignKey("ProductoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FacturaDetalle");

                    b.Navigation("Producto");
                });

            modelBuilder.Entity("FacturasAPI.Entidad.FacturaCabecera", b =>
                {
                    b.Navigation("FacturaDetalle");
                });

            modelBuilder.Entity("FacturasAPI.Entidad.FacturaDetalle", b =>
                {
                    b.Navigation("FacturaDetalleProductos");
                });

            modelBuilder.Entity("FacturasAPI.Entidad.Producto", b =>
                {
                    b.Navigation("FacturaDetalleProductos");
                });
#pragma warning restore 612, 618
        }
    }
}