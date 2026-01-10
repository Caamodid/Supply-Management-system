using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_companies_CompanyId",
                table: "products");

            migrationBuilder.DropIndex(
                name: "IX_products_CompanyId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "products");

            migrationBuilder.AddColumn<Guid>(
                name: "CategoryTypeId",
                table: "products",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "products",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "inventories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "companies",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "categories",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdatedBy",
                table: "branches",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "categorytypes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: false),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    CreatedBy = table.Column<string>(type: "text", nullable: true),
                    UpdatedBy = table.Column<string>(type: "text", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categorytypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_categorytypes_aspnetusers_CreatedBy",
                        column: x => x.CreatedBy,
                        principalTable: "aspnetusers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_categorytypes_categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_products_CategoryTypeId",
                table: "products",
                column: "CategoryTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_categorytypes_CategoryId",
                table: "categorytypes",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_categorytypes_CreatedBy",
                table: "categorytypes",
                column: "CreatedBy");

            migrationBuilder.AddForeignKey(
                name: "FK_products_categorytypes_CategoryTypeId",
                table: "products",
                column: "CategoryTypeId",
                principalTable: "categorytypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_products_categorytypes_CategoryTypeId",
                table: "products");

            migrationBuilder.DropTable(
                name: "categorytypes");

            migrationBuilder.DropIndex(
                name: "IX_products_CategoryTypeId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "CategoryTypeId",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "products");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "inventories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "companies");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "categories");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "branches");

            migrationBuilder.AddColumn<Guid>(
                name: "CompanyId",
                table: "products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_products_CompanyId",
                table: "products",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_products_companies_CompanyId",
                table: "products",
                column: "CompanyId",
                principalTable: "companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
