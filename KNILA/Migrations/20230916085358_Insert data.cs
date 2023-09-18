using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KNILA.Migrations
{
    public partial class Insertdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "BookId", "AuthorFirstName", "AuthorLastName", "Price", "Publisher", "Title" },
                values: new object[] { 1, "Kalki", "KrishnaMoorthy", 500m, "ABC Publisher", "Ponniyin Selvan" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "BookId",
                keyValue: 1);
        }
    }
}
