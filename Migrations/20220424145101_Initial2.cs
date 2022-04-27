using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class Initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Movies",
                newName: "movieRating");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Movies",
                newName: "movieName");

            migrationBuilder.RenameColumn(
                name: "info",
                table: "Movies",
                newName: "movieInfo");

            migrationBuilder.RenameColumn(
                name: "rating",
                table: "Actors",
                newName: "height");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Actors",
                newName: "actorName");

            migrationBuilder.RenameColumn(
                name: "info",
                table: "Actors",
                newName: "actorInfo");

            migrationBuilder.AddColumn<int>(
                name: "actorRating",
                table: "Actors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "actorRating",
                table: "Actors");

            migrationBuilder.RenameColumn(
                name: "movieRating",
                table: "Movies",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "movieName",
                table: "Movies",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "movieInfo",
                table: "Movies",
                newName: "info");

            migrationBuilder.RenameColumn(
                name: "height",
                table: "Actors",
                newName: "rating");

            migrationBuilder.RenameColumn(
                name: "actorName",
                table: "Actors",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "actorInfo",
                table: "Actors",
                newName: "info");
        }
    }
}
