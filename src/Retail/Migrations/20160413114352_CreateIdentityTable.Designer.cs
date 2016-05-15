using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using Retail.Models;

namespace Retail.Migrations
{
    [DbContext(typeof(RetailContext))]
    [Migration("20160413114352_CreateIdentityTable")]
    partial class CreateIdentityTable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasAnnotation("Relational:Name", "RoleNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasAnnotation("Relational:TableName", "AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasAnnotation("Relational:TableName", "AspNetUserRoles");
                });

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
                        .HasAnnotation("Relational:ColumnName", "CreatedDate")
                        .HasAnnotation("Relational:ColumnType", "datetime2");

                    b.Property<int>("ProductId")
                        .HasAnnotation("Relational:ColumnName", "Product_id");

                    b.Property<bool>("Sale")
                        .HasAnnotation("Relational:ColumnName", "Sale");

                    b.Property<int>("StoreId")
                        .HasAnnotation("Relational:ColumnName", "Store_Id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "UpdatedDate")
                        .HasAnnotation("Relational:ColumnType", "datetime2");

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
                        .HasAnnotation("Relational:ColumnName", "CreatedDate")
                        .HasAnnotation("Relational:ColumnType", "datetime2");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "Label");

                    b.Property<int>("UnitId")
                        .HasAnnotation("Relational:ColumnName", "Unit_Id");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "UpdatedDate")
                        .HasAnnotation("Relational:ColumnType", "datetime2");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Products");
                });

            modelBuilder.Entity("Retail.Models.RetailUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasAnnotation("Relational:Name", "EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .HasAnnotation("Relational:Name", "UserNameIndex");

                    b.HasAnnotation("Relational:TableName", "AspNetUsers");
                });

            modelBuilder.Entity("Retail.Models.Store", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasAnnotation("Relational:ColumnName", "CreatedDate")
                        .HasAnnotation("Relational:ColumnType", "datetime2");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "Label");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "UpdatedDate")
                        .HasAnnotation("Relational:ColumnType", "datetime2");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Stores");
                });

            modelBuilder.Entity("Retail.Models.Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("Relational:ColumnName", "Id");

                    b.Property<DateTime>("CreatedDate")
                        .HasAnnotation("Relational:ColumnName", "CreatedDate")
                        .HasAnnotation("Relational:ColumnType", "datetime2");

                    b.Property<string>("Label")
                        .HasAnnotation("Relational:ColumnName", "Label");

                    b.Property<DateTime>("UpdatedDate")
                        .HasAnnotation("Relational:ColumnName", "UpdatedDate")
                        .HasAnnotation("Relational:ColumnType", "datetime2");

                    b.HasKey("Id");

                    b.HasAnnotation("Relational:TableName", "Units");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Retail.Models.RetailUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Retail.Models.RetailUser")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNet.Identity.EntityFramework.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId");

                    b.HasOne("Retail.Models.RetailUser")
                        .WithMany()
                        .HasForeignKey("UserId");
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
