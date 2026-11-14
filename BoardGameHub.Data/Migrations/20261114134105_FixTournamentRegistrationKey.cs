using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class FixTournamentRegistrationKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentRegistration",
                table: "TournamentRegistration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentRegistration",
                table: "TournamentRegistration",
                columns: new[] { "UserId", "TournamentId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TournamentRegistration",
                table: "TournamentRegistration");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TournamentRegistration",
                table: "TournamentRegistration",
                column: "UserId");
        }
    }
}
