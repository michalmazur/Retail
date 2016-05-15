using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Retail.Migrations
{
    public partial class OverrideColumnNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "Price");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "Price");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Product");
            migrationBuilder.DropColumn(name: "CreatedDate", table: "Product");
            migrationBuilder.DropColumn(name: "UpdatedDate", table: "Product");
            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Unit",
                newName: "label");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Unit",
                newName: "id");
            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Store",
                newName: "label");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Store",
                newName: "id");
            migrationBuilder.RenameColumn(
                name: "UnitId",
                table: "Product",
                newName: "unit_id");
            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Product",
                newName: "label");
            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Product",
                newName: "comments");
            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "Product",
                newName: "barcode");
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Product",
                newName: "amount");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Product",
                newName: "id");
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Price",
                newName: "updated_at");
            migrationBuilder.RenameColumn(
                name: "StoreId",
                table: "Price",
                newName: "store_id");
            migrationBuilder.RenameColumn(
                name: "Sale",
                table: "Price",
                newName: "sale");
            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Price",
                newName: "product_id");
            migrationBuilder.RenameColumn(
                name: "Cost",
                table: "Price",
                newName: "price");
            migrationBuilder.RenameColumn(
                name: "Bogo",
                table: "Price",
                newName: "bogo");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Price",
                newName: "id");
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "Price",
                column: "product_id",
                principalTable: "Product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "Price",
                column: "store_id",
                principalTable: "Store",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Product",
                column: "unit_id",
                principalTable: "Unit",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "Price");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "Price");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Product");
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.RenameColumn(
                name: "label",
                table: "Unit",
                newName: "Label");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Unit",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "label",
                table: "Store",
                newName: "Label");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Store",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "unit_id",
                table: "Product",
                newName: "UnitId");
            migrationBuilder.RenameColumn(
                name: "label",
                table: "Product",
                newName: "Label");
            migrationBuilder.RenameColumn(
                name: "comments",
                table: "Product",
                newName: "Comments");
            migrationBuilder.RenameColumn(
                name: "barcode",
                table: "Product",
                newName: "Barcode");
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Product",
                newName: "Amount");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Product",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "Price",
                newName: "UpdatedDate");
            migrationBuilder.RenameColumn(
                name: "store_id",
                table: "Price",
                newName: "StoreId");
            migrationBuilder.RenameColumn(
                name: "sale",
                table: "Price",
                newName: "Sale");
            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "Price",
                newName: "ProductId");
            migrationBuilder.RenameColumn(
                name: "price",
                table: "Price",
                newName: "Cost");
            migrationBuilder.RenameColumn(
                name: "bogo",
                table: "Price",
                newName: "Bogo");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Price",
                newName: "Id");
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "Price",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "Price",
                column: "StoreId",
                principalTable: "Store",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
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
