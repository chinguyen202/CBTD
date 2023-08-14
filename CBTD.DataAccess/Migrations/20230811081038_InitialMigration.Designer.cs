﻿// <auto-generated />
using CBTD.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace CBTD.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230811081038_InitialMigration")]
    partial class InitialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("CBTD.DataAccess.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Non-Alcoholic Beverages"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Wine"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "Snacks"
                        });
                });

            modelBuilder.Entity("CBTD.DataAccess.Models.Manufacturer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Coca-Cola"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Abncsdghjflkasdj"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Trinchero Family Estates"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Frito Lay"
                        });
                });

            modelBuilder.Entity("CBTD.DataAccess.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("DozenPrice")
                        .HasColumnType("double precision");

                    b.Property<double>("HalfDozenPrice")
                        .HasColumnType("double precision");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<double>("ListPrice")
                        .HasColumnType("double precision");

                    b.Property<int>("ManufacturerId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Size")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("UPC")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("UnitPrice")
                        .HasColumnType("double precision");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            Description = "The primary taste of Coca-Cola is thought to come from vanilla and cinnamon, with trace amounts of essential oils, and spices such as nutmeg.",
                            DozenPrice = 0.98999999999999999,
                            HalfDozenPrice = 1.24,
                            ImageUrl = "/images/products/Coke.jpg",
                            ListPrice = 1.99,
                            ManufacturerId = 1,
                            Name = "Coca Cola Classic",
                            Size = "33cl",
                            UPC = "4894034",
                            UnitPrice = 1.49
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            Description = "<p>The Yellow Tail Shiraz has a deep red color with bright purple hues, characteristic of fine young wines. It displays impressive <strong>spice, licorice, and black currant aromas</strong>. The palate is perfectly balanced with soft tannins and fine French Oak, further complemented by ripe fruit flavors.</p>",
                            DozenPrice = 6.9900000000000002,
                            HalfDozenPrice = 7.9900000000000002,
                            ImageUrl = "/images/products/YellowTail.png",
                            ListPrice = 9.9900000000000002,
                            ManufacturerId = 2,
                            Name = "Yellow Tail Shiraz",
                            Size = "750 ml",
                            UPC = "031259008943",
                            UnitPrice = 8.9900000000000002
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 2,
                            Description = "Menage a Trois California Red Blend exposes the fresh, ripe, jam-like fruit that is the calling card of California wine. Forward, spicy and soft, this delicious dalliance makes the perfect accompaniment for grilled meats or chicken.",
                            DozenPrice = 9.9900000000000002,
                            HalfDozenPrice = 10.75,
                            ImageUrl = "/images/products/menage.jpg",
                            ListPrice = 12.99,
                            ManufacturerId = 3,
                            Name = "Menage a Trois Merlot",
                            Size = "750 ml",
                            UPC = "099988071096",
                            UnitPrice = 11.49
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 3,
                            Description = "The chip that packs a flavorful punch with the classic crunch. Boldly seasoned with three cheeses, tomatoes, onions, and a savory blend of spices. Indulge yourself or share with large gatherings",
                            DozenPrice = 0.68999999999999995,
                            HalfDozenPrice = 1.05,
                            ImageUrl = "/images/products/doritos.jpg",
                            ListPrice = 1.99,
                            ManufacturerId = 4,
                            Name = "Doritos",
                            Size = "175 grams",
                            UPC = "028400443753",
                            UnitPrice = 1.49
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 3,
                            Description = "The fun, crunchy snack that is made with real cheese. Packed with flavor that satisfies. Always a crowd favorite.",
                            DozenPrice = 0.68999999999999995,
                            HalfDozenPrice = 1.05,
                            ImageUrl = "/images/products/cheetos.jpg",
                            ListPrice = 1.99,
                            ManufacturerId = 4,
                            Name = "Cheetos",
                            Size = "200 grams",
                            UPC = "028400443661",
                            UnitPrice = 1.49
                        });
                });

            modelBuilder.Entity("CBTD.DataAccess.Models.Product", b =>
                {
                    b.HasOne("CBTD.DataAccess.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CBTD.DataAccess.Models.Manufacturer", "Manufacturer")
                        .WithMany()
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("Manufacturer");
                });
#pragma warning restore 612, 618
        }
    }
}