using Microsoft.EntityFrameworkCore;

namespace CameraTrackerApp.Models
{
    public class Context: DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {
        }
        public DbSet<Camera> Camera { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Confirmation> Confirmation { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server= localhost; Database= Pfff; Integrated Security=True;");
        }
    }
}
