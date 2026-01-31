using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PickleballClubManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddMatchDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "395_MatchSets");

            migrationBuilder.AddColumn<int>(
                name: "DurationMinutes",
                table: "395_Matches",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "395_Matches",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhotoUrl",
                table: "395_Matches",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ScoreSummary",
                table: "395_Matches",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DurationMinutes",
                table: "395_Matches");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "395_Matches");

            migrationBuilder.DropColumn(
                name: "PhotoUrl",
                table: "395_Matches");

            migrationBuilder.DropColumn(
                name: "ScoreSummary",
                table: "395_Matches");

            migrationBuilder.CreateTable(
                name: "395_MatchSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchId = table.Column<int>(type: "int", nullable: false),
                    SetNumber = table.Column<int>(type: "int", nullable: false),
                    TeamAScore = table.Column<int>(type: "int", nullable: false),
                    TeamBScore = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_395_MatchSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_395_MatchSets_395_Matches_MatchId",
                        column: x => x.MatchId,
                        principalTable: "395_Matches",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_395_MatchSets_MatchId",
                table: "395_MatchSets",
                column: "MatchId");
        }
    }
}
