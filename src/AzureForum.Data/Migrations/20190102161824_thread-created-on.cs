using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AzureForum.Data.Migrations
{
    public partial class threadcreatedon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "PostThreads",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "PostThreads");
        }
    }
}
