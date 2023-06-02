using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    public partial class Seed_Account : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { -2L, "Some random description to Jane", "Jane Doe" });

            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { -1L, "Some random description", "John Doe" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: -2L);

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValue: -1L);
        }
    }
}
