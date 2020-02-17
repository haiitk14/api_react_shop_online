using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResturantAPI.Migrations
{
    public partial class CategorysTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categorys",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Code = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Order = table.Column<int>(nullable: false),
                    IsPublic = table.Column<bool>(nullable: false),
                    TitleSeo = table.Column<string>(nullable: true),
                    KeywordsSeo = table.Column<string>(nullable: true),
                    DescriptionSeo = table.Column<string>(nullable: true),
                    IsMenu = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorys", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categorys");
        }
    }
}
