using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ForienkeyAppliedBtCustomer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "customers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_customers_BranchId",
                table: "customers",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_customers_branches_BranchId",
                table: "customers",
                column: "BranchId",
                principalTable: "branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customers_branches_BranchId",
                table: "customers");

            migrationBuilder.DropIndex(
                name: "IX_customers_BranchId",
                table: "customers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "customers");
        }
    }
}
