using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseWeb.Migrations
{
    public partial class FKtest : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_paymentStatuses_PaymentStatusId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_paymentStatuses",
                table: "paymentStatuses");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "paymentStatuses");

            migrationBuilder.AddColumn<int>(
                name: "PaymentStatusId",
                table: "paymentStatuses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_paymentStatuses",
                table: "paymentStatuses",
                column: "PaymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_paymentStatuses_PaymentStatusId",
                table: "Expenses",
                column: "PaymentStatusId",
                principalTable: "paymentStatuses",
                principalColumn: "PaymentStatusId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_paymentStatuses_PaymentStatusId",
                table: "Expenses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_paymentStatuses",
                table: "paymentStatuses");

            migrationBuilder.DropColumn(
                name: "PaymentStatusId",
                table: "paymentStatuses");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "paymentStatuses",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_paymentStatuses",
                table: "paymentStatuses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_paymentStatuses_PaymentStatusId",
                table: "Expenses",
                column: "PaymentStatusId",
                principalTable: "paymentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
