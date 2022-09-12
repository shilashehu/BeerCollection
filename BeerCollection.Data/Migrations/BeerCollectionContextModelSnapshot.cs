﻿// <auto-generated />
using System;
using BeerCollection.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BeerCollection.Data.Migrations
{
    [DbContext(typeof(BeerCollectionContext))]
    partial class BeerCollectionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BeerCollection.Domain.Models.Beer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<double?>("AvgRating")
                        .HasColumnType("float");

                    b.Property<int>("BeerTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("Beer");
                });

            modelBuilder.Entity("BeerCollection.Domain.Models.BeerRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BeerId")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BeerId");

                    b.ToTable("BeerRating");
                });

            modelBuilder.Entity("BeerCollection.Domain.Models.BeerType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("BeerType");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Oldest style of beer.",
                            Name = "Ale"
                        },
                        new
                        {
                            Id = 2,
                            Description = "A newer style of beer.",
                            Name = "Lager"
                        });
                });

            modelBuilder.Entity("BeerCollection.Domain.Models.BeerRating", b =>
                {
                    b.HasOne("BeerCollection.Domain.Models.Beer", "Beer")
                        .WithMany("BeerRatings")
                        .HasForeignKey("BeerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Beer");
                });

            modelBuilder.Entity("BeerCollection.Domain.Models.Beer", b =>
                {
                    b.Navigation("BeerRatings");
                });
#pragma warning restore 612, 618
        }
    }
}
