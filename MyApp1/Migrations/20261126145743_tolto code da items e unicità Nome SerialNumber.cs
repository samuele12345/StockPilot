using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp1.Migrations
{
    /// <inheritdoc />
    public partial class toltocodedaitemseunicitàNomeSerialNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Item_SerialNumber_SerialId",
                table: "Item");

            migrationBuilder.DropIndex(
                name: "IX_Item_SerialId",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Code",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "SerialId",
                table: "Item");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SerialNumber",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "ItemId",
                table: "SerialNumber",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumber_ItemId",
                table: "SerialNumber",
                column: "ItemId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SerialNumber_Name",
                table: "SerialNumber",
                column: "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SerialNumber_Item_ItemId",
                table: "SerialNumber",
                column: "ItemId",
                principalTable: "Item",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SerialNumber_Item_ItemId",
                table: "SerialNumber");

            migrationBuilder.DropIndex(
                name: "IX_SerialNumber_ItemId",
                table: "SerialNumber");

            migrationBuilder.DropIndex(
                name: "IX_SerialNumber_Name",
                table: "SerialNumber");

            migrationBuilder.DropColumn(
                name: "ItemId",
                table: "SerialNumber");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SerialNumber",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SerialId",
                table: "Item",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Item_SerialId",
                table: "Item",
                column: "SerialId",
                unique: true,
                filter: "[SerialId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Item_SerialNumber_SerialId",
                table: "Item",
                column: "SerialId",
                principalTable: "SerialNumber",
                principalColumn: "Id");
        }
    }
}
