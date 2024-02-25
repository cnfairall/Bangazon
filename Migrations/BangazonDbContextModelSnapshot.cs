﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Bangazon.Migrations
{
    [DbContext(typeof(BangazonDbContext))]
    partial class BangazonDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Bangazon.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Sporting Goods"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Clothing"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Dry Goods"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Books"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Automotive"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DatePlaced")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("Open")
                        .HasColumnType("boolean");

                    b.Property<int?>("PaymentTypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CustomerId = 2,
                            Open = true
                        },
                        new
                        {
                            Id = 2,
                            CustomerId = 3,
                            DatePlaced = new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Open = false,
                            PaymentTypeId = 1
                        },
                        new
                        {
                            Id = 3,
                            CustomerId = 1,
                            DatePlaced = new DateTime(2023, 12, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Open = false,
                            PaymentTypeId = 2
                        },
                        new
                        {
                            Id = 4,
                            CustomerId = 3,
                            Open = true
                        });
                });

            modelBuilder.Entity("Bangazon.Models.PaymentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("PaymentTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Debit Card"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Credit Card"
                        },
                        new
                        {
                            Id = 3,
                            Name = "PayPal"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateAdded")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("PricePer")
                        .HasColumnType("numeric");

                    b.Property<int>("QuantityAvail")
                        .HasColumnType("integer");

                    b.Property<int>("SellerId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("SellerId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateAdded = new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Always comes back!",
                            ImageUrl = "https://tse1.mm.bing.net/th?id=OIP.HFDa4OD0-IeYTX5t5CB1FgHaGq&pid=Api&P=0&h=220",
                            PricePer = 12.00m,
                            QuantityAvail = 15,
                            SellerId = 1,
                            Title = "Bone Boomerang"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            DateAdded = new DateTime(2024, 1, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Not cursed!",
                            ImageUrl = "https://sp.yimg.com/ib/th?id=OPHS.0VTDiWr0%2fU%2fVFw474C474&o=5&pid=21.1&w=160&h=105",
                            PricePer = 120.00m,
                            QuantityAvail = 1,
                            SellerId = 2,
                            Title = "Wedding gown"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            DateAdded = new DateTime(2024, 2, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Everything you need",
                            ImageUrl = "https://sp.yimg.com/ib/th?id=OPHS.BHEw0gGLElfx9A474C474&o=5&pid=21.1&w=160&h=105",
                            PricePer = 60.00m,
                            QuantityAvail = 6,
                            SellerId = 1,
                            Title = "Prepper Bucket"
                        },
                        new
                        {
                            Id = 4,
                            CategoryId = 4,
                            DateAdded = new DateTime(2023, 12, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "very long",
                            ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.UlJzwVqHm_CbLNAdaKcKNAHaLH&pid=Api&P=0&h=220",
                            PricePer = 8.00m,
                            QuantityAvail = 2,
                            SellerId = 2,
                            Title = "The Memoir Book"
                        },
                        new
                        {
                            Id = 5,
                            CategoryId = 2,
                            DateAdded = new DateTime(2024, 2, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Description = "Nashville classic",
                            ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.UlJzwVqHm_CbLNAdaKcKNAHaLH&pid=Api&P=0&h=220",
                            PricePer = 12.00m,
                            QuantityAvail = 20,
                            SellerId = 2,
                            Title = "Cowgirl Hat"
                        });
                });

            modelBuilder.Entity("Bangazon.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsSeller")
                        .HasColumnType("boolean");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Uid")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "24 Hollyhock Ln, Atlanta, GA 13024",
                            Email = "fastcar@yahoo.com",
                            FirstName = "Larry",
                            ImageUrl = "https://up.yimg.com/ib/th?id=OIP.IcMrOf627VHm5umBg-NdkQHaMC&%3Bpid=Api&rs=1&c=1&qlt=95&w=76&h=123",
                            IsSeller = true,
                            LastName = "Dingle",
                            Uid = "Z487K28",
                            Username = "fastestCar"
                        },
                        new
                        {
                            Id = 2,
                            Address = "1824A Cypress Circle, Detroit, MI 57351",
                            Email = "nightmoves81@gmail.com",
                            FirstName = "Denise",
                            ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.roc7SqiVeXDbnAinXSVdTQHaNK&pid=Api&P=0&h=220",
                            IsSeller = false,
                            LastName = "Arriat",
                            Uid = "FQ985B8",
                            Username = "NightMoves81"
                        },
                        new
                        {
                            Id = 3,
                            Address = "7 Moonlight Way, Miami, FL 92118",
                            Email = "lilyrose@yahoo.com",
                            FirstName = "Sheryl",
                            ImageUrl = "https://tse2.mm.bing.net/th?id=OIP.vahulDgxNXU-mGHiUzFbLwHaLH&pid=Api&P=0&h=220",
                            IsSeller = true,
                            LastName = "Barnes",
                            Uid = "Z487K28",
                            Username = "LilyRose3"
                        });
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.Property<int>("OrdersId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductsId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersId", "ProductsId");

                    b.HasIndex("ProductsId");

                    b.ToTable("OrderProduct");
                });

            modelBuilder.Entity("Bangazon.Models.Order", b =>
                {
                    b.HasOne("Bangazon.Models.User", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Bangazon.Models.Product", b =>
                {
                    b.HasOne("Bangazon.Models.User", "Seller")
                        .WithMany()
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("OrderProduct", b =>
                {
                    b.HasOne("Bangazon.Models.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bangazon.Models.Product", null)
                        .WithMany()
                        .HasForeignKey("ProductsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
