using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Retail.Migrations
{
    public partial class LinkProductsAndUnits : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UnitId",
                table: "Product",
                nullable: false,
                defaultValue: 0);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Product",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Product");
            migrationBuilder.DropColumn(name: "UnitId", table: "Product");
        }
    }
}
