﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using videotek.db;

namespace videotek.Migrations
{
    [DbContext(typeof(VideoTDbContext))]
    partial class VideoTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.3-servicing-35854");

            modelBuilder.Entity("videotek.Classes.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Libelle");

                    b.HasKey("Id");

                    b.ToTable("Genres");
                });

            modelBuilder.Entity("videotek.Classes.GenreMedia", b =>
                {
                    b.Property<int>("IdGenre");

                    b.Property<int>("IdMedia");

                    b.HasKey("IdGenre", "IdMedia");

                    b.HasIndex("IdMedia");

                    b.ToTable("GenreMedias");
                });

            modelBuilder.Entity("videotek.Classes.Media", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AgeMinimum");

                    b.Property<string>("Commentaire");

                    b.Property<DateTime>("DateSortie");

                    b.Property<string>("Description");

                    b.Property<TimeSpan>("Duree");

                    b.Property<string>("Image");

                    b.Property<int>("LangueMedia");

                    b.Property<int>("LangueVO");

                    b.Property<int>("Note");

                    b.Property<int>("SousTitre");

                    b.Property<bool>("SupportNumerique");

                    b.Property<bool>("SupportPhysique");

                    b.Property<string>("Titre");

                    b.Property<int>("Type");

                    b.Property<bool>("Vu");

                    b.HasKey("Id");

                    b.ToTable("Medias");
                });

            modelBuilder.Entity("videotek.Classes.Personne", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Civilite");

                    b.Property<DateTime>("DateNaissance");

                    b.Property<string>("Nationalite");

                    b.Property<string>("Nom");

                    b.Property<string>("Photo");

                    b.Property<string>("Prenom");

                    b.HasKey("Id");

                    b.ToTable("Personne");
                });

            modelBuilder.Entity("videotek.Classes.PersonneMedia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Fonction");

                    b.Property<int>("IdMedia");

                    b.Property<int>("IdPersonne");

                    b.Property<string>("Photo");

                    b.Property<string>("Role");

                    b.HasKey("Id");

                    b.HasIndex("IdMedia");

                    b.HasIndex("IdPersonne");

                    b.ToTable("PersonneMedia");
                });

            modelBuilder.Entity("videotek.Classes.GenreMedia", b =>
                {
                    b.HasOne("videotek.Classes.Genre", "Genre")
                        .WithMany("Media")
                        .HasForeignKey("IdGenre")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("videotek.Classes.Media", "Media")
                        .WithMany("Genre")
                        .HasForeignKey("IdMedia")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("videotek.Classes.PersonneMedia", b =>
                {
                    b.HasOne("videotek.Classes.Media", "Media")
                        .WithMany("Personne")
                        .HasForeignKey("IdMedia")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("videotek.Classes.Personne", "Personne")
                        .WithMany("Media")
                        .HasForeignKey("IdPersonne")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
