using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class M002_Logo2LogoUrl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Logo",
                table: "Categories",
                newName: "LogoUrl");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "LogoUrl",
                table: "Categories",
                newName: "Logo");
        }
    }
}
