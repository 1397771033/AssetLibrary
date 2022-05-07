using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AssetLibrary.Api.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "scene",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creatorId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    creationTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    modifierId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    modificationTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scene", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sceneAsset",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    sceneId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assetType = table.Column<int>(type: "int", nullable: true),
                    parentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    fileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_sceneAsset", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "systemAsset",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assetType = table.Column<int>(type: "int", nullable: true),
                    parentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    fileType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_systemAsset", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenant",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    userName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenantAsset",
                columns: table => new
                {
                    id = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    data = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    assetType = table.Column<int>(type: "int", nullable: true),
                    parentId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: true),
                    fileType = table.Column<int>(type: "int", nullable: false),
                    tenantId = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenantAsset", x => x.id);
                });

            migrationBuilder.InsertData(
                table: "systemAsset",
                columns: new[] { "id", "assetType", "data", "fileType", "name", "parentId" },
                values: new object[,]
                {
                    { "ae8e0107-88ad-4d41-a399-dfbe8d27fe60", 2, null, 2, "建筑", null },
                    { "ae8e0107-88ad-470e-94a8-cb2b7badc560", 2, "住宅数据", 2, "住宅", "ae8e0107-88ad-4d41-a399-dfbe8d27fe60" },
                    { "ae8e0107-88ad-4abc-9e1c-a63d7bea745d", 2, "商业数据", 2, "商业", "ae8e0107-88ad-4d41-a399-dfbe8d27fe60" },
                    { "ae8e0107-88ad-4d09-98ff-8983529c0ecc", 2, null, 2, "交通", null },
                    { "ae8e0107-88ad-43bf-b6b5-b2a03cebc1c4", 2, "信号灯数据", 2, "信号灯", "ae8e0107-88ad-4d09-98ff-8983529c0ecc" },
                    { "ae8e0107-88ad-44c7-976e-350c083266eb", 2, "公交站数据", 2, "公交站", "ae8e0107-88ad-4d09-98ff-8983529c0ecc" },
                    { "ae8e0107-88ad-47a9-8cdf-c50671189dc4", 2, null, 2, "市政", null },
                    { "ae8e0107-88ad-4350-85d7-3c4f6bf68cb1", 2, "井盖数据", 2, "井盖", "ae8e0107-88ad-47a9-8cdf-c50671189dc4" },
                    { "ae8e0107-88ad-490b-b044-7e557d851e5a", 2, "售货机数据", 2, "售货机", "ae8e0107-88ad-47a9-8cdf-c50671189dc4" }
                });

            migrationBuilder.InsertData(
                table: "tenant",
                columns: new[] { "id", "password", "userName" },
                values: new object[,]
                {
                    { "ae8e0107-88ad-442f-a7dd-964104d07e6e", "123456", "admin1" },
                    { "ae8e0107-88ad-44fa-b797-b762ce2a3320", "123456", "admin2" },
                    { "ae8e0107-88ad-4260-ad26-338cadf25f7b", "123456", "admin3" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "scene");

            migrationBuilder.DropTable(
                name: "sceneAsset");

            migrationBuilder.DropTable(
                name: "systemAsset");

            migrationBuilder.DropTable(
                name: "tenant");

            migrationBuilder.DropTable(
                name: "tenantAsset");
        }
    }
}
