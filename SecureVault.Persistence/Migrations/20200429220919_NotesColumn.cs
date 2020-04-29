using Microsoft.EntityFrameworkCore.Migrations;

namespace SecureVault.Persistence.Migrations
{
    public partial class NotesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Banks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Banks");
        }
    }
}
