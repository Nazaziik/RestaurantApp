﻿// <auto-generated />
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    [DbContext(typeof(StoreContext))]
    [Migration("20230417083201_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.15");

            modelBuilder.Entity("DishProduct", b =>
                {
                    b.Property<int>("DishesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DishesId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("DishProduct");

                    b.HasData(
                        new
                        {
                            DishesId = 1,
                            ProductsId = 1
                        },
                        new
                        {
                            DishesId = 3,
                            ProductsId = 1
                        },
                        new
                        {
                            DishesId = 2,
                            ProductsId = 2
                        },
                        new
                        {
                            DishesId = 3,
                            ProductsId = 2
                        },
                        new
                        {
                            DishesId = 3,
                            ProductsId = 3
                        });
                });

            modelBuilder.Entity("Domain.Entities.Dish", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(400)
                        .HasColumnType("TEXT");

                    b.Property<int>("DishType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<string>("PictureUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Some dish 0",
                            DishType = 1,
                            Name = "Sombrero",
                            PictureUrl = "zzz",
                            Price = 20.50m
                        },
                        new
                        {
                            Id = 2,
                            Description = "Some dish 1",
                            DishType = 3,
                            Name = "Mustangi",
                            PictureUrl = "xxx",
                            Price = 73.0m
                        },
                        new
                        {
                            Id = 3,
                            Description = "Some dish 2",
                            DishType = 0,
                            Name = "Eleonore",
                            PictureUrl = "ccc",
                            Price = 2.0m
                        });
                });

            modelBuilder.Entity("Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductType")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fish",
                            ProductType = 1
                        },
                        new
                        {
                            Id = 2,
                            Name = "Milk",
                            ProductType = 0
                        },
                        new
                        {
                            Id = 3,
                            Name = "Beef",
                            ProductType = 2
                        });
                });

            modelBuilder.Entity("DishProduct", b =>
                {
                    b.HasOne("Domain.Entities.Dish", null)
                        .WithMany()
                        .HasForeignKey("DishesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Domain.Entities.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}