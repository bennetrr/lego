﻿// <auto-generated />
using System;
using Bennetr.BrickInv.Api.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bennetr.BrickInv.Api.Migrations.BrickInv
{
    [DbContext(typeof(BrickInvContext))]
    partial class BrickInvContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.Group", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageUri")
                        .HasColumnType("longtext");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("OwnerId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("RebrickableApiKey")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.GroupInvite", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("GroupId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("IssuerId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("RecipientId")
                        .HasColumnType("varchar(36)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.HasIndex("IssuerId");

                    b.HasIndex("RecipientId");

                    b.ToTable("GroupInvites");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.Part", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("ImageUri")
                        .HasColumnType("longtext");

                    b.Property<string>("PartColor")
                        .HasColumnType("longtext");

                    b.Property<string>("PartId")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("PartName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PresentCount")
                        .HasColumnType("int");

                    b.Property<string>("SetId")
                        .HasColumnType("varchar(36)");

                    b.Property<int>("TotalCount")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("SetId");

                    b.ToTable("Parts");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.Set", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Finished")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ForSale")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("GroupId")
                        .IsRequired()
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ImageUri")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PresentParts")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<string>("SetId")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("SetName")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TotalParts")
                        .HasColumnType("int");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Sets");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.UserProfile", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(36)
                        .HasColumnType("varchar(36)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime(6)");

                    b.Property<bool>("Finalized")
                        .HasColumnType("tinyint(1)");

                    b.Property<string>("GroupId")
                        .HasColumnType("varchar(36)");

                    b.Property<string>("ProfileImageUri")
                        .HasColumnType("longtext");

                    b.Property<string>("RebrickableApiKey")
                        .HasMaxLength(32)
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("Updated")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Username")
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("UserProfiles");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.Group", b =>
                {
                    b.HasOne("Bennetr.BrickInv.Api.Models.UserProfile", "Owner")
                        .WithMany()
                        .HasForeignKey("OwnerId");

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.GroupInvite", b =>
                {
                    b.HasOne("Bennetr.BrickInv.Api.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId");

                    b.HasOne("Bennetr.BrickInv.Api.Models.UserProfile", "Issuer")
                        .WithMany()
                        .HasForeignKey("IssuerId");

                    b.HasOne("Bennetr.BrickInv.Api.Models.UserProfile", "Recipient")
                        .WithMany()
                        .HasForeignKey("RecipientId");

                    b.Navigation("Group");

                    b.Navigation("Issuer");

                    b.Navigation("Recipient");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.Part", b =>
                {
                    b.HasOne("Bennetr.BrickInv.Api.Models.Set", "Set")
                        .WithMany()
                        .HasForeignKey("SetId");

                    b.Navigation("Set");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.Set", b =>
                {
                    b.HasOne("Bennetr.BrickInv.Api.Models.Group", "Group")
                        .WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.UserProfile", b =>
                {
                    b.HasOne("Bennetr.BrickInv.Api.Models.Group", null)
                        .WithMany("Members")
                        .HasForeignKey("GroupId");
                });

            modelBuilder.Entity("Bennetr.BrickInv.Api.Models.Group", b =>
                {
                    b.Navigation("Members");
                });
#pragma warning restore 612, 618
        }
    }
}
