using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChurchManagementApi.Migrations
{
    public partial class _7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChurchUserId",
                table: "Groups",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Groups_ChurchUserId",
                table: "Groups",
                column: "ChurchUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Groups_ChurchUsers_ChurchUserId",
                table: "Groups",
                column: "ChurchUserId",
                principalTable: "ChurchUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Groups_ChurchUsers_ChurchUserId",
                table: "Groups");

            migrationBuilder.DropIndex(
                name: "IX_Groups_ChurchUserId",
                table: "Groups");

            migrationBuilder.DropColumn(
                name: "ChurchUserId",
                table: "Groups");
        }
    }
}
