using System;
using System.Collections;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.SchemaMigrator.Migrations
{
    public partial class renameTableImageToMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.RenameTable(
                name: "image",
                schema: "campaign",
                newName:"media",
                newSchema:"campaign"
                );

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
           
        }
    }
}
