using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChurchManagementApi.Migrations
{
    public partial class _9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ChurchUserId",
                table: "AutomatedEmails",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_AutomatedEmails_ChurchUserId",
                table: "AutomatedEmails",
                column: "ChurchUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AutomatedEmails_ChurchUsers_ChurchUserId",
                table: "AutomatedEmails",
                column: "ChurchUserId",
                principalTable: "ChurchUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AutomatedEmails_ChurchUsers_ChurchUserId",
                table: "AutomatedEmails");

            migrationBuilder.DropIndex(
                name: "IX_AutomatedEmails_ChurchUserId",
                table: "AutomatedEmails");

            migrationBuilder.DropColumn(
                name: "ChurchUserId",
                table: "AutomatedEmails");
        }
    }
}
