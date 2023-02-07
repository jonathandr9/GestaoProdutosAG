﻿// <auto-generated />
using System;
using GestaoProdutosAG.DbAdapter.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GestaoProdutosAG.DbAdapter.Migrations
{
    [DbContext(typeof(ProductManagementContext))]
    [Migration("20230207202755_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("GestaoProdutosAG.Domain.Models.Product", b =>
                {
                    b.Property<int>("Code")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ExpirationDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ManufacturingDate")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Status")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendorCNPJ")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendorCode")
                        .HasColumnType("INTEGER");

                    b.Property<string>("VendorDescription")
                        .HasColumnType("TEXT");

                    b.HasKey("Code");

                    b.ToTable("Products");
                });
#pragma warning restore 612, 618
        }
    }
}
