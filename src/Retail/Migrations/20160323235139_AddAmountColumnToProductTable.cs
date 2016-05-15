using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Retail.Migrations
{
    public partial class AddAmountColumnToProductTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Product");
            migrationBuilder.AddColumn<decimal>(
                name: "Amount",
                table: "Product",
                nullable: false,
                defaultValue: 0m);
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
            migrationBuilder.DropColumn(name: "Amount", table: "Product");
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Product",
                column: "UnitId",
                principalTable: "Unit",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
