﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace YakimGamesTaskBundle.Migrations
{
    [DbContext(typeof(TasksContext))]
    [Migration("20240408160725_AddTaskProgress")]
    partial class AddTaskProgress
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.3");

            modelBuilder.Entity("YakimGamesTaskBundle.Data.ProjectTask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BundleId")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("BundleId1")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CurrentProgress")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("DifficultyLevel")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProgressGoal")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("BundleId");

                    b.HasIndex("BundleId1");

                    b.ToTable("TaskItems");
                });

            modelBuilder.Entity("YakimGamesTaskBundle.Data.TaskBundle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TaskBundles");
                });

            modelBuilder.Entity("YakimGamesTaskBundle.Data.ProjectTask", b =>
                {
                    b.HasOne("YakimGamesTaskBundle.Data.TaskBundle", null)
                        .WithMany("Tasks")
                        .HasForeignKey("BundleId");

                    b.HasOne("YakimGamesTaskBundle.Data.TaskBundle", "Bundle")
                        .WithMany()
                        .HasForeignKey("BundleId1");

                    b.Navigation("Bundle");
                });

            modelBuilder.Entity("YakimGamesTaskBundle.Data.TaskBundle", b =>
                {
                    b.Navigation("Tasks");
                });
#pragma warning restore 612, 618
        }
    }
}
