﻿// <auto-generated />
using System;
using EasyMenu.Core.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace EasyMenu.Core.Model.Migrations
{
    [DbContext(typeof(EasyMenuContext))]
    [Migration("20230512033452_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
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

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<string>("TenantId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TenantId1")
                        .HasColumnType("int");

                    b.HasKey("MenuId");

                    b.HasIndex("TenantId1");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.MenuUi", b =>
                {
                    b.Property<int>("MenuUiId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("AssetPath")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("TenantId")
                        .HasColumnType("int");

                    b.HasKey("MenuUiId");

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

                    b.Property<int>("ParentProductId")
                        .HasColumnType("int");

                    b.Property<int>("Position")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(65,30)");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(200) COLLATE SQL_Latin1_General_CP1_CI_AS");

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.HasKey("ProductId");

                    b.HasIndex("ParentProductId");

                    b.ToTable("Products");
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

                    b.Property<int>("StatusId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("SectionId");

                    b.ToTable("Sections");
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

                    b.Property<int>("StatusId")
                        .HasColumnType("int");

                    b.Property<int>("SuscriptionType")
                        .HasColumnType("int");

                    b.HasKey("SuscriptionId");

                    b.ToTable("Suscriptions");
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

                    b.Property<int>("StatusId")
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
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
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

                    b.Property<bool>("IsDisabledByInactivity")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("Locked")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint(1)")
                        .HasDefaultValue(false);

                    b.Property<int>("StatusId")
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
                        .HasForeignKey("TenantId1")
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.MenuUi", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Tenant", "Tenant")
                        .WithMany("MenuUi")
                        .HasForeignKey("MenuUiId")
                        .IsRequired();

                    b.Navigation("Tenant");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Product", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Product", "ParentProduct")
                        .WithMany("ChildProducts")
                        .HasForeignKey("ParentProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ParentProduct");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.Tenant", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Suscription", "Suscription")
                        .WithMany("Tenants")
                        .HasForeignKey("SuscriptionId")
                        .IsRequired();

                    b.Navigation("Suscription");
                });

            modelBuilder.Entity("EasyMenu.Core.Model.Domains.User", b =>
                {
                    b.HasOne("EasyMenu.Core.Model.Domains.Tenant", "Tenant")
                        .WithMany("Users")
                        .HasForeignKey("TenantId")
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
