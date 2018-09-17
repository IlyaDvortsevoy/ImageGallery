using System.Data.Entity;

namespace SimpleWebApp.Models
{
    public class ImageContext : DbContext
    {
        public ImageContext()
            : base("DBConnection")
        {
        }

        public DbSet<DbImage> DbImages { get; set; }
    }
}