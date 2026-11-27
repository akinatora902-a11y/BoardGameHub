using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BoardGameHub.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddShopOwnerId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerId",
                table: "Shop",
                type: "nvarchar(450)",
                nullable: true,
                comment: "Identifier of the Identity user who owns the shop");

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000001"),
                column: "OwnerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000002"),
                column: "OwnerId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shop",
                keyColumn: "Id",
                keyValue: new Guid("b0000000-0000-0000-0000-000000000003"),
                column: "OwnerId",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Shop_OwnerId",
                table: "Shop",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Shop_AspNetUsers_OwnerId",
                table: "Shop",
                column: "OwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Shop_AspNetUsers_OwnerId",
                table: "Shop");

            migrationBuilder.DropIndex(
                name: "IX_Shop_OwnerId",
                table: "Shop");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Shop");
        }
    }
}
