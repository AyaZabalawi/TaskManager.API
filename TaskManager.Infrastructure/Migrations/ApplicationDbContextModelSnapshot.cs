﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TaskManager.Infrastructure;

#nullable disable

namespace TaskManager.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TaskManager.Core.Domain.Entities.Item", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateOnly>("DueDate")
                        .HasColumnType("date");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Tasks", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("6afa3e32-2ba9-4a5c-9889-bd06f59607e9"),
                            Description = "Description 1",
                            DueDate = new DateOnly(1, 1, 1),
                            Status = true,
                            Title = "Task 1"
                        },
                        new
                        {
                            Id = new Guid("e3e77baf-8d0e-4472-9148-41e6c0332419"),
                            Description = "Description 2",
                            DueDate = new DateOnly(1, 1, 1),
                            Status = true,
                            Title = "Task 2"
                        },
                        new
                        {
                            Id = new Guid("5ce5c3ea-b45c-47dd-8765-aa2b50166e65"),
                            Description = "Description 3",
                            DueDate = new DateOnly(1, 1, 1),
                            Status = false,
                            Title = "Task 3"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}