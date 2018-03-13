using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WineFridge.Migrations
{
    public partial class WineFridge0_3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Wineries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Wineries",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Wineries");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Wineries");
        }
    }
}
