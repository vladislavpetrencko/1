using Microsoft.EntityFrameworkCore;

namespace WebApi.Models
    
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Cmena> Cmenas { get; set; }
        public DbSet<Brigada> Brigadas { get; set; }
        public DbSet<Master> Masters { get; set; }
        public DbSet<Opove> Opoves { get; set; }
        public DbSet<Zadani> Zadanis { get; set; }



        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options) { Database.EnsureCreated(); }
    }
}
