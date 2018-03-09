using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WineFridge.Migrations
{
    public partial class InitFKsRemoved : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Wines_WineType_TypeID",
                table: "Wines");

            migrationBuilder.DropForeignKey(
                name: "FK_Wines_Winery_WineryID",
                table: "Wines");

            migrationBuilder.DropTable(
                name: "Winery");

            migrationBuilder.DropTable(
                name: "WineType");

            migrationBuilder.DropIndex(
                name: "IX_Wines_TypeID",
                table: "Wines");

            migrationBuilder.DropIndex(
                name: "IX_Wines_WineryID",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "TypeID",
                table: "Wines");

            migrationBuilder.DropColumn(
                name: "WineryID",
                table: "Wines");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TypeID",
                table: "Wines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "WineryID",
                table: "Wines",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Winery",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Winery", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "WineType",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Description = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WineType", x => x.ID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wines_TypeID",
                table: "Wines",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Wines_WineryID",
                table: "Wines",
                column: "WineryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_WineType_TypeID",
                table: "Wines",
                column: "TypeID",
                principalTable: "WineType",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Wines_Winery_WineryID",
                table: "Wines",
                column: "WineryID",
                principalTable: "Winery",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
