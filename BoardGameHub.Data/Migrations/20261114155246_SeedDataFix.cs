using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BoardGameHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("c0000000-0000-0000-0000-000000000001"), "Strategy" },
                    { new Guid("c0000000-0000-0000-0000-000000000002"), "Party" },
                    { new Guid("c0000000-0000-0000-0000-000000000003"), "Card Games" },
                    { new Guid("c0000000-0000-0000-0000-000000000004"), "Cooperative" }
                });

            migrationBuilder.InsertData(
                table: "Shop",
                columns: new[] { "Id", "ApprovalStatus", "Description", "Name", "Owner" },
                values: new object[,]
                {
                    { new Guid("b0000000-0000-0000-0000-000000000001"), true, "Board game store and play space in the city center.", "Dice & Dragons", "Ivan Petrov" },
                    { new Guid("b0000000-0000-0000-0000-000000000002"), true, "Cozy cafe with a large collection of board games.", "Meeple Corner", "Maria Georgieva" },
                    { new Guid("b0000000-0000-0000-0000-000000000003"), false, "Community club that hosts weekly game nights.", "Tabletop Club", "Georgi Dimitrov" }
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "CategoryId", "MaxParticipants", "MinParticipants", "Name" },
                values: new object[,]
                {
                    { new Guid("a0000000-0000-0000-0000-000000000001"), new Guid("c0000000-0000-0000-0000-000000000001"), 4, 3, "Catan" },
                    { new Guid("a0000000-0000-0000-0000-000000000002"), new Guid("c0000000-0000-0000-0000-000000000001"), 5, 2, "Carcassonne" },
                    { new Guid("a0000000-0000-0000-0000-000000000003"), new Guid("c0000000-0000-0000-0000-000000000002"), 8, 4, "Codenames" },
                    { new Guid("a0000000-0000-0000-0000-000000000004"), new Guid("c0000000-0000-0000-0000-000000000003"), 10, 2, "Uno" },
                    { new Guid("a0000000-0000-0000-0000-000000000005"), new Guid("c0000000-0000-0000-0000-000000000004"), 4, 2, "Pandemic" }
                });

            migrationBuilder.InsertData(
                table: "Tournament",
                columns: new[] { "Id", "Description", "GameId", "MaxParticipants", "ShopId", "StartDateAndTime", "Status", "Title" },
                values: new object[,]
                {
                    { new Guid("d0000000-0000-0000-0000-000000000001"), "Friendly Catan tournament with prizes for the top three players.", new Guid("a0000000-0000-0000-0000-000000000001"), 16, new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2026, 12, 12, 18, 0, 0, 0, DateTimeKind.Unspecified), true, "Catan Winter Cup" },
                    { new Guid("d0000000-0000-0000-0000-000000000002"), "Open Carcassonne tournament for all skill levels.", new Guid("a0000000-0000-0000-0000-000000000002"), 20, new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2026, 12, 19, 17, 0, 0, 0, DateTimeKind.Unspecified), true, "Carcassonne Open" },
                    { new Guid("d0000000-0000-0000-0000-000000000003"), "Team-based Codenames evening, come with friends or find a team.", new Guid("a0000000-0000-0000-0000-000000000003"), 24, new Guid("b0000000-0000-0000-0000-000000000002"), new DateTime(2027, 1, 9, 19, 0, 0, 0, DateTimeKind.Unspecified), true, "Codenames Night" },
                    { new Guid("d0000000-0000-0000-0000-000000000004"), "Cooperative challenge, teams compete for the fastest cure.", new Guid("a0000000-0000-0000-0000-000000000005"), 12, new Guid("b0000000-0000-0000-0000-000000000001"), new DateTime(2027, 1, 23, 16, 0, 0, 0, DateTimeKind.Unspecified), false, "Pandemic Co-op Challenge" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Tournament",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Tournament",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Tournament",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Tournament",
                keyColumn: "Id",
                keyValue: new Guid("d0000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000003"));

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: new Guid("a0000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000001"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000002"));

            migrationBuilder.DeleteData(
                table: "Category",
                keyColumn: "Id",
                keyValue: new Guid("c0000000-0000-0000-0000-000000000004"));
        }
    }
}
