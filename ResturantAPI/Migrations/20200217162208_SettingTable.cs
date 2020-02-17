using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ResturantAPI.Migrations
{
    public partial class SettingTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Setting",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CommanyName = table.Column<string>(nullable: true),
                    Website = table.Column<string>(nullable: true),
                    Slogan = table.Column<string>(nullable: true),
                    CopyRight = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    HotLine = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    Facebook = table.Column<string>(nullable: true),
                    Twitter = table.Column<string>(nullable: true),
                    Google = table.Column<string>(nullable: true),
                    Youtube = table.Column<string>(nullable: true),
                    TitleSeo = table.Column<string>(nullable: true),
                    KeywordsSeo = table.Column<string>(nullable: true),
                    DescriptionSeo = table.Column<string>(nullable: true),
                    GoogleAnalytic = table.Column<string>(nullable: true),
                    HeadTab = table.Column<string>(nullable: true),
                    BodyTab = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    UpdatedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Setting", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Setting");
        }
    }
}
