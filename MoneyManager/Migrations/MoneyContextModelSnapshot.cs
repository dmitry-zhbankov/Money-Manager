﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Money_Manager.Models;

namespace MoneyManager.Migrations
{
    [DbContext(typeof(MoneyContext))]
    partial class MoneyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0");

            modelBuilder.Entity("Money_Manager.Models.Asset", b =>
                {
                    b.Property<int>("AssetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Balance")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AssetId");

                    b.HasIndex("UserId");

                    b.ToTable("Assets");
                });

            modelBuilder.Entity("Money_Manager.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("ParentCategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Type")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Money_Manager.Models.Transaction", b =>
                {
                    b.Property<int>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Amount")
                        .HasColumnType("TEXT");

                    b.Property<int?>("CategoryId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comment")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TEXT");

                    b.Property<int?>("DestinationAssetId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("SourceAssetId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("UserId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TransactionId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("DestinationAssetId");

                    b.HasIndex("SourceAssetId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("Money_Manager.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Email = "email1",
                            Name = "User1"
                        });
                });

            modelBuilder.Entity("Money_Manager.Models.Asset", b =>
                {
                    b.HasOne("Money_Manager.Models.User", "User")
                        .WithMany("Assets")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Money_Manager.Models.Category", b =>
                {
                    b.HasOne("Money_Manager.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentCategoryId");
                });

            modelBuilder.Entity("Money_Manager.Models.Transaction", b =>
                {
                    b.HasOne("Money_Manager.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Money_Manager.Models.Asset", "Destination")
                        .WithMany()
                        .HasForeignKey("DestinationAssetId");

                    b.HasOne("Money_Manager.Models.Asset", "Source")
                        .WithMany()
                        .HasForeignKey("SourceAssetId");

                    b.HasOne("Money_Manager.Models.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId");
                });
#pragma warning restore 612, 618
        }
    }
}