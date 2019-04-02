using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;
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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.EnableSensitiveDataLogging();
            optionsBuilder.UseSqlite($"Filename={DatabasePath}", x => x.SuppressForeignKeyEnforcement());
        }
    }
}
