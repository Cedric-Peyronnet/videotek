

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace videotek.db
{
    public class VideoTDbContextFactory : IDesignTimeDbContextFactory<VideoTDbContext>
    {
        public VideoTDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<VideoTDbContext>();
            optionsBuilder.UseSqlite("Data Source=database.db");

            return new VideoTDbContext(optionsBuilder.Options);
        }
    }
}
