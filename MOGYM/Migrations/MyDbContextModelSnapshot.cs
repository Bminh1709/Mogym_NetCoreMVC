﻿// <auto-generated />
using System;
using MOGYM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MOGYM.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MOGYM.Models.BranchModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasMaxLength(6)
                        .HasColumnType("nvarchar(6)");

                    b.HasKey("Id");

                    b.ToTable("Branches", (string)null);
                });

            modelBuilder.Entity("MOGYM.Models.FeedbackModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<int>("EmotionalLevel")
                        .HasColumnType("int");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.HasIndex("TrainerId");

                    b.ToTable("Feedbacks", (string)null);
                });

            modelBuilder.Entity("MOGYM.Models.ServiceModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Services", (string)null);
                });

            modelBuilder.Entity("MOGYM.Models.TimeTableModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWeek")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<int>("MarkedTime")
                        .HasColumnType("int");

                    b.Property<string>("Task")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TrainerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.ToTable("TimeTables", (string)null);
                });

            modelBuilder.Entity("MOGYM.Models.UserModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Avatar")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Gmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("JoinedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Users", (string)null);

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("MOGYM.Models.WorkoutScheduleModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CurrentWeek")
                        .HasColumnType("int");

                    b.Property<int>("DayOfWeek")
                        .HasColumnType("int");

                    b.Property<string>("Task")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TraineeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TraineeId");

                    b.ToTable("WorkoutSchedules", (string)null);
                });

            modelBuilder.Entity("MOGYM.Models.AdminModel", b =>
                {
                    b.HasBaseType("MOGYM.Models.UserModel");

                    b.ToTable("Admins", (string)null);
                });

            modelBuilder.Entity("MOGYM.Models.TraineeModel", b =>
                {
                    b.HasBaseType("MOGYM.Models.UserModel");

                    b.Property<int?>("Height")
                        .HasColumnType("int");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TrainerId")
                        .HasColumnType("int");

                    b.Property<int?>("Weight")
                        .HasColumnType("int");

                    b.HasIndex("TrainerId");

                    b.ToTable("Trainees", (string)null);
                });

            modelBuilder.Entity("MOGYM.Models.TrainerModel", b =>
                {
                    b.HasBaseType("MOGYM.Models.UserModel");

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.HasIndex("AdminId");

                    b.ToTable("Trainers", (string)null);
                });

            modelBuilder.Entity("MOGYM.Models.FeedbackModel", b =>
                {
                    b.HasOne("MOGYM.Models.BranchModel", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MOGYM.Models.TrainerModel", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId");

                    b.Navigation("Branch");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("MOGYM.Models.ServiceModel", b =>
                {
                    b.HasOne("MOGYM.Models.BranchModel", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("MOGYM.Models.TimeTableModel", b =>
                {
                    b.HasOne("MOGYM.Models.TrainerModel", "Trainer")
                        .WithMany()
                        .HasForeignKey("TrainerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("MOGYM.Models.UserModel", b =>
                {
                    b.HasOne("MOGYM.Models.BranchModel", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.Navigation("Branch");
                });

            modelBuilder.Entity("MOGYM.Models.WorkoutScheduleModel", b =>
                {
                    b.HasOne("MOGYM.Models.TraineeModel", "Trainee")
                        .WithMany()
                        .HasForeignKey("TraineeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Trainee");
                });

            modelBuilder.Entity("MOGYM.Models.AdminModel", b =>
                {
                    b.HasOne("MOGYM.Models.UserModel", null)
                        .WithOne()
                        .HasForeignKey("MOGYM.Models.AdminModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MOGYM.Models.TraineeModel", b =>
                {
                    b.HasOne("MOGYM.Models.UserModel", null)
                        .WithOne()
                        .HasForeignKey("MOGYM.Models.TraineeModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MOGYM.Models.TrainerModel", "Trainer")
                        .WithMany("Trainees")
                        .HasForeignKey("TrainerId");

                    b.Navigation("Trainer");
                });

            modelBuilder.Entity("MOGYM.Models.TrainerModel", b =>
                {
                    b.HasOne("MOGYM.Models.AdminModel", "Admin")
                        .WithMany("Trainers")
                        .HasForeignKey("AdminId");

                    b.HasOne("MOGYM.Models.UserModel", null)
                        .WithOne()
                        .HasForeignKey("MOGYM.Models.TrainerModel", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Admin");
                });

            modelBuilder.Entity("MOGYM.Models.AdminModel", b =>
                {
                    b.Navigation("Trainers");
                });

            modelBuilder.Entity("MOGYM.Models.TrainerModel", b =>
                {
                    b.Navigation("Trainees");
                });
#pragma warning restore 612, 618
        }
    }
}
