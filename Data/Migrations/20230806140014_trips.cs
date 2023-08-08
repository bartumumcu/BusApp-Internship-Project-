using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusApp.Data.Migrations
{
    public partial class trips : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Trip",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    STime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ETime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DriverId = table.Column<int>(type: "int", nullable: false),
                    BusId = table.Column<int>(type: "int", nullable: false),
                    LineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trip", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trip_Bus_BusId",
                        column: x => x.BusId,
                        principalTable: "Bus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Driver_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Driver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Trip_Line_LineId",
                        column: x => x.LineId,
                        principalTable: "Line",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Trip_BusId",
                table: "Trip",
                column: "BusId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_DriverId",
                table: "Trip",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Trip_LineId",
                table: "Trip",
                column: "LineId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Trip");
        }
    }
}
