﻿// <auto-generated />
using System;
using MeetUp.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MeetUp.Data.Migrations
{
    [DbContext(typeof(MeetUpContext))]
    [Migration("20181002124202_InitialCreation")]
    partial class InitialCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MeetUp.Data.Model.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeetUpId");

                    b.Property<string>("Number")
                        .IsRequired();

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("MeetUpId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("MeetUp.Data.Model.Lecture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lecturer")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<int>("MeetUpId");

                    b.Property<string>("Topic")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("MeetUpId")
                        .IsUnique();

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("MeetUp.Data.Model.MeetUp", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CreatedById");

                    b.Property<int>("CurrentVisitorsCount");

                    b.Property<DateTime>("Date");

                    b.Property<string>("From")
                        .IsRequired();

                    b.Property<int>("MaxVisitors");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(80);

                    b.Property<string>("To")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("MeetUps");
                });

            modelBuilder.Entity("MeetUp.Data.Model.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MeetUp.Data.Model.UserMeetUps", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MeetUpId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("MeetUpId");

                    b.HasIndex("UserId");

                    b.ToTable("UserMeetUps");
                });

            modelBuilder.Entity("MeetUp.Data.Model.Address", b =>
                {
                    b.HasOne("MeetUp.Data.Model.MeetUp")
                        .WithOne("Address")
                        .HasForeignKey("MeetUp.Data.Model.Address", "MeetUpId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MeetUp.Data.Model.Lecture", b =>
                {
                    b.HasOne("MeetUp.Data.Model.MeetUp")
                        .WithOne("Lecture")
                        .HasForeignKey("MeetUp.Data.Model.Lecture", "MeetUpId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("MeetUp.Data.Model.UserMeetUps", b =>
                {
                    b.HasOne("MeetUp.Data.Model.MeetUp")
                        .WithMany("Visitors")
                        .HasForeignKey("MeetUpId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("MeetUp.Data.Model.User")
                        .WithMany("MyMeetUps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
