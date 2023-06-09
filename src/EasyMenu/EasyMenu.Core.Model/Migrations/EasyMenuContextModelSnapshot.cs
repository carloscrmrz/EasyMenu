﻿// <auto-generated />
using System;
using EasyMenu.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyMenu.Core.Model.Migrations
{
    [DbContext(typeof(EasyMenuContext))]
    partial class EasyMenuContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Menu", b =>
                {
                    b.Property<int>("MenuId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfInsert")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOfLastChange")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnteredByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.HasIndex("TenantId");

                    b.ToTable("Menus");

                    b.HasData(
                        new
                        {
                            MenuId = 1,
                            DateOfInsert = new DateTime(2023, 6, 5, 14, 3, 2, 544, DateTimeKind.Local).AddTicks(2291),
                            EnteredByUserId = 1,
                            Status = 1,
                            TenantId = 1
                        },
                        new
                        {
                            MenuId = 2,
                            DateOfInsert = new DateTime(2023, 6, 5, 14, 3, 2, 545, DateTimeKind.Local).AddTicks(3491),
                            EnteredByUserId = 1,
                            Status = 2,
                            TenantId = 1
                        });
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.MenuUi", b =>
                {
                    b.Property<int>("MenuUiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AssetPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("MenuUiId");

                    b.HasIndex("TenantId");

                    b.ToTable("MenuUis");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Product", b =>
                {
                    b.Property<int>("ProductId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.Property<int?>("ParentProductId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ParentProductId");

                    b.HasIndex("TenantId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductId = 1,
                            Description = "La buena",
                            Position = 0,
                            Price = 3m,
                            ProductName = "Cerveza",
                            Status = 1,
                            TenantId = 1
                        },
                        new
                        {
                            ProductId = 2,
                            Description = "Ta jugoso",
                            Position = 0,
                            Price = 29m,
                            ProductName = "Tomahawk",
                            Status = 1,
                            TenantId = 1
                        },
                        new
                        {
                            ProductId = 3,
                            Description = "Te despierta",
                            Position = 0,
                            Price = 1m,
                            ProductName = "Cafe",
                            Status = 1,
                            TenantId = 1
                        },
                        new
                        {
                            ProductId = 4,
                            Description = "Los que hacen glu glu",
                            Position = 0,
                            Price = 11m,
                            ProductName = "Calamares",
                            Status = 1,
                            TenantId = 1
                        });
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Section", b =>
                {
                    b.Property<int>("SectionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SectionName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("SectionId");

                    b.HasIndex("TenantId");

                    b.ToTable("Sections");

                    b.HasData(
                        new
                        {
                            SectionId = 1,
                            ImageUrl = "",
                            SectionName = "Entradas",
                            Status = 1,
                            TenantId = 1
                        },
                        new
                        {
                            SectionId = 2,
                            ImageUrl = "",
                            SectionName = "Platos Fuertes",
                            Status = 1,
                            TenantId = 1
                        },
                        new
                        {
                            SectionId = 3,
                            ImageUrl = "",
                            SectionName = "Bebidas",
                            Status = 1,
                            TenantId = 1
                        },
                        new
                        {
                            SectionId = 4,
                            ImageUrl = "",
                            SectionName = "Postres",
                            Status = 1,
                            TenantId = 1
                        });
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Suscription", b =>
                {
                    b.Property<int>("SuscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<double>("Discout")
                        .HasColumnType("double");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int>("SuscriptionType")
                        .HasColumnType("int");

                    b.HasKey("SuscriptionId");

                    b.ToTable("Suscriptions");

                    b.HasData(
                        new
                        {
                            SuscriptionId = 1,
                            Discout = 0.0,
                            Price = 0m,
                            Status = 1,
                            SuscriptionType = 0
                        },
                        new
                        {
                            SuscriptionId = 2,
                            Discout = 0.0,
                            Price = 10m,
                            Status = 1,
                            SuscriptionType = 1
                        },
                        new
                        {
                            SuscriptionId = 3,
                            Discout = 0.0,
                            Price = 100m,
                            Status = 1,
                            SuscriptionType = 2
                        },
                        new
                        {
                            SuscriptionId = 4,
                            Discout = 0.0,
                            Price = 1000m,
                            Status = 1,
                            SuscriptionType = 3
                        });
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Tenant", b =>
                {
                    b.Property<int>("TenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ActiveSubscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.Property<int>("CurrentMenuId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfInsert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<DateTime?>("DateOfLastChange")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnteredByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<string>("SubPath")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS")
                        .HasDefaultValue("");

                    b.Property<int>("SuscriptionId")
                        .HasColumnType("int");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("TenantId");

                    b.HasIndex("SuscriptionId");

                    b.ToTable("Tenants");

                    b.HasData(
                        new
                        {
                            TenantId = 1,
                            ActiveSubscriptionId = 1,
                            Address = "",
                            CurrentMenuId = 1,
                            DateOfInsert = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            EnteredByUserId = 0,
                            Status = 1,
                            SubPath = "easymenu",
                            SuscriptionId = 1,
                            Telephone = "123",
                            TenantName = "EasyMenu"
                        });
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateOfInsert")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime")
                        .HasDefaultValueSql("current_timestamp()");

                    b.Property<DateTime?>("DateOfLastChange")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("DateOfLastPasswordChange")
                        .HasColumnType("datetime(6)");

                    b.Property<int>("EnteredByUserId")
                        .HasColumnType("int");

                    b.Property<DateTimeOffset?>("ExpirationDate")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("IsDisabledByInactivity")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Locked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.Property<bool>("TemporaryLocked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.Property<string>("UserLogin")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("UserPass")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.Property<string>("UserSalt")
                        .IsRequired()
                        .HasColumnType("VARCHAR(500) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.HasKey("UserId");

                    b.HasIndex("TenantId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MenuSection", b =>
                {
                    b.Property<int>("MenusMenuId")
                        .HasColumnType("int");

                    b.Property<int>("SectionsSectionId")
                        .HasColumnType("int");

                    b.HasKey("MenusMenuId", "SectionsSectionId");

                    b.HasIndex("SectionsSectionId");

                    b.ToTable("MenuSection");
                });

            modelBuilder.Entity("ProductSection", b =>
                {
                    b.Property<int>("ProductsProductId")
                        .HasColumnType("int");

                    b.Property<int>("SectionsSectionId")
                        .HasColumnType("int");

                    b.HasKey("ProductsProductId", "SectionsSectionId");

                    b.HasIndex("SectionsSectionId");

                    b.ToTable("ProductSection");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Menu", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Tenant", "Tenant")
                        .WithMany("Menus")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.MenuUi", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Tenant", "Tenant")
                        .WithMany("MenuUi")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Product", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Product", "ParentProduct")
                        .WithMany("ChildProducts")
                        .HasForeignKey("ParentProductId");

                    b.HasOne("EasyMenu.Core.Model.Domains.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentProduct");

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Section", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Tenant", "Tenant")
                        .WithMany()
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Tenant", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Suscription", "Suscription")
                        .WithMany("Tenants")
                        .HasForeignKey("SuscriptionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Suscription");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.User", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("MenuSection", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Menu", null)
                        .WithMany()
                        .HasForeignKey("MenusMenuId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyMenu.Core.Model.Domains.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionsSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProductSection", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EasyMenu.Core.Model.Domains.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionsSectionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Product", b =>
                {
                    b.Navigation("ChildProducts");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Suscription", b =>
                {
                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Tenant", b =>
                {
                    b.Navigation("MenuUi");

                    b.Navigation("Menus");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
