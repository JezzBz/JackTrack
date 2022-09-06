﻿// <auto-generated />
using System;
using JackTrack.Entities.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace JackTrack.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220906105112_MissionInitMigration")]
    partial class MissionInitMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("JackTrack.Entities.Tasks.Mission", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("FromUserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.ToTable("Missions");
                });

            modelBuilder.Entity("JackTrack.Entities.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<long?>("MissionId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("MissionId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("JackTrack.Entities.Tasks.Mission", b =>
                {
                    b.HasOne("JackTrack.Entities.Users.User", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("FromUser");
                });

            modelBuilder.Entity("JackTrack.Entities.Users.User", b =>
                {
                    b.HasOne("JackTrack.Entities.Tasks.Mission", null)
                        .WithMany("ToUsers")
                        .HasForeignKey("MissionId");
                });

            modelBuilder.Entity("JackTrack.Entities.Tasks.Mission", b =>
                {
                    b.Navigation("ToUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
