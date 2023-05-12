using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EasyMenu.Core.Model.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ParentProductId = table.Column<int>(type: "int", nullable: false),
                    ProductName = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentProductId",
                        column: x => x.ParentProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SectionName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Suscriptions",
                columns: table => new
                {
                    SuscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SuscriptionType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Discout = table.Column<double>(type: "double", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscriptions", x => x.SuscriptionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ProductSection",
                columns: table => new
                {
                    ProductsProductId = table.Column<int>(type: "int", nullable: false),
                    SectionsSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductSection", x => new { x.ProductsProductId, x.SectionsSectionId });
                    table.ForeignKey(
                        name: "FK_ProductSection_Products_ProductsProductId",
                        column: x => x.ProductsProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductSection_Sections_SectionsSectionId",
                        column: x => x.SectionsSectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    TenantId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantName = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SubPath = table.Column<string>(type: "VARCHAR(200)", nullable: false, defaultValue: "")
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Address = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telephone = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ActiveSubscriptionId = table.Column<int>(type: "int", nullable: false),
                    CurrentMenuId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    SuscriptionId = table.Column<int>(type: "int", nullable: false),
                    DateOfInsert = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EnteredByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.TenantId);
                    table.ForeignKey(
                        name: "FK_Tenants_Suscriptions_SuscriptionId",
                        column: x => x.SuscriptionId,
                        principalTable: "Suscriptions",
                        principalColumn: "SuscriptionId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false),
                    TenantId1 = table.Column<int>(type: "int", nullable: false),
                    DateOfInsert = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EnteredByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Tenants_TenantId1",
                        column: x => x.TenantId1,
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuUis",
                columns: table => new
                {
                    MenuUiId = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    AssetPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuUis", x => x.MenuUiId);
                    table.ForeignKey(
                        name: "FK_MenuUis_Tenants_MenuUiId",
                        column: x => x.MenuUiId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    UserLogin = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserPass = table.Column<string>(type: "VARCHAR(500)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserSalt = table.Column<string>(type: "VARCHAR(500)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DateOfLastPasswordChange = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    IsDisabledByInactivity = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Locked = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    TemporaryLocked = table.Column<bool>(type: "tinyint(1)", nullable: false, defaultValue: false),
                    StatusId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DateOfInsert = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "current_timestamp()"),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EnteredByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuSection",
                columns: table => new
                {
                    MenusMenuId = table.Column<int>(type: "int", nullable: false),
                    SectionsSectionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuSection", x => new { x.MenusMenuId, x.SectionsSectionId });
                    table.ForeignKey(
                        name: "FK_MenuSection_Menus_MenusMenuId",
                        column: x => x.MenusMenuId,
                        principalTable: "Menus",
                        principalColumn: "MenuId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MenuSection_Sections_SectionsSectionId",
                        column: x => x.SectionsSectionId,
                        principalTable: "Sections",
                        principalColumn: "SectionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TenantId1",
                table: "Menus",
                column: "TenantId1");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSection_SectionsSectionId",
                table: "MenuSection",
                column: "SectionsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentProductId",
                table: "Products",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSection_SectionsSectionId",
                table: "ProductSection",
                column: "SectionsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Tenants_SuscriptionId",
                table: "Tenants",
                column: "SuscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_TenantId",
                table: "Users",
                column: "TenantId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MenuSection");

            migrationBuilder.DropTable(
                name: "MenuUis");

            migrationBuilder.DropTable(
                name: "ProductSection");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Sections");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropTable(
                name: "Suscriptions");
        }
    }
}
