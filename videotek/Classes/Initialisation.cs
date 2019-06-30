using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace videotek.Classes
{
    public class Initialisation
    {
        public async void RemplissageGenre()
        {


            var context = await db.VideoTDbContext.GetCurrent();

            List<Genre> genre = context.Genres.ToList();

            if (genre.Count == 0)
            {
                Genre remplissageGenre = new Genre()
                {
                    Libelle = "Science Fiction"
                };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Fantaisie" };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Drame" };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Comédie" };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Horreur" };
                context.Add(remplissageGenre);
                remplissageGenre = new Genre() { Libelle = "Live action" };
                context.Add(remplissageGenre);
                await context.SaveChangesAsync();
            }


            await context.SaveChangesAsync();
        }
        public async void remplissageSerieFilm()

        {

            var context = await db.VideoTDbContext.GetCurrent();
            List<Media> series = context.Medias.Where(m => m.Type == ETypeMedia.Serie).ToList();
            List<Media> film = context.Medias.Where(m => m.Type == ETypeMedia.Film).ToList();
            if (series.Count == 0 && series.Count == 0)
            {


                context.Medias.Add(new Media { Titre = "Game of thrones", Type = ETypeMedia.Serie, AgeMinimum = 18, DateSortie = new DateTime(2011, 04, 17), Commentaire = "Top série", LangueVO = ELangue.Anglais, LangueMedia = ELangue.Français, SousTitre = ELangue.Français, Duree = new TimeSpan(1, 20, 0), SupportPhysique = true, SupportNumerique = true, Note = 10, Vu = true, Description = "", });

                context.Medias.Add(new Media
                {
                    Titre = "Harry potter à l’école des sorcier",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 6,
                    DateSortie = new DateTime(2001, 12, 05),
                    Commentaire = "Très bon premier opus",
                    Note = 8,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 39, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Vu = true,
                    Description = "Un jeune sorcier en apprentissage"
                });

                context.Medias.Add(new Media
                {
                    Titre = "Harry potter et la chambre des secrets",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 6,
                    DateSortie = new DateTime(2002, 12, 04),
                    Commentaire = "Suite logique au premier",
                    Note = 8,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 54, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Vu = true,
                    Description = "Une chambre qui réserve bien des secrets à nos protagoniste"
                });

                context.Medias.Add(new Media
                {
                    Titre = "Harry potter et le prisionier d’Azkaban",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 15,
                    DateSortie = new DateTime(2004, 02, 06),
                    Commentaire = "",
                    Note = 0,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 22, 0),
                    SupportPhysique = false,
                    SupportNumerique = true,
                    Vu = false,
                    Description = "Sirius Black, séchappe mais qui est Sirius black pour nos sorcies ? "
                });

                context.Medias.Add(new Media
                {
                    Titre = "Harry Potter et la Coupe de feu",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 15,
                    DateSortie = new DateTime(2005, 11, 30),
                    Commentaire = "",
                    Note = 0,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 37, 0),
                    SupportPhysique = false,
                    SupportNumerique = true,
                    Vu = false,
                    Description = "De la compétition pour nos sorciers qui va donc pouvoir la remporter"
                });

                context.Medias.Add(new Media
                {
                    Titre = "Limitless",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(2011, 06, 8),
                    Commentaire = "Un de mes films préférés",
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(1, 45, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Note = 10,
                    Vu = true,
                    Description = "Une drogue de synthèse qui permet d'optimiser les performances cérébrales mais à quel prix ?",
                });


                context.Medias.Add(new Media
                {
                    Titre = "Toy Story",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 0,
                    DateSortie = new DateTime(1996, 03, 27),
                    Commentaire = "Un film pour les petits et les grands",
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(1, 17, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Note = 9,
                    Vu = true,
                    Description = "Que se passe-t-il quand les jouets prennent vie ?",
                });

                context.Medias.Add(new Media
                {
                    Titre = "Tu ne tueras point",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(2016, 11, 9),
                    Commentaire = "Super film avec une belle histoire",
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 20, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Note = 10,
                    Vu = true,
                    Description = "Un soldat américain n'a pas toujours besoin d'une arme pour faire son devoir",
                });

                context.Medias.Add(new Media
                {
                    Titre = "Gran Torino",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(2016, 11, 9),
                    Commentaire = "Du Clint Eastwood avec Clint Eastwood",
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(1, 51, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Note = 10,
                    Vu = true,
                    Description = "Un super film avec une belle morale",
                });

                context.Medias.Add(new Media
                {
                    Titre = "Star Wars II",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 3,
                    DateSortie = new DateTime(2002, 05, 17),
                    Commentaire = "Un des meilleurs Star Wars à mes yeux",
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 22, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Note = 9,
                    Vu = true,
                    Description = "L'entrée en scène du côté obscur et des grandes batailles",
                });

                context.Medias.Add(new Media
                {
                    Titre = "Le Seigneur des Anneaux: la Communauté de l'Anneaux",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(2001, 12, 19),
                    Commentaire = "Meilleurs films",
                    Note = 10,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 58, 0),
                    SupportPhysique = false,
                    SupportNumerique = true,
                    Vu = true,
                    Description = "Un jeune et timide `Hobbit', Frodon Sacquet, hérite d'un anneau magique. Bien loin d'être une simple babiole, il s'agit d'un instrument de pouvoir absolu qui permettrait à Sauron, le `Seigneur des ténèbres', de régner sur la `Terre du Milieu' et de réduire en esclavage ses peuples. Frodon doit parvenir jusqu'à la `Crevasse du Destin' pour détruire l'anneau.",
                });


                context.Medias.Add(new Media
                {
                    Titre = "Le Seigneur des Anneaux: les Deux Tours",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(2002, 12, 18),
                    Commentaire = "Meilleurs films 2",
                    Note = 10,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 59, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Vu = true,
                    Description = "Après la mort de Boromir et la disparition de Gandalf, la `Communauté' s'est scindée en trois. Perdus dans les collines d'`Emyn Muil', Frodon et Sam découvrent qu'ils sont suivis par Gollum, une créature versatile corrompue par l'anneau magique. Gollum promet de conduire les `Hobbits' jusqu'à la `Porte Noire' du `Mordor'. A travers la `Terre du Milieu', Aragorn, Legolas et Gimli font route vers le `Rohan', le royaume assiégé de Theoden.",
                });


                context.Medias.Add(new Media
                {
                    Titre = "Le Seigneur des Anneaux: le Retour du Roi",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(2003, 12, 17),
                    Commentaire = "Meilleurs films 3",
                    Note = 10,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(3, 21, 0),
                    SupportPhysique = true,
                    SupportNumerique = false,
                    Vu = true,
                    Description = "Les armées de Sauron ont attaqué `Minas Tirith', la capitale de `Gondor'. Jamais ce royaume autrefois puissant n'a eu autant besoin de son roi. Cependant, Aragorn trouvera-t-il en lui la volonté d'accomplir sa destinée ? Tandis que Gandalf s'efforce de soutenir les forces brisées de Gondor, Théoden exhorte les guerriers de Rohan à se joindre au combat. Cependant, malgré leur courage et leur loyauté, les forces des Hommes ne sont pas de taille à lutter contre les innombrables légions d'ennemis.",
                });


                context.Medias.Add(new Media
                {
                    Titre = "Kingdom of Heaven",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 0,
                    DateSortie = new DateTime(2005, 05, 04),
                    Commentaire = "Très bon film a voir",
                    Note = 8,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 25, 0),
                    SupportPhysique = true,
                    SupportNumerique = false,
                    Vu = true,
                    Description = "Quelque part dans le royaume de France en 1186, Balian, jeune forgeron accablé par l'existence, apprend qu'il est le fils de Godefroy d'Ibelin. Mais cette noble lignée le contraint de se rendre en Terre sainte pour défendre Jérusalem reconquise. Une fois en Palestine, il s'initie à l'art de la guerre et aux intrigues politiques, grâce à l'aide de Tiberias, le puissant conseiller militaire du roi.",
                });


                context.Medias.Add(new Media
                {
                    Titre = "La Ligne verte",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(1999, 12, 10),
                    Commentaire = "Top Film",
                    Note = 10,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(3, 09, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Vu = true,
                    Description = "Paul est le gardien-chef au pénitencier de Cold Moutain en Louisiane, au bloc E, surnommé La Ligne verte. Un jour, un nouveau détenu arrive, mais qui est ce nouveau prisonnier ? ",
                });

                context.Medias.Add(new Media
                {
                    Titre = "Ready Player One",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(2018, 03, 28),
                    Commentaire = "Top Film",
                    Note = 9,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 20, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Vu = true,
                    Description = " 2045. Le monde est au bord du chaos. Les êtres humains se réfugient dans un monde virtuel nommé l’OASIS, mais que réserve ce nouveau monde ?",
                });

                context.Medias.Add(new Media
                {
                    Titre = "Gladiator",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 14,
                    DateSortie = new DateTime(2000, 06, 20),
                    Commentaire = "Top Film",
                    Note = 9,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 35, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Vu = true,
                    Description = "Un général romain renommé va être capturé par un marchant d’esclaves, il devient gladiateur et prépare sa vengeance"
                });


                context.Medias.Add(new Media
                {
                    Titre = "Avengers : Infinity War",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 12,
                    DateSortie = new DateTime(2018, 04, 25),
                    Commentaire = "Top Film",
                    Note = 9,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 36, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Vu = true,
                    Description = "Les Avengers et leurs alliés devront être prêts à tout sacrifier pour neutraliser le redoutable Thanos avant que son attaque éclair ne conduise à la destruction de l’univers"
                });


                context.Medias.Add(new Media
                {
                    Titre = "Inception",
                    Type = ETypeMedia.Film,
                    AgeMinimum = 14,
                    DateSortie = new DateTime(2010, 07, 21),
                    Commentaire = "Top Film",
                    Note = 9,
                    LangueVO = ELangue.Anglais,
                    LangueMedia = ELangue.Français,
                    SousTitre = ELangue.Français,
                    Duree = new TimeSpan(2, 28, 0),
                    SupportPhysique = true,
                    SupportNumerique = true,
                    Vu = true,
                    Description = "Entre rêve et réalité, seriez-vous faire la différence ?"
                });

                await context.SaveChangesAsync();

                context.Add(new GenreMedia { IdGenre = 1, IdMedia = 1 });
                context.Add(new GenreMedia { IdGenre = 1, IdMedia = 2 });
                context.Add(new GenreMedia { IdGenre = 1, IdMedia = 3 });
                context.Add(new GenreMedia { IdGenre = 2, IdMedia = 4 });
                context.Add(new GenreMedia { IdGenre = 2, IdMedia = 5 });
                context.Add(new GenreMedia { IdGenre = 2, IdMedia = 6 });
                context.Add(new GenreMedia { IdGenre = 3, IdMedia = 7 });
                context.Add(new GenreMedia { IdGenre = 3, IdMedia = 8 });
                context.Add(new GenreMedia { IdGenre = 4, IdMedia = 9 });
                context.Add(new GenreMedia { IdGenre = 4, IdMedia = 10 });
                context.Add(new GenreMedia { IdGenre = 5, IdMedia = 11 });
                context.Add(new GenreMedia { IdGenre = 6, IdMedia = 12 });
                context.Add(new GenreMedia { IdGenre = 6, IdMedia = 13 });
                context.Add(new GenreMedia { IdGenre = 1, IdMedia = 14 });
                context.Add(new GenreMedia { IdGenre = 1, IdMedia = 15 });


                await context.SaveChangesAsync();

                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "L'hiver vient", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 1 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "La route royal", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 2 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Lord Snow", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 3 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Infirmes, Bâtards et Choses brisées", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 4 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Le Loup et le Lion", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 5 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Une couronne dorée", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 6 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Gagner ou mourir", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 7 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Frapper d'estoc", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 8 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Baelor", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 9 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "De feu et de sang", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 10 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Le Nord se souvient", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 1 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 1, Duree = new TimeSpan(0, 40, 0), Titre = "Les Contrées nocturnes", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 2 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Ce qui est mort ne saurait mourir", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 3 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Le Jardin des os", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 4 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Le Fantôme d'Harrenhal", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 5 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Les Anciens et les Nouveaux Dieux", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 6 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Un homme sans honneur", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 7 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Le Prince de Winterfell", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 8 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "La Néra", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 9 });
                context.Episodes.Add(new Episode { IdMedia = 1, NumSaison = 2, Duree = new TimeSpan(0, 40, 0), Titre = "Valar Morghulis", Description = "", DateDiffusion = new DateTime(2011, 04, 17), NumEpisode = 10 });
                await context.SaveChangesAsync();

                series = context.Medias.Where(m => m.Type == ETypeMedia.Serie).ToList();
                List<Episode> episodes = context.Episodes.ToList();
                foreach (Media serie in series)
                {
                    for (int i = 0; i < 20; i++)
                    {
                        context.EpisodesMedia.Add(new EpisodeMedia { IdMedia = serie.Id, IdEpisode = episodes[i].Id });
                    }
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
