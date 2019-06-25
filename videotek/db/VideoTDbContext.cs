using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using videotek.Classes;
using static System.Environment;

namespace videotek.db
{
    public class VideoTDbContext : DbContext
    {
        private static VideoTDbContext _context = null;
        public static async Task<VideoTDbContext> GetCurrent()
        {
            if(_context == null)
            {
                _context = new VideoTDbContext(
                    Path.Combine(Environment.GetFolderPath(SpecialFolder.MyDocuments), "database.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }
        internal VideoTDbContext(DbContextOptions options) : base(options) { }
        private VideoTDbContext(string databasePath) : base ()
        {
            DatabasePath = databasePath;
        }
        public string DatabasePath { get; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMedia> GenreMedias { get; set; }
       //  public DbSet<Langue> Langues { get; set; }
        public DbSet<Media> Medias { get; set; }
      //  public DbSet<TypeMedia> Medias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<GenreMedia>().HasKey((gm) => new { gm.IdGenre, gm.IdMedia });

            //base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Media>()
                                .HasKey(m => new { m.Id });

            modelBuilder.Entity<Genre>()
                                .HasKey(g => new { g.Id });

            modelBuilder.Entity<GenreMedia>().HasKey(gm => new { gm.IdMedia, gm.IdGenre });

            modelBuilder.Entity<GenreMedia>()
                                .HasOne<Media>(gm => gm.Media)
                                .WithMany(m => m.Genre)
                                .HasForeignKey(gm => gm.IdMedia);

            modelBuilder.Entity<GenreMedia>()
                                .HasOne<Genre>(gm => gm.Genre)
                                .WithMany(g => g.Media)
                                .HasForeignKey(gm => gm.IdGenre);


            modelBuilder.Entity<Personne>()
                                .HasKey(p => new { p.Id });

            modelBuilder.Entity<PersonneMedia>().HasKey(pm => new { pm.IdPersonne, pm.IdMedia });

            modelBuilder.Entity<PersonneMedia>()
                                .HasOne<Media>(pm => pm.Media)
                                .WithMany(m => m.Personne)
                                .HasForeignKey(pm => pm.IdMedia);

            modelBuilder.Entity<PersonneMedia>()
                                .HasOne<Personne>(pm => pm.Personne)
                                .WithMany(p => p.Media)
                                .HasForeignKey(pm => pm.IdPersonne);

            modelBuilder.Entity<Episode>()
                                .HasKey(e => new { e.Id });
        }
    }
}
