using DotNetCoreMVCDemo.DomainLayer.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetCoreMVCDemo.InfrastructureLayer.Data
{
    public class DotNetCoreMVCDemoContext : DbContext
    {
        public DotNetCoreMVCDemoContext(DbContextOptions<DotNetCoreMVCDemoContext> options)
            : base(options)
        {
        }
        
        public DbSet<Movie> Movies { get; set; } = default!;
        public DbSet<Tickets> Tickets { get; set; } = default!;

        // SP: To set the One to Many relationship i table movie and ticket
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tickets>()
                .HasOne<Movie>(s => s.Movie)
                .WithMany(g => g.Tickets)
                .HasForeignKey(s => s.MovieId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder
            .Entity<Tickets>()
            .Property(d => d.Gender)
            .HasConversion(new EnumToStringConverter<Gender>());
        }
    }
}
