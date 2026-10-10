using API_proj.Models;
using Microsoft.EntityFrameworkCore;

namespace API_proj.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasOne<User>().WithMany()
                .HasForeignKey(e => e.OrganiserID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Event>()
                .HasOne<Category>().WithMany()
                .HasForeignKey(e => e.CategoryID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Category>()
                .HasOne<Event>().WithMany()
                .HasForeignKey(c => c.EventID)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}