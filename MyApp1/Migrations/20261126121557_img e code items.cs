using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyApp1.Migrations
{
    /// <inheritdoc />
    public partial class imgecodeitems : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Code",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Item",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Code",
                table: "Item");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Item");
        }
    }
}
