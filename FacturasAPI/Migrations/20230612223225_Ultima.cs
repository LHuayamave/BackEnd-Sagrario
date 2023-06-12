using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FacturasAPI.Migrations
{
    public partial class Ultima : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturasDetalle_Facturasabecera_Id",
                table: "FacturasDetalle");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Facturasabecera",
                table: "FacturasCabecera");

            migrationBuilder.RenameTable(
                name: "FacturasCabecera",
                newName: "FacturasCabecera");

            migrationBuilder.AddColumn<int>(
                name: "FacturaDetalleId",
                table: "Productos",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Total",
                table: "FacturasCabecera",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturasCabecera",
                table: "FacturasCabecera",
                column: "IdFactura");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_FacturaDetalleId",
                table: "Productos",
                column: "FacturaDetalleId");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturasDetalle_FacturasCabecera_Id",
                table: "FacturasDetalle",
                column: "Id",
                principalTable: "FacturasCabecera",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_FacturasDetalle_FacturaDetalleId",
                table: "Productos",
                column: "FacturaDetalleId",
                principalTable: "FacturasDetalle",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FacturasDetalle_FacturasCabecera_Id",
                table: "FacturasDetalle");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_FacturasDetalle_FacturaDetalleId",
                table: "Productos");

            migrationBuilder.DropIndex(
                name: "IX_Productos_FacturaDetalleId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FacturasCabecera",
                table: "FacturasCabecera");

            migrationBuilder.DropColumn(
                name: "FacturaDetalleId",
                table: "Productos");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "FacturasCabecera");

            migrationBuilder.RenameTable(
                name: "FacturasCabecera",
                newName: "FacturasCabecera");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FacturasCabecera",
                table: "FacturasCabecera",
                column: "IdFactura");

            migrationBuilder.AddForeignKey(
                name: "FK_FacturasDetalle_Facturasabecera_Id",
                table: "FacturasDetalle",
                column: "Id",
                principalTable: "FacturasCabecera",
                principalColumn: "IdFactura",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
