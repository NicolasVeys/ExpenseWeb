using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpenseWeb.Migrations
{
    public partial class seein : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "paymentStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 1, "Already payed" });

            migrationBuilder.InsertData(
                table: "paymentStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 2, "Not payed" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "paymentStatuses",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "paymentStatuses",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
