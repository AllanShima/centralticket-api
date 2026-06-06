using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralTicket.Migrations.BillingDb
{
    /// <inheritdoc />
    public partial class AtualizaEstruturaVendaGuid : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billing_Sales_billing_Users_CustomerId",
                schema: "billing",
                table: "billing_Sales");

            migrationBuilder.DropIndex(
                name: "IX_billing_Sales_CustomerId",
                schema: "billing",
                table: "billing_Sales");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_billing_Sales_CustomerId",
                schema: "billing",
                table: "billing_Sales",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_billing_Sales_billing_Users_CustomerId",
                schema: "billing",
                table: "billing_Sales",
                column: "CustomerId",
                principalSchema: "billing",
                principalTable: "billing_Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
