using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FanKart.Migrations
{
    public partial class update_Aspenetusers_EncryptionKey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "EncryptionKey",
                table: "AspNetUsers",
                type: "uniqueidentifier",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EncryptionKey",
                table: "AspNetUsers");
        }
    }
}
