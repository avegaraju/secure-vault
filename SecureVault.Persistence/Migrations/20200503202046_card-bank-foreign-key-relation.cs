using Microsoft.EntityFrameworkCore.Migrations;

namespace SecureVault.Persistence.SqlServer.Migrations
{
    public partial class cardbankforeignkeyrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cards_BankId",
                table: "Cards",
                column: "BankId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Banks_BankId",
                table: "Cards",
                column: "BankId",
                principalTable: "Banks",
                principalColumn: "BankId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Banks_BankId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_BankId",
                table: "Cards");
        }
    }
}
