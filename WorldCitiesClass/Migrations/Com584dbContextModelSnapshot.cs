﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WorldCitiesClass;

#nullable disable

namespace WorldCitiesClass.Migrations
{
    [DbContext(typeof(Com584dbContext))]
    partial class Com584dbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8mb4_0900_ai_ci")
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8mb4");

            modelBuilder.Entity("WorldCitiesClass.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int")
                        .HasColumnName("CountryID");

                    b.Property<decimal?>("Latitude")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<decimal?>("Longitude")
                        .HasPrecision(18, 4)
                        .HasColumnType("decimal(18,4)");

                    b.Property<string>("Name")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.Property<int>("Population")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CountryId" }, "FK_Cities_Countries");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("WorldCitiesClass.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    b.Property<string>("Iso2")
                        .HasMaxLength(2)
                        .HasColumnType("char(2)")
                        .IsFixedLength();

                    b.Property<string>("Iso3")
                        .HasMaxLength(3)
                        .HasColumnType("char(3)")
                        .IsFixedLength();

                    b.Property<string>("Name")
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("WorldCitiesClass.City", b =>
                {
                    b.HasOne("WorldCitiesClass.Country", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .HasConstraintName("FK_Cities_Countries");

                    b.Navigation("Country");
                });

            modelBuilder.Entity("WorldCitiesClass.Country", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
