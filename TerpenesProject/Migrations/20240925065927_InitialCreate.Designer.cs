﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace TerpenesProject.Migrations
{
    [DbContext(typeof(TerpenesProjectDbContext))]
    [Migration("20240925065927_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.8");

            modelBuilder.Entity("AromaTerpene", b =>
                {
                    b.Property<int>("AromasId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TerpenesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AromasId", "TerpenesId");

                    b.HasIndex("TerpenesId");

                    b.ToTable("TerpeneAromas", (string)null);
                });

            modelBuilder.Entity("ConditionCondition", b =>
                {
                    b.Property<int>("AllConditionsId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FilteredConditionsId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AllConditionsId", "FilteredConditionsId");

                    b.HasIndex("FilteredConditionsId");

                    b.ToTable("ConditionCondition");
                });

            modelBuilder.Entity("TerpeneTerpene", b =>
                {
                    b.Property<int>("AllTerpenesId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("FilteredTerpenesId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AllTerpenesId", "FilteredTerpenesId");

                    b.HasIndex("FilteredTerpenesId");

                    b.ToTable("TerpeneTerpene");
                });

            modelBuilder.Entity("TerpenesProject.Models.Aroma", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Aromas");
                });

            modelBuilder.Entity("TerpenesProject.Models.Condition", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Conditions");
                });

            modelBuilder.Entity("TerpenesProject.Models.Terpene", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Aroma")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("ConditionId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("ConditionId");

                    b.ToTable("Terpenes");
                });

            modelBuilder.Entity("TerpenesProject.Models.TerpeneCondition", b =>
                {
                    b.Property<int>("TerpeneId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ConditionId")
                        .HasColumnType("INTEGER");

                    b.HasKey("TerpeneId", "ConditionId");

                    b.HasIndex("ConditionId");

                    b.ToTable("TerpenesConditions");
                });

            modelBuilder.Entity("AromaTerpene", b =>
                {
                    b.HasOne("TerpenesProject.Models.Aroma", null)
                        .WithMany()
                        .HasForeignKey("AromasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TerpenesProject.Models.Terpene", null)
                        .WithMany()
                        .HasForeignKey("TerpenesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ConditionCondition", b =>
                {
                    b.HasOne("TerpenesProject.Models.Condition", null)
                        .WithMany()
                        .HasForeignKey("AllConditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TerpenesProject.Models.Condition", null)
                        .WithMany()
                        .HasForeignKey("FilteredConditionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TerpeneTerpene", b =>
                {
                    b.HasOne("TerpenesProject.Models.Terpene", null)
                        .WithMany()
                        .HasForeignKey("AllTerpenesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TerpenesProject.Models.Terpene", null)
                        .WithMany()
                        .HasForeignKey("FilteredTerpenesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TerpenesProject.Models.Terpene", b =>
                {
                    b.HasOne("TerpenesProject.Models.Condition", null)
                        .WithMany("FilteredTerpenes")
                        .HasForeignKey("ConditionId");
                });

            modelBuilder.Entity("TerpenesProject.Models.TerpeneCondition", b =>
                {
                    b.HasOne("TerpenesProject.Models.Condition", "Condition")
                        .WithMany("TerpeneConditions")
                        .HasForeignKey("ConditionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TerpenesProject.Models.Terpene", "Terpene")
                        .WithMany("TerpeneConditions")
                        .HasForeignKey("TerpeneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Condition");

                    b.Navigation("Terpene");
                });

            modelBuilder.Entity("TerpenesProject.Models.Condition", b =>
                {
                    b.Navigation("FilteredTerpenes");

                    b.Navigation("TerpeneConditions");
                });

            modelBuilder.Entity("TerpenesProject.Models.Terpene", b =>
                {
                    b.Navigation("TerpeneConditions");
                });
#pragma warning restore 612, 618
        }
    }
}
