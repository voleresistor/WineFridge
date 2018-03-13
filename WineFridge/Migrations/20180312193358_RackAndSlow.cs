using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WineFridge.Migrations
{
    public partial class RackAndSlow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Wines");

            migrationBuilder.AddColumn<int>(
                name: "Rack",
                table: "Wines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Slot",
                table: "Wines",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rack",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "Slot",
                table: "Wines");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Wines",
                nullable: true);
        }
    }
}
