﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace videotek.Migrations
{
    public partial class a : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Episodes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    IdMedia = table.Column<int>(nullable: false),
                    NumSaison = table.Column<int>(nullable: false),
                    NumEpisode = table.Column<int>(nullable: false),
                    Duree = table.Column<TimeSpan>(nullable: false),
                    Titre = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DateDiffusion = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Medias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Duree = table.Column<TimeSpan>(nullable: false),
                    DateSortie = table.Column<DateTime>(nullable: false),
                    Titre = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Vu = table.Column<bool>(nullable: false),
                    Note = table.Column<int>(nullable: false),
                    Commentaire = table.Column<string>(nullable: true),
                    Type = table.Column<int>(nullable: false),
                    AgeMinimum = table.Column<int>(nullable: false),
                    SupportPhysique = table.Column<bool>(nullable: false),
                    SupportNumerique = table.Column<bool>(nullable: false),
                    Image = table.Column<string>(nullable: true),
                    LangueVO = table.Column<int>(nullable: false),
                    LangueMedia = table.Column<int>(nullable: false),
                    SousTitre = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Personne",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Civilite = table.Column<int>(nullable: false),
                    Nationalite = table.Column<string>(nullable: true),
                    DateNaissance = table.Column<DateTime>(nullable: false),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personne", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EpisodesMedia",
                columns: table => new
                {
                    IdMedia = table.Column<int>(nullable: false),
                    IdEpisode = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EpisodesMedia", x => new { x.IdMedia, x.IdEpisode });
                    table.ForeignKey(
                        name: "FK_EpisodesMedia_Episodes_IdEpisode",
                        column: x => x.IdEpisode,
                        principalTable: "Episodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EpisodesMedia_Medias_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "GenreMedias",
                columns: table => new
                {
                    IdGenre = table.Column<int>(nullable: false),
                    IdMedia = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreMedias", x => new { x.IdMedia, x.IdGenre });
                    table.ForeignKey(
                        name: "FK_GenreMedias_Genres_IdGenre",
                        column: x => x.IdGenre,
                        principalTable: "Genres",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GenreMedias_Medias_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PersonneMedia",
                columns: table => new
                {
                    IdPersonne = table.Column<int>(nullable: false),
                    IdMedia = table.Column<int>(nullable: false),
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Fonction = table.Column<int>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    Photo = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonneMedia", x => new { x.IdPersonne, x.IdMedia });
                    table.UniqueConstraint("AK_PersonneMedia_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PersonneMedia_Medias_IdMedia",
                        column: x => x.IdMedia,
                        principalTable: "Medias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonneMedia_Personne_IdPersonne",
                        column: x => x.IdPersonne,
                        principalTable: "Personne",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EpisodesMedia_IdEpisode",
                table: "EpisodesMedia",
                column: "IdEpisode");

            migrationBuilder.CreateIndex(
                name: "IX_GenreMedias_IdGenre",
                table: "GenreMedias",
                column: "IdGenre");

            migrationBuilder.CreateIndex(
                name: "IX_PersonneMedia_IdMedia",
                table: "PersonneMedia",
                column: "IdMedia");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EpisodesMedia");

            migrationBuilder.DropTable(
                name: "GenreMedias");

            migrationBuilder.DropTable(
                name: "PersonneMedia");

            migrationBuilder.DropTable(
                name: "Episodes");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Medias");

            migrationBuilder.DropTable(
                name: "Personne");
        }
    }
}
