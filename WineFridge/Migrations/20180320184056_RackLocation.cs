using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace WineFridge.Migrations
{
    public partial class RackLocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RackLocations",
                columns: table => new
                {
                    WineID = table.Column<int>(nullable: false),
                    RackID = table.Column<int>(nullable: false),
                    LocationRackID = table.Column<int>(nullable: true),
                    LocationWineID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RackLocations", x => new { x.WineID, x.RackID });
                    table.ForeignKey(
                        name: "FK_RackLocations_Wines_WineID",
                        column: x => x.WineID,
                        principalTable: "Wines",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RackLocations_RackLocations_LocationWineID_LocationRackID",
                        columns: x => new { x.LocationWineID, x.LocationRackID },
                        principalTable: "RackLocations",
                        principalColumns: new[] { "WineID", "RackID" },
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_RackLocations_LocationWineID_LocationRackID",
                table: "RackLocations",
                columns: new[] { "LocationWineID", "LocationRackID" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RackLocations");
        }
    }
}
