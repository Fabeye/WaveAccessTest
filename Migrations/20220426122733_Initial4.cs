using Microsoft.EntityFrameworkCore.Migrations;

namespace Test.Migrations
{
    public partial class Initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ActorMovie");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ActorMovie",
                columns: table => new
                {
                    actorsid = table.Column<int>(type: "int", nullable: false),
                    moviesid = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActorMovie", x => new { x.actorsid, x.moviesid });
                    table.ForeignKey(
                        name: "FK_ActorMovie_Actors_actorsid",
                        column: x => x.actorsid,
                        principalTable: "Actors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActorMovie_Movies_moviesid",
                        column: x => x.moviesid,
                        principalTable: "Movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActorMovie_moviesid",
                table: "ActorMovie",
                column: "moviesid");
        }
    }
}
