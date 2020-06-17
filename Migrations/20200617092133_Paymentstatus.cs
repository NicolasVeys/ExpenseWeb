using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseWeb.Migrations
{
    public partial class Paymentstatus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentStatusId",
                table: "Expenses",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateTable(
                name: "paymentStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_paymentStatuses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Expenses_PaymentStatusId",
                table: "Expenses",
                column: "PaymentStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Expenses_paymentStatuses_PaymentStatusId",
                table: "Expenses",
                column: "PaymentStatusId",
                principalTable: "paymentStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Expenses_paymentStatuses_PaymentStatusId",
                table: "Expenses");

            migrationBuilder.DropTable(
                name: "paymentStatuses");

            migrationBuilder.DropIndex(
                name: "IX_Expenses_PaymentStatusId",
                table: "Expenses");

            migrationBuilder.DropColumn(
                name: "PaymentStatusId",
                table: "Expenses");
        }
    }
}
