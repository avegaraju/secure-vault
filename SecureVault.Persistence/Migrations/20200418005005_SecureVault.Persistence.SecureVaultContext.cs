using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SecureVault.Persistence.Migrations
{
    public partial class SecureVaultPersistenceSecureVaultContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    BankId = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    AccountNumber = table.Column<string>(nullable: false),
                    LoginId = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.BankId);
                });

            migrationBuilder.CreateTable(
                name: "Cards",
                columns: table => new
                {
                    CardId = table.Column<decimal>(nullable: false),
                    BankId = table.Column<decimal>(nullable: false),
                    TypeId = table.Column<string>(nullable: true),
                    CardNumber = table.Column<string>(nullable: false),
                    Cvv = table.Column<int>(nullable: false),
                    ExpiryMonth = table.Column<int>(nullable: false),
                    ExpiryYear = table.Column<int>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cards", x => x.CardId);
                });

            migrationBuilder.CreateTable(
                name: "CardTypes",
                columns: table => new
                {
                    CardTypeId = table.Column<decimal>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CardTypes", x => x.CardTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<decimal>(nullable: false),
                    UserName = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: true),
                    EmailAddress = table.Column<string>(nullable: false),
                    CreateDate = table.Column<DateTime>(nullable: false),
                    ModifyDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.InsertData(
                table: "CardTypes",
                columns: new[] { "CardTypeId", "Name" },
                values: new object[] { 1m, "MasterCard" });

            migrationBuilder.InsertData(
                table: "CardTypes",
                columns: new[] { "CardTypeId", "Name" },
                values: new object[] { 2m, "Maestro" });

            migrationBuilder.InsertData(
                table: "CardTypes",
                columns: new[] { "CardTypeId", "Name" },
                values: new object[] { 3m, "American Express" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Banks");

            migrationBuilder.DropTable(
                name: "Cards");

            migrationBuilder.DropTable(
                name: "CardTypes");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
