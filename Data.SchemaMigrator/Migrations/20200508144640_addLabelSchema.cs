using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.SchemaMigrator.Migrations
{
    public partial class addLabelSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "label");

            migrationBuilder.CreateTable(
                name: "images_for_labelling",
                schema: "label",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdCreatorFk = table.Column<Guid>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    filename = table.Column<string>(nullable: true),
                    view = table.Column<string>(nullable: true),
                    image_quality = table.Column<string>(nullable: true),
                    Context = table.Column<string>(nullable: true),
                    container_url = table.Column<string>(nullable: true),
                    blob_name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_images_for_labelling", x => x.id);
                    table.ForeignKey(
                        name: "id_creator_fk",
                        column: x => x.IdCreatorFk,
                        principalSchema: "campaign",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "bounding_boxes",
                schema: "label",
                columns: table => new
                {
                    id = table.Column<Guid>(nullable: false, defaultValueSql: "uuid_generate_v4()"),
                    IdCreatorFk = table.Column<Guid>(nullable: false),
                    createdon = table.Column<DateTime>(nullable: false),
                    IdRefTrashTypeFk = table.Column<int>(nullable: false),
                    IdRefImagesForLabelling = table.Column<Guid>(nullable: false),
                    locationX = table.Column<int>(nullable: false),
                    locationY = table.Column<int>(nullable: false),
                    width = table.Column<int>(nullable: false),
                    height = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bounding_boxes", x => x.id);
                    table.ForeignKey(
                        name: "id_creator_fk",
                        column: x => x.IdCreatorFk,
                        principalSchema: "campaign",
                        principalTable: "user",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "id_ref_images_for_labelling_fk",
                        column: x => x.IdRefImagesForLabelling,
                        principalSchema: "label",
                        principalTable: "images_for_labelling",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "id_ref_trash_type_fk",
                        column: x => x.IdRefTrashTypeFk,
                        principalSchema: "campaign",
                        principalTable: "trash_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_bounding_boxes_IdCreatorFk",
                schema: "label",
                table: "bounding_boxes",
                column: "IdCreatorFk");

            migrationBuilder.CreateIndex(
                name: "IX_bounding_boxes_IdRefImagesForLabelling",
                schema: "label",
                table: "bounding_boxes",
                column: "IdRefImagesForLabelling");

            migrationBuilder.CreateIndex(
                name: "IX_bounding_boxes_IdRefTrashTypeFk",
                schema: "label",
                table: "bounding_boxes",
                column: "IdRefTrashTypeFk");

            migrationBuilder.CreateIndex(
                name: "IX_images_for_labelling_IdCreatorFk",
                schema: "label",
                table: "images_for_labelling",
                column: "IdCreatorFk");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "bounding_boxes",
                schema: "label");

            migrationBuilder.DropTable(
                name: "images_for_labelling",
                schema: "label");
        }
    }
}
