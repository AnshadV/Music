﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Music.Models;

namespace Music.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20220531092032_Revision")]
    partial class Revision
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Music.Models.ArtistModel", b =>
                {
                    b.Property<int>("ArtistId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("DOB")
                        .HasColumnType("date");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("ArtistId");

                    b.ToTable("Artists");
                });

            modelBuilder.Entity("Music.Models.SongModel", b =>
                {
                    b.Property<int>("SongId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArtistId")
                        .HasColumnType("int");

                    b.Property<byte[]>("CoverImage")
                        .HasColumnType("varbinary(MAX)");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("date");

                    b.Property<string>("SongName")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("SongId");

                    b.HasIndex("ArtistId");

                    b.ToTable("SongModel");
                });

            modelBuilder.Entity("Music.Models.SongModel", b =>
                {
                    b.HasOne("Music.Models.ArtistModel", "ArtistModel")
                        .WithMany("Songs")
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArtistModel");
                });

            modelBuilder.Entity("Music.Models.ArtistModel", b =>
                {
                    b.Navigation("Songs");
                });
#pragma warning restore 612, 618
        }
    }
}
