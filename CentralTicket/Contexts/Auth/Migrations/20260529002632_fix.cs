using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralTicket.Contexts.Auth.Migrations
{
    /// <inheritdoc />
    public partial class fix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Users_UserId",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.EnsureSchema(
                name: "auth");

            migrationBuilder.RenameTable(
                name: "Ticket",
                newName: "Ticket",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sale",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Event",
                newSchema: "auth");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "auth_Users",
                newSchema: "auth");

            migrationBuilder.AddPrimaryKey(
                name: "PK_auth_Users",
                schema: "auth",
                table: "auth_Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_auth_Users_UserId",
                schema: "auth",
                table: "Sale",
                column: "UserId",
                principalSchema: "auth",
                principalTable: "auth_Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_auth_Users_UserId",
                schema: "auth",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_auth_Users",
                schema: "auth",
                table: "auth_Users");

            migrationBuilder.RenameTable(
                name: "Ticket",
                schema: "auth",
                newName: "Ticket");

            migrationBuilder.RenameTable(
                name: "Sale",
                schema: "auth",
                newName: "Sale");

            migrationBuilder.RenameTable(
                name: "Event",
                schema: "auth",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "auth_Users",
                schema: "auth",
                newName: "Users");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Users_UserId",
                table: "Sale",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
