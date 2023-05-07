using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChurchManagementApi.Migrations
{
    public partial class _14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Members",
                table: "ChurchEvents");

            migrationBuilder.AddColumn<List<string>>(
                name: "Participants",
                table: "ChurchEvents",
                type: "text[]",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Participants",
                table: "ChurchEvents");

            migrationBuilder.AddColumn<List<Guid>>(
                name: "Members",
                table: "ChurchEvents",
                type: "uuid[]",
                nullable: true);
        }
    }
}
