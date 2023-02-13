﻿// <auto-generated />
using System;
using Cinema.Server;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Cinema.Server.Migrations
{
    [DbContext(typeof(CinemaDBContext))]
    [Migration("20230211133527_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Cinema.Server.Models.Booking", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("Cinema.Server.Models.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Points")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Cinema.Server.Models.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("FirstName")
                        .HasColumnType("int");

                    b.Property<string>("JobTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LastName")
                        .HasColumnType("int");

                    b.Property<int>("Password")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Cinema.Server.Models.Movie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<string>("AgeRating")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Duration")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Trailer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("Cinema.Server.Models.Room", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Decom")
                        .HasColumnType("bit");

                    b.Property<int>("SeatQty")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.ToTable("Rooms");
                });

            modelBuilder.Entity("Cinema.Server.Models.Screening", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int>("MmovieID")
                        .HasColumnType("int");

                    b.Property<int>("MovieID")
                        .HasColumnType("int");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("MovieID");

                    b.HasIndex("RoomID");

                    b.ToTable("Screenings");
                });

            modelBuilder.Entity("Cinema.Server.Models.Seat", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<bool>("Booked")
                        .HasColumnType("bit");

                    b.Property<int>("BookingID")
                        .HasColumnType("int");

                    b.Property<bool>("DisabiltySeat")
                        .HasColumnType("bit");

                    b.Property<int>("ScreeningID")
                        .HasColumnType("int");

                    b.Property<string>("SeatNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BookingID");

                    b.HasIndex("ScreeningID");

                    b.ToTable("Seats");
                });

            modelBuilder.Entity("Cinema.Server.Models.TicketType", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"));

                    b.Property<int?>("BookingID")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("BookingID");

                    b.ToTable("TicketType");
                });

            modelBuilder.Entity("Cinema.Server.Models.Booking", b =>
                {
                    b.HasOne("Cinema.Server.Models.Customer", "Customer")
                        .WithMany("Bookings")
                        .HasForeignKey("CustomerID");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("Cinema.Server.Models.Screening", b =>
                {
                    b.HasOne("Cinema.Server.Models.Movie", "Movie")
                        .WithMany("Screenings")
                        .HasForeignKey("MovieID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Server.Models.Room", "Room")
                        .WithMany("Screenings")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("Cinema.Server.Models.Seat", b =>
                {
                    b.HasOne("Cinema.Server.Models.Booking", "Booking")
                        .WithMany("Seats")
                        .HasForeignKey("BookingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Cinema.Server.Models.Screening", "Screening")
                        .WithMany()
                        .HasForeignKey("ScreeningID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Booking");

                    b.Navigation("Screening");
                });

            modelBuilder.Entity("Cinema.Server.Models.TicketType", b =>
                {
                    b.HasOne("Cinema.Server.Models.Booking", null)
                        .WithMany("TicketTypes")
                        .HasForeignKey("BookingID");
                });

            modelBuilder.Entity("Cinema.Server.Models.Booking", b =>
                {
                    b.Navigation("Seats");

                    b.Navigation("TicketTypes");
                });

            modelBuilder.Entity("Cinema.Server.Models.Customer", b =>
                {
                    b.Navigation("Bookings");
                });

            modelBuilder.Entity("Cinema.Server.Models.Movie", b =>
                {
                    b.Navigation("Screenings");
                });

            modelBuilder.Entity("Cinema.Server.Models.Room", b =>
                {
                    b.Navigation("Screenings");
                });
#pragma warning restore 612, 618
        }
    }
}
