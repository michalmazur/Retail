using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Retail.Models;

namespace Retail.Migrations
{
    [DbContext(typeof(RetailContext))]
    [Migration("20160324233203_UpdateModelsToMatchOldProject")]
    partial class UpdateModelsToMatchOldProject
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Retail.Models.Price", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "Id");

                    b.Property<bool>("Bogo")
                        .HasAnnotation("Relational:ColumnName", "Bogo");

                    b.Property<decimal>("Cost")
                        .HasAnnotation("Relational:ColumnName", "PurchasePrice");

                    b.Property<DateTime>("CreatedDate")
                        .HasAnnotation("Relational:ColumnName", "CreatedDate");

                    b.Property<int>("ProductId")
                        .HasAnnotation("Relational:ColumnName", "Product_id");

                    b.Property<bool>("Sale")
                        .HasAnnotation("Relational:ColumnName", "Sale");

                    b.Property<int>("StoreId")
                        .HasAnnotation("Relational:ColumnName", "Store_Id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "UpdatedDate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Prices");
                });

            modelBuilder.Entity("Retail.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "Id");

                    b.Property<decimal>("Amount")
                        .HasAnnotation("Relational:ColumnName", "Amount");

                    b.Property<string>("Barcode")
                        .HasAnnotation("Relational:ColumnName", "Barcode");

                    b.Property<string>("Comments")
                        .HasAnnotation("Relational:ColumnName", "Comments");

                    b.Property<DateTime>("CreatedDate")
                        .HasAnnotation("Relational:ColumnName", "CreatedDate");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "Label");

                    b.Property<int>("UnitId")
                        .HasAnnotation("Relational:ColumnName", "Unit_Id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "UpdatedDate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Products");
                });

            modelBuilder.Entity("Retail.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasAnnotation("Relational:ColumnName", "CreatedDate");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "Label");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "UpdatedDate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Stores");
                });

            modelBuilder.Entity("Retail.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasAnnotation("Relational:ColumnName", "CreatedDate");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "Label");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "UpdatedDate");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Units");
                });

            modelBuilder.Entity("Retail.Models.Price", b =>
                {
                    b.HasOne("Retail.Models.Product")
                        .WithMany()
                        .HasForeignKey("ProductId");

                    b.HasOne("Retail.Models.Store")
                        .WithMany()
                        .HasForeignKey("StoreId");
                });

            modelBuilder.Entity("Retail.Models.Product", b =>
                {
                    b.HasOne("Retail.Models.Unit")
                        .WithMany()
                        .HasForeignKey("UnitId");
                });
        }
    }
}
