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
                name: "FacturaCabecera",
                columns: table => new
                {
                    IdFacturaCabecera = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FechaFacturaCreacion = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "getdate()"),
                    NumeroFactura = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    FechaVencimiento = table.Column<DateTime>(type: "datetime", nullable: false),
                    NombreCliente = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    NombreEmpresa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    DireccionEmpresa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TelefonoEmpresa = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Subtotal = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Iva = table.Column<double>(type: "float", nullable: true),
                    TotalFactura = table.Column<double>(type: "float", nullable: true),
                    EstadoFacturaCabecera = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "A"),
                    Observaciones = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FacturaCabecera", x => x.IdFacturaCabecera);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    IdProducto = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    EstadoProducto = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false, defaultValue: "A"),
                    FechaCreacion = table.Column<DateTime>(type: "datetime", nullable: true, defaultValueSql: "getdate()"),
                    FechaActualizacion = table.Column<DateTime>(type: "datetime", nullable: true),
                    FechaEliminacion = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Producto", x => x.IdProducto);
                });

            migrationBuilder.CreateTable(
                name: "FacturaDetalle",
                columns: table => new
                {
                    IdFacturaDetalle = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdFacturaCabecera = table.Column<int>(type: "int", nullable: false),
                    IdProducto = table.Column<int>(type: "int", nullable: false),
                    Cantidad = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PrecioUnitario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    SubtotalProducto = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__FacturaDetalle", x => x.IdFacturaDetalle);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_FacturaCabecera",
                        column: x => x.IdFacturaCabecera,
                        principalTable: "FacturaCabecera",
                        principalColumn: "IdFacturaCabecera",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FacturaDetalle_Producto",
                        column: x => x.IdProducto,
                        principalTable: "Producto",
                        principalColumn: "IdProducto");
                });

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_IdFacturaCabecera",
                table: "FacturaDetalle",
                column: "IdFacturaCabecera");

            migrationBuilder.CreateIndex(
                name: "IX_FacturaDetalle_IdProducto",
                table: "FacturaDetalle",
                column: "IdProducto");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FacturaDetalle");

            migrationBuilder.DropTable(
                name: "FacturaCabecera");

            migrationBuilder.DropTable(
                name: "Producto");
        }
    }
}
