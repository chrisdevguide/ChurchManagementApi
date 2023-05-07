﻿// <auto-generated />
using System;
using ChurchManagementApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ChurchManagementApi.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230504154217_5")]
    partial class _5
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ChurchManagementApi.Models.ChurchUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("ChurchName")
                        .HasColumnType("text");

                    b.Property<byte[]>("PasswordHash")
                        .HasColumnType("bytea");

                    b.Property<byte[]>("PasswordSalt")
                        .HasColumnType("bytea");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ChurchUsers");
                });

            modelBuilder.Entity("ChurchManagementApi.Models.Group", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Group");
                });

            modelBuilder.Entity("ChurchManagementApi.Models.Member", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ArchiveDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateOnly?>("BaptismDate")
                        .HasColumnType("date");

                    b.Property<DateOnly>("BirthDate")
                        .HasColumnType("date");

                    b.Property<Guid>("ChurchUserId")
                        .HasColumnType("uuid");

                    b.Property<string>("City")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<int>("Gender")
                        .HasColumnType("integer");

                    b.Property<bool>("HasAcceptedPrivacyPolicy")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsArchived")
                        .HasColumnType("boolean");

                    b.Property<bool>("IsWaterBaptized")
                        .HasColumnType("boolean");

                    b.Property<int>("MaritalStatus")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("Nationality")
                        .HasColumnType("integer");

                    b.Property<string>("Occupation")
                        .HasColumnType("text");

                    b.Property<string>("Phone")
                        .HasColumnType("text");

                    b.Property<string>("Surname")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ChurchUserId");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("GroupMember", b =>
                {
                    b.Property<Guid>("GroupsId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("MembersId")
                        .HasColumnType("uuid");

                    b.HasKey("GroupsId", "MembersId");

                    b.HasIndex("MembersId");

                    b.ToTable("GroupMember");
                });

            modelBuilder.Entity("ChurchManagementApi.Models.Member", b =>
                {
                    b.HasOne("ChurchManagementApi.Models.ChurchUser", "ChurchUser")
                        .WithMany()
                        .HasForeignKey("ChurchUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ChurchUser");
                });

            modelBuilder.Entity("GroupMember", b =>
                {
                    b.HasOne("ChurchManagementApi.Models.Group", null)
                        .WithMany()
                        .HasForeignKey("GroupsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ChurchManagementApi.Models.Member", null)
                        .WithMany()
                        .HasForeignKey("MembersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
