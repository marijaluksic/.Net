﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZavrsniLuksic.DAL;

#nullable disable

namespace ZavrsniLuksic.DAL.Migrations
{
    [DbContext(typeof(PaprichicaManagerDbContext))]
    partial class PaprichicaManagerDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ZavrsniLuksic.Model.Cuisine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cuisines");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Name = "Talijanska"
                        },
                        new
                        {
                            ID = 2,
                            Name = "Meksička"
                        },
                        new
                        {
                            ID = 3,
                            Name = "Francuska"
                        },
                        new
                        {
                            ID = 4,
                            Name = "Japanska"
                        },
                        new
                        {
                            ID = 5,
                            Name = "Kineska"
                        },
                        new
                        {
                            ID = 6,
                            Name = "Španjolska"
                        },
                        new
                        {
                            ID = 7,
                            Name = "Etiopska"
                        });
                });

            modelBuilder.Entity("ZavrsniLuksic.Model.Dish", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Price")
                        .IsRequired()
                        .HasMaxLength(3)
                        .HasColumnType("nvarchar(3)");

                    b.Property<int?>("RestaurantID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int?>("SpicinessID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("RestaurantID");

                    b.HasIndex("SpicinessID");

                    b.ToTable("Dishes");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "Lazanje sa umakom od mljevenog mesa dinstanog na luku, češnjaku, rajčicama te maslinovom ulju sa začinima.",
                            Name = "Lasagne Bolognese",
                            Price = "78",
                            RestaurantID = 1,
                            SpicinessID = 1
                        },
                        new
                        {
                            ID = 2,
                            Description = "Šnite bifteka s pečenim krumpirom, rukolom, crvenim radičem i cherry rajčicama.",
                            Name = "Rustica",
                            Price = "158",
                            RestaurantID = 1,
                            SpicinessID = 2
                        },
                        new
                        {
                            ID = 3,
                            Description = "Zapečeni kaktus s grahom i Jalapeno paprikom.",
                            Name = "Nopalitos con frijoles",
                            Price = "55",
                            RestaurantID = 2,
                            SpicinessID = 4
                        },
                        new
                        {
                            ID = 4,
                            Description = "Piletina u umaku od kakaa, gljive i 20 vrsta začina.",
                            Name = "Pollo con mole poblano",
                            Price = "100",
                            RestaurantID = 2,
                            SpicinessID = 3
                        },
                        new
                        {
                            ID = 5,
                            Description = "Pileća krilca u marinadi od chilija.",
                            Name = "Alitas de pollo en chili",
                            Price = "80",
                            RestaurantID = 2,
                            SpicinessID = 5
                        });
                });

            modelBuilder.Entity("ZavrsniLuksic.Model.Restaurant", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("CuisineID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CuisineID");

                    b.ToTable("Restaurants");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Address = "Gajeva 9, Zagreb",
                            CuisineID = 1,
                            Name = "Boban",
                            PhoneNumber = "4811549",
                            Url = "http://www.boban.hr/home"
                        },
                        new
                        {
                            ID = 2,
                            Address = "Savska cesta 154, Zagreb",
                            CuisineID = 2,
                            Name = "Mex Cantina",
                            PhoneNumber = "6192156",
                            Url = "https://mexcantina.eatbu.hr/?lang=hr"
                        });
                });

            modelBuilder.Entity("ZavrsniLuksic.Model.Spiciness", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Spicinesses");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Level = "Nije ni posoljeno"
                        },
                        new
                        {
                            ID = 2,
                            Level = "Prstohvat cimeta mi je doseg"
                        },
                        new
                        {
                            ID = 3,
                            Level = "Pikantno"
                        },
                        new
                        {
                            ID = 4,
                            Level = "Neki to vole vruće"
                        },
                        new
                        {
                            ID = 5,
                            Level = "Eh, da je Dante samo znao za tebe..."
                        });
                });

            modelBuilder.Entity("ZavrsniLuksic.Model.Dish", b =>
                {
                    b.HasOne("ZavrsniLuksic.Model.Restaurant", "Restaurant")
                        .WithMany()
                        .HasForeignKey("RestaurantID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ZavrsniLuksic.Model.Spiciness", "Spiciness")
                        .WithMany("Dishes")
                        .HasForeignKey("SpicinessID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Restaurant");

                    b.Navigation("Spiciness");
                });

            modelBuilder.Entity("ZavrsniLuksic.Model.Restaurant", b =>
                {
                    b.HasOne("ZavrsniLuksic.Model.Cuisine", "Cuisine")
                        .WithMany("Restaurants")
                        .HasForeignKey("CuisineID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cuisine");
                });

            modelBuilder.Entity("ZavrsniLuksic.Model.Cuisine", b =>
                {
                    b.Navigation("Restaurants");
                });

            modelBuilder.Entity("ZavrsniLuksic.Model.Spiciness", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
