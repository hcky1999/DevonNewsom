﻿// <auto-generated />
using System;
using DojoSecrets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DojoSecrets.Migrations
{
    [DbContext(typeof(DojoSecretsContext))]
    partial class DojoSecretsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("DojoSecrets.Models.Like", b =>
                {
                    b.Property<int>("LikeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("SecretId");

                    b.Property<int>("UserId");

                    b.HasKey("LikeId");

                    b.HasIndex("SecretId");

                    b.HasIndex("UserId");

                    b.ToTable("likes");
                });

            modelBuilder.Entity("DojoSecrets.Models.Secret", b =>
                {
                    b.Property<int>("SecretId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int>("UserId");

                    b.HasKey("SecretId");

                    b.HasIndex("UserId");

                    b.ToTable("secrets");
                });

            modelBuilder.Entity("DojoSecrets.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("VARCHAR(45)");

                    b.Property<string>("Password")
                        .IsRequired();

                    b.Property<DateTime>("UpdatedAt");

                    b.HasKey("UserId");

                    b.ToTable("users");
                });

            modelBuilder.Entity("DojoSecrets.Models.Like", b =>
                {
                    b.HasOne("DojoSecrets.Models.Secret", "LikedSecret")
                        .WithMany("Likes")
                        .HasForeignKey("SecretId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("DojoSecrets.Models.User", "Liker")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("DojoSecrets.Models.Secret", b =>
                {
                    b.HasOne("DojoSecrets.Models.User", "Creator")
                        .WithMany("SecretsCreated")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}