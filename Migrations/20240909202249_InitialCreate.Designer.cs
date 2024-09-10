﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Tuna_Piano;

#nullable disable

namespace Tuna_Piano.Migrations
{
    [DbContext(typeof(TunaPianoDbContext))]
    [Migration("20240909202249_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.Property<int>("GenresId")
                        .HasColumnType("integer");

                    b.Property<int>("SongsId")
                        .HasColumnType("integer");

                    b.HasKey("GenresId", "SongsId");

                    b.HasIndex("SongsId");

                    b.ToTable("GenreSong");
                });

            modelBuilder.Entity("Tuna_Piano.Models.Artist", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("integer");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Artists");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Age = 60,
                            Bio = "Legendary Rock Band",
                            Name = "The Beatles"
                        },
                        new
                        {
                            Id = 2,
                            Age = 50,
                            Bio = "Classical Music Composer",
                            Name = "Ludwig van Beethoven"
                        },
                        new
                        {
                            Id = 3,
                            Age = 20,
                            Bio = "Rock Band",
                            Name = "Queen"
                        },
                        new
                        {
                            Id = 4,
                            Age = 33,
                            Bio = "Country Pop Singer-Songwriter",
                            Name = "Taylor Swift"
                        },
                        new
                        {
                            Id = 5,
                            Age = 82,
                            Bio = "Folk Rock Singer-Songwriter",
                            Name = "Bob Dylan"
                        });
                });

            modelBuilder.Entity("Tuna_Piano.Models.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Genres");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Rock"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Classical"
                        },
                        new
                        {
                            Id = 3,
                            Description = "Pop"
                        },
                        new
                        {
                            Id = 4,
                            Description = "Country"
                        },
                        new
                        {
                            Id = 5,
                            Description = "Jazz"
                        });
                });

            modelBuilder.Entity("Tuna_Piano.Models.Song", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Album")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ArtistId")
                        .HasColumnType("integer");

                    b.Property<int>("Length")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("ArtistId");

                    b.ToTable("Songs");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Album = "Hey Jude",
                            ArtistId = 1,
                            Length = 228,
                            Title = "Hey Jude"
                        },
                        new
                        {
                            Id = 2,
                            Album = "For Elise",
                            ArtistId = 2,
                            Length = 580,
                            Title = "Moonlight Sonata"
                        },
                        new
                        {
                            Id = 3,
                            Album = "A Night at the Opera",
                            ArtistId = 3,
                            Length = 595,
                            Title = "Bohemian Rhapsody"
                        },
                        new
                        {
                            Id = 4,
                            Album = "1989",
                            ArtistId = 4,
                            Length = 200,
                            Title = "Shake It Off"
                        },
                        new
                        {
                            Id = 5,
                            Album = "The Freewheelin' Bob Dylan",
                            ArtistId = 5,
                            Length = 320,
                            Title = "Blowin' in the Wind"
                        });
                });

            modelBuilder.Entity("GenreSong", b =>
                {
                    b.HasOne("Tuna_Piano.Models.Genre", null)
                        .WithMany()
                        .HasForeignKey("GenresId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Tuna_Piano.Models.Song", null)
                        .WithMany()
                        .HasForeignKey("SongsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Tuna_Piano.Models.Song", b =>
                {
                    b.HasOne("Tuna_Piano.Models.Artist", "Artist")
                        .WithMany()
                        .HasForeignKey("ArtistId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Artist");
                });
#pragma warning restore 612, 618
        }
    }
}
