using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Retail.Models;

namespace Retail.Migrations
{
    [DbContext(typeof(RetailContext))]
    [Migration("20160323235139_AddAmountColumnToProductTable")]
    partial class AddAmountColumnToProductTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Retail.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<decimal>("Amount");

                    b.Property<string>("Barcode");

                    b.Property<string>("Comments");

                    b.Property<DateTime>("CreatedDate");

                    b.Property<string>("Label");

                    b.Property<int>("UnitId");

                    b.Property<DateTime>("UpdatedDate");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Retail.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");
                });

            modelBuilder.Entity("Retail.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Label");

                    b.HasKey("Id");
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
