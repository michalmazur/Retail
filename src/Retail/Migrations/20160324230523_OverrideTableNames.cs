using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Retail.Migrations
{
    public partial class OverrideTableNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "Price");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "Price");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Product");
            migrationBuilder.RenameTable(
                name: "Unit",
                newName: "units");
            migrationBuilder.RenameTable(
                name: "Store",
                newName: "stores");
            migrationBuilder.RenameTable(
                name: "Product",
                newName: "products");
            migrationBuilder.RenameTable(
                name: "Price",
                newName: "prices");
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "prices",
                column: "product_id",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "prices",
                column: "store_id",
                principalTable: "stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "products",
                column: "unit_id",
                principalTable: "units",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "prices");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "prices");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "products");
            migrationBuilder.RenameTable(
                name: "units",
                newName: "Unit");
            migrationBuilder.RenameTable(
                name: "stores",
                newName: "Store");
            migrationBuilder.RenameTable(
                name: "products",
                newName: "Product");
            migrationBuilder.RenameTable(
                name: "prices",
                newName: "Price");
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "Price",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "Price",
                column: "store_id",
                principalTable: "Store",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Product",
                column: "unit_id",
                principalTable: "Unit",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
