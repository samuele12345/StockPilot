using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp1.Migrations
{
    /// <inheritdoc />
    public partial class Eliminazionemodelsinutili : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Categories_CategoryId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_SerialNumber_IdSerial",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_IdSerial",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "IdSerial",
                table: "Item",
                newName: "SerialId");

            migrationBuilder.CreateIndex(
                name: "IX_Item_SerialId",
                table: "Item",
                column: "SerialId",
                unique: true,
                filter: "[SerialId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Categories_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SerialNumber_SerialId",
                table: "Item",
                column: "SerialId",
                principalTable: "SerialNumber",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_Categories_CategoryId",
                table: "Item");

            migrationBuilder.DropForeignKey(
                name: "FK_Item_SerialNumber_SerialId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_SerialId",
                table: "Item");

            migrationBuilder.RenameColumn(
                name: "SerialId",
                table: "Item",
                newName: "IdSerial");

            migrationBuilder.CreateIndex(
                name: "IX_Item_IdSerial",
                table: "Item",
                column: "IdSerial",
                unique: true,
                filter: "[IdSerial] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_Categories_CategoryId",
                table: "Item",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SerialNumber_IdSerial",
                table: "Item",
                column: "IdSerial",
                principalTable: "SerialNumber",
                principalColumn: "Id");
        }
    }
}
