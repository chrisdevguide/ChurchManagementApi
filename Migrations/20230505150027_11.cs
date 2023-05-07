using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChurchManagementApi.Migrations
{
    public partial class _11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Sent",
                table: "AutomatedEmails",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Subject",
                table: "AutomatedEmails",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sent",
                table: "AutomatedEmails");

            migrationBuilder.DropColumn(
                name: "Subject",
                table: "AutomatedEmails");
        }
    }
}
