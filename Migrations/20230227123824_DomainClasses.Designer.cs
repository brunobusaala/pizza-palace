﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NewPizzaPalace.Data;

namespace NewPizzaPalace.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20230227123824_DomainClasses")]
    partial class DomainClasses
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NewPizzaPalace.Models.BasicTopping", b =>
                {
                    b.Property<int>("BasicTopppingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Cheese")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Ham")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pepperoni")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Pineapple")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SizeID")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("BasicTopppingID");

                    b.HasIndex("SizeID");

                    b.ToTable("BasicToppings");

                    b.HasData(
                        new
                        {
                            BasicTopppingID = 1,
                            Cheese = 0.5m,
                            Ham = 0.5m,
                            Pepperoni = 0.5m,
                            Pineapple = 0.5m,
                            SizeID = "Small"
                        },
                        new
                        {
                            BasicTopppingID = 2,
                            Cheese = 0.75m,
                            Ham = 0.75m,
                            Pepperoni = 0.75m,
                            Pineapple = 0.75m,
                            SizeID = "Medium"
                        },
                        new
                        {
                            BasicTopppingID = 3,
                            Cheese = 1m,
                            Ham = 1m,
                            Pepperoni = 1m,
                            Pineapple = 1m,
                            SizeID = "Large"
                        });
                });

            modelBuilder.Entity("NewPizzaPalace.Models.DeluxeTopping", b =>
                {
                    b.Property<int>("DeluxeToppingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("FetaCheese")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Olives")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Sausage")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("SizeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Tomatoes")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("DeluxeToppingID");

                    b.HasIndex("SizeID");

                    b.ToTable("DeluxeToppings");

                    b.HasData(
                        new
                        {
                            DeluxeToppingID = 1,
                            FetaCheese = 2m,
                            Olives = 2m,
                            Sausage = 2m,
                            SizeID = "Small",
                            Tomatoes = 2m
                        },
                        new
                        {
                            DeluxeToppingID = 2,
                            FetaCheese = 3m,
                            Olives = 3m,
                            Sausage = 3m,
                            SizeID = "Medium",
                            Tomatoes = 3m
                        },
                        new
                        {
                            DeluxeToppingID = 3,
                            FetaCheese = 4m,
                            Olives = 4m,
                            Sausage = 4m,
                            SizeID = "Large",
                            Tomatoes = 4m
                        });
                });

            modelBuilder.Entity("NewPizzaPalace.Models.Size", b =>
                {
                    b.Property<string>("SizeID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("SizeID");

                    b.ToTable("Size");

                    b.HasData(
                        new
                        {
                            SizeID = "Small",
                            Price = 12m
                        },
                        new
                        {
                            SizeID = "Medium",
                            Price = 14m
                        },
                        new
                        {
                            SizeID = "Large",
                            Price = 16m
                        });
                });

            modelBuilder.Entity("NewPizzaPalace.Models.BasicTopping", b =>
                {
                    b.HasOne("NewPizzaPalace.Models.Size", "Size")
                        .WithMany("BasicToppings")
                        .HasForeignKey("SizeID");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("NewPizzaPalace.Models.DeluxeTopping", b =>
                {
                    b.HasOne("NewPizzaPalace.Models.Size", "Size")
                        .WithMany("DeluxeToppings")
                        .HasForeignKey("SizeID");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("NewPizzaPalace.Models.Size", b =>
                {
                    b.Navigation("BasicToppings");

                    b.Navigation("DeluxeToppings");
                });
#pragma warning restore 612, 618
        }
    }
}