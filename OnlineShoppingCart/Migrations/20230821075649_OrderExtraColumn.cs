using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineShoppingCart.Migrations
{
    /// <inheritdoc />
    public partial class OrderExtraColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_loginHistory_Users_UserId",
                table: "loginHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_loginHistory",
                table: "loginHistory");

            migrationBuilder.RenameTable(
                name: "loginHistory",
                newName: "LoginHistory");

            migrationBuilder.RenameIndex(
                name: "IX_loginHistory_UserId",
                table: "LoginHistory",
                newName: "IX_LoginHistory_UserId");

            migrationBuilder.AddColumn<string>(
                name: "ContactNumber",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_LoginHistory",
                table: "LoginHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LoginHistory_Users_UserId",
                table: "LoginHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoginHistory_Users_UserId",
                table: "LoginHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LoginHistory",
                table: "LoginHistory");

            migrationBuilder.DropColumn(
                name: "ContactNumber",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "LoginHistory",
                newName: "loginHistory");

            migrationBuilder.RenameIndex(
                name: "IX_LoginHistory_UserId",
                table: "loginHistory",
                newName: "IX_loginHistory_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_loginHistory",
                table: "loginHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_loginHistory_Users_UserId",
                table: "loginHistory",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
