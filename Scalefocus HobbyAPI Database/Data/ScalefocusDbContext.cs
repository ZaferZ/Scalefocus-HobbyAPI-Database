using CommentAPI.Entities;
using Microsoft.EntityFrameworkCore;
using Scalefocus_HobbyAPI_Database.Models;

namespace Scalefocus_HobbyAPI_Database.Data
{
    public class ScalefocusDbContext(DbContextOptions<ScalefocusDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Hobbies> Hobbies { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<TaskEntity> Tasks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}
