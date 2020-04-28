using System;
using Microsoft.EntityFrameworkCore.Migrations;
using NetTopologySuite.Geometries;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Data.SchemaMigrator.Migrations.Referential
{
    public partial class initReferentialSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "referential");

            migrationBuilder.AlterDatabase()
                .Annotation("Npgsql:PostgresExtension:pg_buffercache", ",,")
                .Annotation("Npgsql:PostgresExtension:pg_stat_statements", ",,")
                .Annotation("Npgsql:PostgresExtension:pgcrypto", ",,")
                .Annotation("Npgsql:PostgresExtension:pgrouting", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis", ",,")
                .Annotation("Npgsql:PostgresExtension:postgis_topology", ",,")
                .Annotation("Npgsql:PostgresExtension:uuid-ossp", ",,");

            migrationBuilder.CreateTable(
                name: "country",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "limits_land_sea",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_limits_land_sea", x => x.id);
                    table.ForeignKey(
                        name: "limits_land_sea_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "river",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    nature = table.Column<string>(nullable: true),
                    importance = table.Column<int>(nullable: true),
                    origine = table.Column<string>(nullable: true),
                    code_hydro = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    bras = table.Column<string>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_river", x => x.id);
                    table.ForeignKey(
                        name: "river_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "state",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_country_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_state", x => x.id);
                    table.ForeignKey(
                        name: "state_id_ref_country_fk_fkey",
                        column: x => x.id_ref_country_fk,
                        principalSchema: "referential",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "department",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_state_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_department", x => x.id);
                    table.ForeignKey(
                        name: "department_id_ref_state_fk_fkey",
                        column: x => x.id_ref_state_fk,
                        principalSchema: "referential",
                        principalTable: "state",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "municipality",
                schema: "referential",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    the_geom = table.Column<Geometry>(nullable: false),
                    code = table.Column<string>(nullable: true),
                    name = table.Column<string>(nullable: true),
                    id_source = table.Column<string>(nullable: true),
                    id_ref_department_fk = table.Column<int>(nullable: true),
                    createdon = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_municipality", x => x.id);
                    table.ForeignKey(
                        name: "municipality_id_ref_department_fk_fkey",
                        column: x => x.id_ref_department_fk,
                        principalSchema: "referential",
                        principalTable: "department",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "country_code",
                schema: "referential",
                table: "country",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "country_name_key",
                schema: "referential",
                table: "country",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "country_the_geom",
                schema: "referential",
                table: "country",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "referential_department_code",
                schema: "referential",
                table: "department",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_department_id_ref_state_fk",
                schema: "referential",
                table: "department",
                column: "id_ref_state_fk");

            migrationBuilder.CreateIndex(
                name: "department_name_key",
                schema: "referential",
                table: "department",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "referential_department_the_geom",
                schema: "referential",
                table: "department",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_limits_land_sea_id_ref_country_fk",
                schema: "referential",
                table: "limits_land_sea",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "limits_land_sea_the_geom",
                schema: "referential",
                table: "limits_land_sea",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "municipality_code",
                schema: "referential",
                table: "municipality",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_municipality_id_ref_department_fk",
                schema: "referential",
                table: "municipality",
                column: "id_ref_department_fk");

            migrationBuilder.CreateIndex(
                name: "municipality_the_geom",
                schema: "referential",
                table: "municipality",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "IX_river_id_ref_country_fk",
                schema: "referential",
                table: "river",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "river_importance",
                schema: "referential",
                table: "river",
                column: "importance");

            migrationBuilder.CreateIndex(
                name: "river_name",
                schema: "referential",
                table: "river",
                column: "name");

            migrationBuilder.CreateIndex(
                name: "river_the_geom",
                schema: "referential",
                table: "river",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");

            migrationBuilder.CreateIndex(
                name: "state_code",
                schema: "referential",
                table: "state",
                column: "code");

            migrationBuilder.CreateIndex(
                name: "IX_state_id_ref_country_fk",
                schema: "referential",
                table: "state",
                column: "id_ref_country_fk");

            migrationBuilder.CreateIndex(
                name: "state_name_key",
                schema: "referential",
                table: "state",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "state_the_geom",
                schema: "referential",
                table: "state",
                column: "the_geom")
                .Annotation("Npgsql:IndexMethod", "gist");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "limits_land_sea",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "municipality",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "river",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "department",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "state",
                schema: "referential");

            migrationBuilder.DropTable(
                name: "country",
                schema: "referential");
        }
    }
}
