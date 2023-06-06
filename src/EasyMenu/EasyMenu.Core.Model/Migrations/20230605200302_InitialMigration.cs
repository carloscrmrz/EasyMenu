using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

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
                name: "Suscriptions",
                columns: table => new
                {
                    SuscriptionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SuscriptionType = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Discout = table.Column<double>(type: "double", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suscriptions", x => x.SuscriptionId);
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
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
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
                        principalColumn: "SuscriptionId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    MenuId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Status = table.Column<int>(type: "int", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    DateOfInsert = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DateOfLastChange = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    EnteredByUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.MenuId);
                    table.ForeignKey(
                        name: "FK_Menus_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "MenuUis",
                columns: table => new
                {
                    MenuUiId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    AssetPath = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuUis", x => x.MenuUiId);
                    table.ForeignKey(
                        name: "FK_MenuUis_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    ParentProductId = table.Column<int>(type: "int", nullable: true),
                    ProductName = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "VARCHAR(200)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Price = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Products_ParentProductId",
                        column: x => x.ParentProductId,
                        principalTable: "Products",
                        principalColumn: "ProductId");
                    table.ForeignKey(
                        name: "FK_Products_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Sections",
                columns: table => new
                {
                    SectionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    SectionName = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ImageUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sections", x => x.SectionId);
                    table.ForeignKey(
                        name: "FK_Sections_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
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
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    ExpirationDate = table.Column<DateTimeOffset>(type: "datetime(6)", nullable: true),
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
                        principalColumn: "TenantId",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "Suscriptions",
                columns: new[] { "SuscriptionId", "Discout", "Price", "Status", "SuscriptionType" },
                values: new object[,]
                {
                    { 1, 0.0, 0m, 1, 0 },
                    { 2, 0.0, 10m, 1, 1 },
                    { 3, 0.0, 100m, 1, 2 },
                    { 4, 0.0, 1000m, 1, 3 }
                });

            migrationBuilder.InsertData(
                table: "Tenants",
                columns: new[] { "TenantId", "ActiveSubscriptionId", "Address", "CurrentMenuId", "DateOfLastChange", "EnteredByUserId", "Status", "SubPath", "SuscriptionId", "Telephone", "TenantName" },
                values: new object[] { 1, 1, "", 1, null, 0, 1, "easymenu", 1, "123", "EasyMenu" });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "DateOfInsert", "DateOfLastChange", "EnteredByUserId", "Status", "TenantId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 6, 5, 14, 3, 2, 544, DateTimeKind.Local).AddTicks(2291), null, 1, 1, 1 },
                    { 2, new DateTime(2023, 6, 5, 14, 3, 2, 545, DateTimeKind.Local).AddTicks(3491), null, 1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "Description", "ParentProductId", "Position", "Price", "ProductName", "Status", "TenantId" },
                values: new object[,]
                {
                    { 1, "La buena", null, 0, 3m, "Cerveza", 1, 1 },
                    { 2, "Ta jugoso", null, 0, 29m, "Tomahawk", 1, 1 },
                    { 3, "Te despierta", null, 0, 1m, "Cafe", 1, 1 },
                    { 4, "Los que hacen glu glu", null, 0, 11m, "Calamares", 1, 1 }
                });

            migrationBuilder.InsertData(
                table: "Sections",
                columns: new[] { "SectionId", "ImageUrl", "SectionName", "Status", "TenantId" },
                values: new object[,]
                {
                    { 1, "", "Entradas", 1, 1 },
                    { 2, "", "Platos Fuertes", 1, 1 },
                    { 3, "", "Bebidas", 1, 1 },
                    { 4, "", "Postres", 1, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TenantId",
                table: "Menus",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuSection_SectionsSectionId",
                table: "MenuSection",
                column: "SectionsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuUis_TenantId",
                table: "MenuUis",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ParentProductId",
                table: "Products",
                column: "ParentProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_TenantId",
                table: "Products",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductSection_SectionsSectionId",
                table: "ProductSection",
                column: "SectionsSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_Sections_TenantId",
                table: "Sections",
                column: "TenantId");

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
