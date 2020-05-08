using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.SchemaMigrator.Migrations
{
    public partial class createLogSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MediaId",
                schema: "logs",
                table: "etl",
                newName: "media_id");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                schema: "logs",
                table: "etl",
                newName: "campaign_id");

            migrationBuilder.RenameIndex(
                name: "IX_etl_MediaId",
                schema: "logs",
                table: "etl",
                newName: "IX_etl_media_id");

            migrationBuilder.RenameIndex(
                name: "IX_etl_CampaignId",
                schema: "logs",
                table: "etl",
                newName: "IX_etl_campaign_id");

            migrationBuilder.RenameColumn(
                name: "CampaignId",
                schema: "logs",
                table: "bi",
                newName: "campaign_id");

            migrationBuilder.RenameIndex(
                name: "IX_bi_CampaignId",
                schema: "logs",
                table: "bi",
                newName: "IX_bi_campaign_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "media_id",
                schema: "logs",
                table: "etl",
                newName: "MediaId");

            migrationBuilder.RenameColumn(
                name: "campaign_id",
                schema: "logs",
                table: "etl",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_etl_media_id",
                schema: "logs",
                table: "etl",
                newName: "IX_etl_MediaId");

            migrationBuilder.RenameIndex(
                name: "IX_etl_campaign_id",
                schema: "logs",
                table: "etl",
                newName: "IX_etl_CampaignId");

            migrationBuilder.RenameColumn(
                name: "campaign_id",
                schema: "logs",
                table: "bi",
                newName: "CampaignId");

            migrationBuilder.RenameIndex(
                name: "IX_bi_campaign_id",
                schema: "logs",
                table: "bi",
                newName: "IX_bi_CampaignId");
        }
    }
}
