using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Retail.Models;

namespace Retail.Migrations
{
    [DbContext(typeof(RetailContext))]
    [Migration("20160324120303_OverrideColumnNames")]
    partial class OverrideColumnNames
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
                        .HasAnnotation("Relational:ColumnName", "id");

                    b.Property<bool>("Bogo")
                        .HasAnnotation("Relational:ColumnName", "bogo");

                    b.Property<decimal>("Cost")
                        .HasAnnotation("Relational:ColumnName", "price");

                    b.Property<int>("ProductId")
                        .HasAnnotation("Relational:ColumnName", "product_id");

                    b.Property<bool>("Sale")
                        .HasAnnotation("Relational:ColumnName", "sale");

                    b.Property<int>("StoreId")
                        .HasAnnotation("Relational:ColumnName", "store_id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "updated_at");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Retail.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "id");

                    b.Property<decimal>("Amount")
                        .HasAnnotation("Relational:ColumnName", "amount");

                    b.Property<string>("Barcode")
                        .HasAnnotation("Relational:ColumnName", "barcode");

                    b.Property<string>("Comments")
                        .HasAnnotation("Relational:ColumnName", "comments");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "label");

                    b.Property<int>("UnitId")
                        .HasAnnotation("Relational:ColumnName", "unit_id");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Retail.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "id");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "label");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Retail.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "id");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "label");

                    b.HasKey("Id");
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
