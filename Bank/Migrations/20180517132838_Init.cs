using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bank.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Banks",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BankLayoutSettings",
                columns: table => new
                {
                    BankId = table.Column<Guid>(nullable: false),
                    LogoKey = table.Column<string>(nullable: true),
                    FooterForeColor = table.Column<string>(nullable: true),
                    HeaderAndFooterBackgroundColor = table.Column<string>(nullable: true),
                    HeaderForeColor = table.Column<string>(nullable: true),
                    TitlesForeColor = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankLayoutSettings", x => x.BankId);
                    table.ForeignKey(
                        name: "FK_BankLayoutSettings_Banks_BankId",
                        column: x => x.BankId,
                        principalTable: "Banks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankLayoutSettings");

            migrationBuilder.DropTable(
                name: "Banks");
        }
    }
}
