using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class Initial9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "actors",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "movies",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actors",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "movies",
                table: "Actors");
        }
    }
}
