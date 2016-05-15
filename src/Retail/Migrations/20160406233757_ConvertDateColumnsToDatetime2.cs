using System;
using System.Collections.Generic;
using Microsoft.Data.Entity.Migrations;

namespace Retail.Migrations
{
    public partial class ConvertDateColumnsToDatetime2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "Prices");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "Prices");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Products");
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Units",
                type: "datetime2",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Units",
                type: "datetime2",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Stores",
                type: "datetime2",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stores",
                type: "datetime2",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                type: "datetime2",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Prices",
                type: "datetime2",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Prices",
                type: "datetime2",
                nullable: false);
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(name: "FK_Price_Product_ProductId", table: "Prices");
            migrationBuilder.DropForeignKey(name: "FK_Price_Store_StoreId", table: "Prices");
            migrationBuilder.DropForeignKey(name: "FK_Product_Unit_UnitId", table: "Products");
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Units",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Units",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Stores",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Stores",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Products",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Products",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                table: "Prices",
                nullable: false);
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                table: "Prices",
                nullable: false);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Product_ProductId",
                table: "Prices",
                column: "Product_id",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Price_Store_StoreId",
                table: "Prices",
                column: "Store_Id",
                principalTable: "Stores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
            migrationBuilder.AddForeignKey(
                name: "FK_Product_Unit_UnitId",
                table: "Products",
                column: "Unit_Id",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
