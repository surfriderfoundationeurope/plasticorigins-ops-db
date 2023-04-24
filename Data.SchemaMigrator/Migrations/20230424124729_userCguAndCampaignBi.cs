using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.SchemaMigrator.Migrations
{
    /// <inheritdoc />
    public partial class userCguAndCampaignBi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "cguvalidateddate",
                schema: "campaign",
                table: "user",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "disabled",
                schema: "bi",
                table: "campaign_river",
                type: "boolean",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "cguvalidateddate",
                schema: "campaign",
                table: "user");

            migrationBuilder.DropColumn(
                name: "disabled",
                schema: "bi",
                table: "campaign_river");
        }
    }
}
