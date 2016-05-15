using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Retail.Migrations
{
    public partial class UpdateModelsToMatchOldProject : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "prices");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "prices");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Products");
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Units",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Units",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Stores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Stores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Prices",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "Prices",
                column: "Product_id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "Prices",
                column: "Store_Id",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Products",
                column: "Unit_Id",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
            migrationBuilder.RenameColumn(
                name: "label",
                table: "Units",
                newName: "Label");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Units",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "label",
                table: "Stores",
                newName: "Label");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Stores",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "unit_id",
                table: "Products",
                newName: "Unit_Id");
            migrationBuilder.RenameColumn(
                name: "label",
                table: "Products",
                newName: "Label");
            migrationBuilder.RenameColumn(
                name: "comments",
                table: "Products",
                newName: "Comments");
            migrationBuilder.RenameColumn(
                name: "barcode",
                table: "Products",
                newName: "Barcode");
            migrationBuilder.RenameColumn(
                name: "amount",
                table: "Products",
                newName: "Amount");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "Products",
                newName: "Id");
            migrationBuilder.RenameColumn(
                name: "updated_at",
                table: "prices",
                newName: "UpdatedDate");
            migrationBuilder.RenameColumn(
                name: "store_id",
                table: "prices",
                newName: "Store_Id");
            migrationBuilder.RenameColumn(
                name: "sale",
                table: "prices",
                newName: "Sale");
            migrationBuilder.RenameColumn(
                name: "product_id",
                table: "prices",
                newName: "Product_id");
            migrationBuilder.RenameColumn(
                name: "price",
                table: "prices",
                newName: "PurchasePrice");
            migrationBuilder.RenameColumn(
                name: "bogo",
                table: "prices",
                newName: "Bogo");
            migrationBuilder.RenameColumn(
                name: "id",
                table: "prices",
                newName: "Id");
            migrationBuilder.RenameTable(
                name: "prices",
                newName: "Prices");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "Prices");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "Prices");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Products");
            migrationBuilder.DropColumn(name: "CreatedDate", table: "Units");
            migrationBuilder.DropColumn(name: "UpdatedDate", table: "Units");
            migrationBuilder.DropColumn(name: "CreatedDate", table: "Stores");
            migrationBuilder.DropColumn(name: "UpdatedDate", table: "Stores");
            migrationBuilder.DropColumn(name: "CreatedDate", table: "Products");
            migrationBuilder.DropColumn(name: "UpdatedDate", table: "Products");
            migrationBuilder.DropColumn(name: "CreatedDate", table: "Prices");
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "prices",
                column: "product_id",
                principalTable: "Products",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "prices",
                column: "store_id",
                principalTable: "Stores",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Products",
                column: "unit_id",
                principalTable: "Units",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Units",
                newName: "label");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Units",
                newName: "id");
            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Stores",
                newName: "label");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Stores",
                newName: "id");
            migrationBuilder.RenameColumn(
                name: "Unit_Id",
                table: "Products",
                newName: "unit_id");
            migrationBuilder.RenameColumn(
                name: "Label",
                table: "Products",
                newName: "label");
            migrationBuilder.RenameColumn(
                name: "Comments",
                table: "Products",
                newName: "comments");
            migrationBuilder.RenameColumn(
                name: "Barcode",
                table: "Products",
                newName: "barcode");
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Products",
                newName: "amount");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Products",
                newName: "id");
            migrationBuilder.RenameColumn(
                name: "UpdatedDate",
                table: "Prices",
                newName: "updated_at");
            migrationBuilder.RenameColumn(
                name: "Store_Id",
                table: "Prices",
                newName: "store_id");
            migrationBuilder.RenameColumn(
                name: "Sale",
                table: "Prices",
                newName: "sale");
            migrationBuilder.RenameColumn(
                name: "Product_id",
                table: "Prices",
                newName: "product_id");
            migrationBuilder.RenameColumn(
                name: "PurchasePrice",
                table: "Prices",
                newName: "price");
            migrationBuilder.RenameColumn(
                name: "Bogo",
                table: "Prices",
                newName: "bogo");
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Prices",
                newName: "id");
            migrationBuilder.RenameTable(
                name: "Prices",
                newName: "prices");
        }
    }
}
