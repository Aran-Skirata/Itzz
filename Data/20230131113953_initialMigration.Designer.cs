﻿// <auto-generated />
using System;
using Itzz.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Itzz.Data
{
    [DbContext(typeof(DataContext))]
    [Migration("20230131113953_initialMigration")]
    partial class initialMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.2");

            modelBuilder.Entity("CargoOrder", b =>
                {
                    b.Property<int>("CargoesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("OrdersId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CargoesId", "OrdersId");

                    b.HasIndex("OrdersId");

                    b.ToTable("CargoOrder");
                });

            modelBuilder.Entity("Itzz.Entities.Cargo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StorageName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("StorageType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Uuid")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Cargoes");
                });

            modelBuilder.Entity("Itzz.Entities.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Comments")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DueTime")
                        .HasColumnType("TEXT");

                    b.Property<string>("ExecutionMethod")
                        .HasColumnType("TEXT");

                    b.Property<int>("Priority")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RouteId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("TransportMeans")
                        .HasColumnType("TEXT");

                    b.Property<string>("Uuid")
                        .HasColumnType("TEXT");

                    b.Property<int>("Verification")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("RouteId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Itzz.Entities.Route", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("RecipientLoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SenderLoc")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Routes");
                });

            modelBuilder.Entity("CargoOrder", b =>
                {
                    b.HasOne("Itzz.Entities.Cargo", null)
                        .WithMany()
                        .HasForeignKey("CargoesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Itzz.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Itzz.Entities.Order", b =>
                {
                    b.HasOne("Itzz.Entities.Route", "Route")
                        .WithMany("Orders")
                        .HasForeignKey("RouteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Route");
                });

            modelBuilder.Entity("Itzz.Entities.Route", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
