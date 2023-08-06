using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusApp.Data.Migrations
{
    public partial class lines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LineId",
                table: "Bus",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Line",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    length = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Line", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bus_LineId",
                table: "Bus",
                column: "LineId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bus_Line_LineId",
                table: "Bus",
                column: "LineId",
                principalTable: "Line",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bus_Line_LineId",
                table: "Bus");

            migrationBuilder.DropTable(
                name: "Line");

            migrationBuilder.DropIndex(
                name: "IX_Bus_LineId",
                table: "Bus");

            migrationBuilder.DropColumn(
                name: "LineId",
                table: "Bus");
        }
    }
}
