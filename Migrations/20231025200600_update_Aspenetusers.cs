using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanKart.Migrations
{
    public partial class update_Aspenetusers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "AspNetUsers");
        }
    }
}
