using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Retail.Migrations
{
    public partial class CapitalizeTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "prices");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "prices");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "products");
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "prices",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "prices",
                column: "store_id",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Products",
                column: "unit_id",
                principalTable: "Units",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.RenameTable(
                name: "units",
                newName: "Units");
            migrationBuilder.RenameTable(
                name: "stores",
                newName: "Stores");
            migrationBuilder.RenameTable(
                name: "products",
                newName: "Products");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "prices");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "prices");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Products");
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "prices",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "prices",
                column: "store_id",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "products",
                column: "unit_id",
                principalTable: "units",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameTable(
                name: "Units",
                newName: "units");
            migrationBuilder.RenameTable(
                name: "Stores",
                newName: "stores");
            migrationBuilder.RenameTable(
                name: "Products",
                newName: "products");
        }
    }
}
