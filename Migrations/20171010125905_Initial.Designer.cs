﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using WarehouseServer.Providers;

namespace WarehouseServer.Migrations
{
    [DbContext(typeof(EFContext))]
    [Migration("20171010125905_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452");

            modelBuilder.Entity("WarehouseServer.Models.Client", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<string>("FIO")
                        .IsRequired()
                        .HasColumnName("fio")
                        .HasMaxLength(70);

                    b.Property<string>("Phone")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("clients");
                });

            modelBuilder.Entity("WarehouseServer.Models.Good", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(40);

                    b.Property<int?>("Price")
                        .HasColumnName("price");

                    b.Property<int>("ProviderId")
                        .HasColumnName("provider_id");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("goods");
                });

            modelBuilder.Entity("WarehouseServer.Models.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Address")
                        .HasColumnName("address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("name")
                        .HasMaxLength(40);

                    b.Property<string>("Phone")
                        .HasColumnName("phone");

                    b.HasKey("Id");

                    b.ToTable("providers");
                });

            modelBuilder.Entity("WarehouseServer.Models.Realization", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<int>("ClientId")
                        .HasColumnName("client_id");

                    b.Property<DateTime>("Date")
                        .HasColumnName("date");

                    b.Property<int>("GoodId")
                        .HasColumnName("good_id");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("GoodId");

                    b.ToTable("realizations");
                });

            modelBuilder.Entity("WarehouseServer.Models.Receipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id");

                    b.Property<string>("Date")
                        .IsRequired()
                        .HasColumnName("date");

                    b.Property<int>("GoodId")
                        .HasColumnName("good_id");

                    b.Property<int>("Quantity")
                        .HasColumnName("quantity");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.ToTable("receipts");
                });

            modelBuilder.Entity("WarehouseServer.Models.Good", b =>
                {
                    b.HasOne("WarehouseServer.Models.Provider", "Provider")
                        .WithMany("Goods")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarehouseServer.Models.Realization", b =>
                {
                    b.HasOne("WarehouseServer.Models.Client", "Client")
                        .WithMany("Realizations")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("WarehouseServer.Models.Good", "Good")
                        .WithMany("Realizations")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("WarehouseServer.Models.Receipt", b =>
                {
                    b.HasOne("WarehouseServer.Models.Good", "Good")
                        .WithMany("Receipts")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
