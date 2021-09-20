using Microsoft.EntityFrameworkCore.Migrations;

namespace Class06.EntityFramework.DataModels.Migrations
{
    public partial class NotesDomainModelExtended : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PriorityLevel",
                table: "Notes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PriorityLevel",
                table: "Notes");
        }
    }
}
