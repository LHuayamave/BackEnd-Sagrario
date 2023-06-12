using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturasAPI.Migrations
{
    public partial class Inicial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Facturasabecera",
                columns: table => new
                {
                    IdFactura = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumeroFactura = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NombreCliente = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NombreEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DireccionEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TelefonoEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facturasabecera", x => x.IdFactura);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FacturasDetalle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<int>(type: "int", nullable: false),
                    PrecioUnitario = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasDetalle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FacturasDetalle_Facturasabecera_Id",
                        column: x => x.Id,
                        principalTable: "Facturasabecera",
                        principalColumn: "IdFactura",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FacturasDetalleProducto",
                columns: table => new
                {
                    FacturaDetalleId = table.Column<int>(type: "int", nullable: false),
                    ProductoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FacturasDetalleProducto", x => new { x.FacturaDetalleId, x.ProductoId });
                    table.ForeignKey(
                        name: "FK_FacturasDetalleProducto_FacturasDetalle_FacturaDetalleId",
                        column: x => x.FacturaDetalleId,
                        principalTable: "FacturasDetalle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturasDetalleProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturasDetalleProducto_ProductoId",
                table: "FacturasDetalleProducto",
                column: "ProductoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturasDetalleProducto");

            migrationBuilder.DropTable(
                name: "FacturasDetalle");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "Facturasabecera");
        }
    }
}
