using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class newDesign : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "BranchId",
                table: "aspnetusers",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_aspnetusers_BranchId",
                table: "aspnetusers",
                column: "BranchId");

            migrationBuilder.AddForeignKey(
                name: "FK_aspnetusers_branches_BranchId",
                table: "aspnetusers",
                column: "BranchId",
                principalTable: "branches",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_aspnetusers_branches_BranchId",
                table: "aspnetusers");

            migrationBuilder.DropIndex(
                name: "IX_aspnetusers_BranchId",
                table: "aspnetusers");

            migrationBuilder.DropColumn(
                name: "BranchId",
                table: "aspnetusers");
        }
    }
}
