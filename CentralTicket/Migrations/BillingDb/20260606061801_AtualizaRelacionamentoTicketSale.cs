using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CentralTicket.Migrations.BillingDb
{
    /// <inheritdoc />
    public partial class AtualizaRelacionamentoTicketSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billing_Tickets_billing_Events_EventId",
                schema: "billing",
                table: "billing_Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_billing_Tickets_billing_Sales_SaleId",
                schema: "billing",
                table: "billing_Tickets");

            migrationBuilder.DropIndex(
                name: "IX_billing_Tickets_EventId",
                schema: "billing",
                table: "billing_Tickets");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "billing",
                table: "billing_Events");

            migrationBuilder.DropColumn(
                name: "Status",
                schema: "billing",
                table: "billing_Events");

            migrationBuilder.DropColumn(
                name: "TicketAmount",
                schema: "billing",
                table: "billing_Events");

            migrationBuilder.AlterColumn<Guid>(
                name: "SaleId",
                schema: "billing",
                table: "billing_Tickets",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true)
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddForeignKey(
                name: "FK_billing_Tickets_billing_Sales_SaleId",
                schema: "billing",
                table: "billing_Tickets",
                column: "SaleId",
                principalSchema: "billing",
                principalTable: "billing_Sales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_billing_Tickets_billing_Sales_SaleId",
                schema: "billing",
                table: "billing_Tickets");

            migrationBuilder.AlterColumn<Guid>(
                name: "SaleId",
                schema: "billing",
                table: "billing_Tickets",
                type: "char(36)",
                nullable: true,
                collation: "ascii_general_ci",
                oldClrType: typeof(Guid),
                oldType: "char(36)")
                .OldAnnotation("Relational:Collation", "ascii_general_ci");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "billing",
                table: "billing_Events",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Status",
                schema: "billing",
                table: "billing_Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TicketAmount",
                schema: "billing",
                table: "billing_Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_billing_Tickets_EventId",
                schema: "billing",
                table: "billing_Tickets",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_billing_Tickets_billing_Events_EventId",
                schema: "billing",
                table: "billing_Tickets",
                column: "EventId",
                principalSchema: "billing",
                principalTable: "billing_Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_billing_Tickets_billing_Sales_SaleId",
                schema: "billing",
                table: "billing_Tickets",
                column: "SaleId",
                principalSchema: "billing",
                principalTable: "billing_Sales",
                principalColumn: "Id");
        }
    }
}
