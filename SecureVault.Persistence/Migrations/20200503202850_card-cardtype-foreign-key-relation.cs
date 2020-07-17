using Microsoft.EntityFrameworkCore.Migrations;

namespace SecureVault.Persistence.SqlServer.Migrations
{
    public partial class cardcardtypeforeignkeyrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Cards_CardTypeId",
                table: "Cards",
                column: "CardTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_CardTypes_CardTypeId",
                table: "Cards",
                column: "CardTypeId",
                principalTable: "CardTypes",
                principalColumn: "CardTypeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_CardTypes_CardTypeId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CardTypeId",
                table: "Cards");
        }
    }
}
