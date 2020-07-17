using Microsoft.EntityFrameworkCore.Migrations;

namespace SecureVault.Persistence.SqlServer.Migrations
{
    public partial class CardNotesColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Cards",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Cards");
        }
    }
}
