﻿// <auto-generated />
using System;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240419190823_restoranDB")]
    partial class restoranDB
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Entity.Category", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Entity.Customer", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("ID");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("Entity.MenuItem", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<Guid>("CategoryID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<bool>("GlutenFree")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsPermanent")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsVegan")
                        .HasColumnType("boolean");

                    b.Property<DateOnly>("MenuDate")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("MenuItem");
                });

            modelBuilder.Entity("Entity.Order", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasDefaultValueSql("gen_random_uuid()");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<Guid>("CustomerID")
                        .HasColumnType("uuid");

                    b.Property<bool>("IsChecked")
                        .HasColumnType("boolean");

                    b.Property<Guid>("MenuItemID")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("OrderDate")
                        .HasMaxLength(100)
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("OrderNote")
                        .HasColumnType("text");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("MenuItemID");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("Entity.MenuItem", b =>
                {
                    b.HasOne("Entity.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Entity.Order", b =>
                {
                    b.HasOne("Entity.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.MenuItem", "MenuItem")
                        .WithMany()
                        .HasForeignKey("MenuItemID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("MenuItem");
                });
#pragma warning restore 612, 618
        }
    }
}
