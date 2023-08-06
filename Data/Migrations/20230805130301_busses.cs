using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BusApp.Data.Migrations
{
    public partial class busses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "No",
                table: "Bus",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "No",
                table: "Bus");
        }
    }
}
