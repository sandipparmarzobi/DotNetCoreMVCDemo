using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DotNetCoreMVCDemo.Models;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore.Storage;
using System.Diagnostics.Metrics;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DotNetCoreMVCDemo.Data
{
    public class DotNetCoreMVCDemoContext : DbContext
    {
        public DotNetCoreMVCDemoContext (DbContextOptions<DotNetCoreMVCDemoContext> options)
            : base(options)
        {
        }

        public DbSet<DotNetCoreMVCDemo.Models.Movie> Movie { get; set; } = default!;
        public DbSet<DotNetCoreMVCDemo.Models.Tickets> Tickets { get; set; } = default!;

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
