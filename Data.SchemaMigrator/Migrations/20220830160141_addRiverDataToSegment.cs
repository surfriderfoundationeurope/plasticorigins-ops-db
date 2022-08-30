using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.SchemaMigrator.Migrations
{
    public partial class addRiverDataToSegment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "count_trash_river",
                schema: "bi_temp",
                table: "segment",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "distance_monitored_river",
                schema: "bi_temp",
                table: "segment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nb_campaign_river",
                schema: "bi_temp",
                table: "segment",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "trash_per_km_river",
                schema: "bi_temp",
                table: "segment",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "count_trash_river",
                schema: "bi",
                table: "segment",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "distance_monitored_river",
                schema: "bi",
                table: "segment",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "nb_campaign_river",
                schema: "bi",
                table: "segment",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "trash_per_km_river",
                schema: "bi",
                table: "segment",
                type: "numeric",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "count_trash_river",
                schema: "bi_temp",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "distance_monitored_river",
                schema: "bi_temp",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "nb_campaign_river",
                schema: "bi_temp",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "trash_per_km_river",
                schema: "bi_temp",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "count_trash_river",
                schema: "bi",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "distance_monitored_river",
                schema: "bi",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "nb_campaign_river",
                schema: "bi",
                table: "segment");

            migrationBuilder.DropColumn(
                name: "trash_per_km_river",
                schema: "bi",
                table: "segment");
        }
    }
}
