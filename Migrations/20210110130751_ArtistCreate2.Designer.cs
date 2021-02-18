﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Zbranca_Iulian_ProiectMedii.Data;

namespace Zbranca_Iulian_ProiectMedii.Migrations
{
    [DbContext(typeof(Zbranca_Iulian_ProiectMediiContext))]
    [Migration("20210110130751_ArtistCreate2")]
    partial class ArtistCreate2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Zbranca_Iulian_ProiectMedii.Models.Album", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DataAparitiei")
                        .HasColumnType("datetime2");

                    b.Property<int>("LabelID")
                        .HasColumnType("int");

                    b.Property<decimal>("Pret")
                        .HasColumnType("decimal(6, 2)");

                    b.Property<string>("Titlu")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("ArtistID");

                    b.HasIndex("LabelID");

                    b.ToTable("Album");
                });

            modelBuilder.Entity("Zbranca_Iulian_ProiectMedii.Models.Artist", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeArtist")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Artist");
                });

            modelBuilder.Entity("Zbranca_Iulian_ProiectMedii.Models.Label", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("NumeLabel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Label");
                });

            modelBuilder.Entity("Zbranca_Iulian_ProiectMedii.Models.Album", b =>
                {
                    b.HasOne("Zbranca_Iulian_ProiectMedii.Models.Artist", null)
                        .WithMany("Albume")
                        .HasForeignKey("ArtistID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Zbranca_Iulian_ProiectMedii.Models.Label", "Label")
                        .WithMany("Albume")
                        .HasForeignKey("LabelID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
