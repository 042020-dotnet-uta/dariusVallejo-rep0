﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using p0;

namespace p0.Migrations
{
    [DbContext(typeof(BusinessContext))]
    [Migration("20200503045658_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("p0.Customer", b =>
                {
                    b.Property<string>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("firstName")
                        .HasColumnType("TEXT");

                    b.Property<string>("lastName")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("p0.Inventory", b =>
                {
                    b.Property<string>("InventoryId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("productName")
                        .HasColumnType("TEXT");

                    b.Property<float>("productPrice")
                        .HasColumnType("REAL");

                    b.Property<int>("quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("InventoryId");

                    b.HasIndex("LocationId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("p0.Location", b =>
                {
                    b.Property<string>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("locationName")
                        .HasColumnType("TEXT");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");
                });

            modelBuilder.Entity("p0.Order", b =>
                {
                    b.Property<string>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LocationId")
                        .HasColumnType("TEXT");

                    b.Property<string>("orderDate")
                        .HasColumnType("TEXT");

                    b.Property<float>("total")
                        .HasColumnType("REAL");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("p0.OrderItem", b =>
                {
                    b.Property<string>("OrderItemId")
                        .HasColumnType("TEXT");

                    b.Property<string>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<int>("quantity")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderItemId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("p0.Inventory", b =>
                {
                    b.HasOne("p0.Location", null)
                        .WithMany("inventory")
                        .HasForeignKey("LocationId");
                });

            modelBuilder.Entity("p0.Order", b =>
                {
                    b.HasOne("p0.Customer", null)
                        .WithMany("orders")
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("p0.OrderItem", b =>
                {
                    b.HasOne("p0.Order", null)
                        .WithMany("orderItems")
                        .HasForeignKey("OrderId");
                });
#pragma warning restore 612, 618
        }
    }
}