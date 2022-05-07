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
                    id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "text", nullable: true),
                    creatorId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    creationTime = table.Column<DateTime>(type: "datetime", nullable: true),
                    modifierId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    modificationTime = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_scene", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sceneAsset",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    sceneId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    data = table.Column<string>(type: "text", nullable: true),
                    assetType = table.Column<int>(type: "int", nullable: true),
                    parentId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
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
                    id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    data = table.Column<string>(type: "text", nullable: true),
                    assetType = table.Column<int>(type: "int", nullable: true),
                    parentId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
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
                    id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    userName = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tenant", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tenantAsset",
                columns: table => new
                {
                    id = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false),
                    name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    data = table.Column<string>(type: "text", nullable: true),
                    assetType = table.Column<int>(type: "int", nullable: true),
                    parentId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: true),
                    fileType = table.Column<int>(type: "int", nullable: false),
                    tenantId = table.Column<string>(type: "varchar(36)", maxLength: 36, nullable: false)
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
                    { "ae8e0168-233e-45dc-bbd1-aeea35276a56", 2, null, 2, "建筑", null },
                    { "ae8e0168-233f-4b58-a640-b80da4e5189a", 2, "住宅数据", 2, "住宅", "ae8e0168-233e-45dc-bbd1-aeea35276a56" },
                    { "ae8e0168-233f-40cd-802c-ed9fc0e35dde", 2, "商业数据", 2, "商业", "ae8e0168-233e-45dc-bbd1-aeea35276a56" },
                    { "ae8e0168-233f-42f0-8dca-1272993a6bbd", 2, null, 2, "交通", null },
                    { "ae8e0168-233f-457e-b166-38c1905d57bd", 2, "信号灯数据", 2, "信号灯", "ae8e0168-233f-42f0-8dca-1272993a6bbd" },
                    { "ae8e0168-233f-42f7-9e02-52df303929d3", 2, "公交站数据", 2, "公交站", "ae8e0168-233f-42f0-8dca-1272993a6bbd" },
                    { "ae8e0168-233f-4ee0-8a43-fa289e38ce90", 2, null, 2, "市政", null },
                    { "ae8e0168-233f-497a-b5ed-6f54d2cf391d", 2, "井盖数据", 2, "井盖", "ae8e0168-233f-4ee0-8a43-fa289e38ce90" },
                    { "ae8e0168-233f-40e2-9db9-9fcac4cd4589", 2, "售货机数据", 2, "售货机", "ae8e0168-233f-4ee0-8a43-fa289e38ce90" }
                });

            migrationBuilder.InsertData(
                table: "tenant",
                columns: new[] { "id", "password", "userName" },
                values: new object[,]
                {
                    { "ae8e0168-233f-41d4-b97d-772b9ba46522", "123456", "admin1" },
                    { "ae8e0168-233f-4b07-a4d4-ce184f48f9dd", "123456", "admin2" },
                    { "ae8e0168-233f-4329-bea0-08761f101f5f", "123456", "admin3" }
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
