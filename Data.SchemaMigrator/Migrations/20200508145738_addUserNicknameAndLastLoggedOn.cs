using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.SchemaMigrator.Migrations
{
    public partial class addUserNicknameAndLastLoggedOn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "lastloggedon",
                schema: "campaign",
                table: "user",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "nickname",
                schema: "campaign",
                table: "user",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "lastloggedon",
                schema: "campaign",
                table: "user");

            migrationBuilder.DropColumn(
                name: "nickname",
                schema: "campaign",
                table: "user");
        }
    }
}
