﻿// <auto-generated />
using System;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.17")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Mc2.CrudTest.Presentation.Server.Models.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("BankAccounNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Family")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Name", "Family", "BirthDate")
                        .IsUnique();

                    b.HasIndex("Name", "Family", "Email")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Mc2.CrudTest.Presentation.Server.Models.CustomerEntity", b =>
                {
                    b.OwnsOne("Mc2.CrudTest.Presentation.Server.Models.CustomerEntity+PhoneNumebrEntity", "PhoneNumebr", b1 =>
                        {
                            b1.Property<int>("CustomerEntityId")
                                .HasColumnType("int");

                            b1.Property<long>("CountryCode")
                                .HasColumnType("bigint");

                            b1.Property<decimal>("MobileNumber")
                                .HasColumnType("decimal(20,0)");

                            b1.HasKey("CustomerEntityId");

                            b1.ToTable("Customers");

                            b1.WithOwner()
                                .HasForeignKey("CustomerEntityId");
                        });

                    b.Navigation("PhoneNumebr")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
