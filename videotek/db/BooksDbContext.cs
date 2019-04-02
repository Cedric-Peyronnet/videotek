using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
using videotek.Classes;
using static System.Environment;

namespace videotek.db
{
    public class BooksDbContext : DbContext
    {
        private static BooksDbContext _context = null;
        public static async Task<BooksDbContext> GetCurrent()
        {
            if(_context == null)
            {
                _context = new BooksDbContext(
                    Path.Combine(Environment.GetFolderPath(SpecialFolder.LocalApplicationData), "database.db"));
                await _context.Database.MigrateAsync();
            }
            return _context;
        }
       private BooksDbContext(string databasePath) : base ()
        {
            DatabasePath = databasePath;
        }
        public string DatabasePath { get; }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<GenreMedia> GenreMedias { get; set; }
     //   public DbSet<Langue> Langues { get; set; }
        public DbSet<Media> Medias { get; set; }
     //   public DbSet<TypeMedia> Medias { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        }
    }
}
