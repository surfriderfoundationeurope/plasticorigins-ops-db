using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.SchemaMigrator.Migrations
{
    public partial class createLogSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "logs",
                schema: "bi");

            migrationBuilder.EnsureSchema(
                name: "logs");

            migrationBuilder.CreateTable(
                name: "bi",
                schema: "logs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    campaign_id = table.Column<Guid>(nullable: false),
                    initiated_on = table.Column<DateTime>(type: "date", nullable: false),
                    finished_on = table.Column<DateTime>(type: "date", nullable: false),
                    elapsed_time = table.Column<double>(nullable: true),
                    status = table.Column<string>(nullable: false, defaultValue: "HARD_FAIL"),
                    reason = table.Column<string>(nullable: true),
                    script_version = table.Column<string>(nullable: true),
                    failed_step = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bi", x => x.id);
                    table.ForeignKey(
                        name: "bi_log_id_ref_campaign_campaign_fkey",
                        column: x => x.campaign_id,
                        principalSchema: "campaign",
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "etl",
                schema: "logs",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false),
                    campaign_id = table.Column<Guid>(nullable: false),
                    media_id = table.Column<Guid>(nullable: false),
                    media_name = table.Column<string>(nullable: false),
                    initiated_on = table.Column<DateTime>(type: "date", nullable: false),
                    finished_on = table.Column<DateTime>(type: "date", nullable: false),
                    elapsed_time = table.Column<double>(nullable: true),
                    status = table.Column<string>(nullable: false, defaultValue: "HARD_FAIL"),
                    reason = table.Column<string>(nullable: true),
                    script_version = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_etl", x => x.id);
                    table.ForeignKey(
                        name: "etl_log_id_ref_campaign_campaign_fkey",
                        column: x => x.campaign_id,
                        principalSchema: "campaign",
                        principalTable: "campaign",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "etl_log_id_ref_media_fkey",
                        column: x => x.media_id,
                        principalSchema: "campaign",
                        principalTable: "media",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bi_campaign_id",
                schema: "logs",
                table: "bi",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_etl_campaign_id",
                schema: "logs",
                table: "etl",
                column: "campaign_id");

            migrationBuilder.CreateIndex(
                name: "IX_etl_media_id",
                schema: "logs",
                table: "etl",
                column: "media_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bi",
                schema: "logs");

            migrationBuilder.DropTable(
                name: "etl",
                schema: "logs");
           
            migrationBuilder.CreateTable(
                name: "logs",
                schema: "bi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    elapsed_time = table.Column<double>(type: "double precision", nullable: true),
                    finished_on = table.Column<DateTime>(type: "date", nullable: false),
                    initiated_on = table.Column<DateTime>(type: "date", nullable: false),
                    status = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_logs", x => x.id);
                });
        }
    }
}
