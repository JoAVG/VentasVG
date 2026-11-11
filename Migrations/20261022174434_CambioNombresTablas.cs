using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VentasVG.Migrations
{
    /// <inheritdoc />
    public partial class CambioNombresTablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categoria_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_UnidadVenta_UnidadVentaId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadVenta",
                table: "UnidadVenta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria");

            migrationBuilder.RenameTable(
                name: "UnidadVenta",
                newName: "UnidadVentas");

            migrationBuilder.RenameTable(
                name: "Categoria",
                newName: "Categorias");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadVentas",
                table: "UnidadVentas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_UnidadVentas_UnidadVentaId",
                table: "Productos",
                column: "UnidadVentaId",
                principalTable: "UnidadVentas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Productos_Categorias_CategoriaId",
                table: "Productos");

            migrationBuilder.DropForeignKey(
                name: "FK_Productos_UnidadVentas_UnidadVentaId",
                table: "Productos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnidadVentas",
                table: "UnidadVentas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorias",
                table: "Categorias");

            migrationBuilder.RenameTable(
                name: "UnidadVentas",
                newName: "UnidadVenta");

            migrationBuilder.RenameTable(
                name: "Categorias",
                newName: "Categoria");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnidadVenta",
                table: "UnidadVenta",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categoria",
                table: "Categoria",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_Categoria_CategoriaId",
                table: "Productos",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Productos_UnidadVenta_UnidadVentaId",
                table: "Productos",
                column: "UnidadVentaId",
                principalTable: "UnidadVenta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
