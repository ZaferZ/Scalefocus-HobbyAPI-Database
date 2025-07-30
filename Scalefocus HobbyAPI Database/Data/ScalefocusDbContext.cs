
using Microsoft.EntityFrameworkCore;
using Scalefocus_HobbyAPI_Database.Models;
using Scalefocus_HobbyAPI_Database.Models.Associations;

namespace Scalefocus_HobbyAPI_Database.Data
{
    public class ScalefocusDbContext(DbContextOptions<ScalefocusDbContext> options) : DbContext(options)
    {
        public DbSet<Event> Events { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Hobbies> Hobbies { get; set; }

        public DbSet<CommentEntity> Comments { get; set; }

        public DbSet<EventParticipants> EventParticipants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasKey(e => e.Id);

            modelBuilder.Entity<User>()
                .HasKey(e => e.Id);
            modelBuilder.Entity<Hobbies>()
                .HasKey(h => h.Id);
            modelBuilder.Entity<CommentEntity>()
                .HasKey(c => c.Id);

            // Many-to-many: Event <-> User via EventParticipants
            modelBuilder.Entity<EventParticipants>()
                .HasKey(ep => new { ep.EventId, ep.UserId });

            modelBuilder.Entity<EventParticipants>()
                .HasOne(ep => ep.Event)
                .WithMany()
                .HasForeignKey(ep => ep.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<EventParticipants>()
                .HasOne(ep => ep.User)
                .WithMany()
                .HasForeignKey(ep => ep.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Event.OwnerId references User.Id (Owner relationship)
            modelBuilder.Entity<Event>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);

            // Event.CreatedBy references User.Id (CreatedBy relationship)
            modelBuilder.Entity<Event>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.CreatedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Event.ModifiedBy references User.Id (ModifiedBy relationship, nullable)
            modelBuilder.Entity<Event>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(e => e.ModifiedBy)
                .OnDelete(DeleteBehavior.Restrict);

            // Seed Users
            var user1Id = new Guid("3bae1d94-7392-477e-922e-e656a8597661");
            var user2Id = new Guid("7e61f925-b7d6-4e69-bbc2-a6695e2e424f");

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = user1Id,
                    Username = "alice123",
                    FirstName = "Alice",
                    LastName = "Smith",
                    Email = "alice.smith@example.com",
                    PasswordHash = "hash1"
                },
                new User
                {
                    Id = user2Id,
                    Username = "bob456",
                    FirstName = "Bob",
                    LastName = "Johnson",
                    Email = "bob.johnson@example.com",
                    PasswordHash = "hash2"
                }
            );

            // Seed Events
            modelBuilder.Entity<Event>().HasData(
                new
                {
                    Id = 1,
                    Title = "Chess Tournament",
                    Description = "A friendly chess tournament.",
                    OwnerId = user1Id,
                    HobbyId = 1,
                    StartDate = new DateTime(2024, 7, 1, 10, 0, 0),
                    EndDate = new DateTime(2024, 7, 1, 18, 0, 0),
                    Location = "Community Center",
                    Capacity = 20,
                    CreatedAt = new DateTime(2024, 6, 1, 9, 0, 0),
                    CreatedBy = user1Id,
                    ModifiedAt = (DateTime?)null,
                    ModifiedBy = (Guid?)null,
                    Status = EventStatus.Scheduled
                },
                new
                {
                    Id = 2,
                    Title = "Painting Workshop",
                    Description = "Learn to paint with watercolors.",
                    OwnerId = user2Id,
                    HobbyId = 2,
                    StartDate = new DateTime(2024, 8, 15, 14, 0, 0),
                    EndDate = new DateTime(2024, 8, 15, 17, 0, 0),
                    Location = "Art Studio",
                    Capacity = 15,
                    CreatedAt = new DateTime(2024, 7, 10, 10, 0, 0),
                    CreatedBy = user2Id,
                    ModifiedAt = (DateTime?)null,
                    ModifiedBy = (Guid?)null,
                    Status = EventStatus.Scheduled
                }
            );
            // Seed Hobbies
            modelBuilder.Entity<Hobbies>().HasData(
                new Hobbies
                {
                    Id = 1,
                    Title = "Chess",
                    Date = new DateTime(2024, 1, 1),
                    Updated_at = 20240101
                },
                new Hobbies
                {
                    Id = 2,
                    Title = "Painting",
                    Date = new DateTime(2024, 2, 1),
                    Updated_at = 20240201
                }
            );
            // Seed Comments
            modelBuilder.Entity<CommentEntity>().HasData(
                new
                {
                    Id = 1,
                    EventId = 1,
                    UserId = user1Id,
                    Content = "Looking forward to this event!",
                    CreatedAt = new DateTime(2024, 6, 2, 10, 0, 0)
                },
                new
                {
                    Id = 2,
                    EventId = 1,
                    UserId = user2Id,
                    Content = "Count me in!",
                    CreatedAt = new DateTime(2024, 6, 3, 11, 0, 0)
                },
                new
                {
                    Id = 3,
                    EventId = 2,
                    UserId = user2Id,
                    Content = "Excited to learn painting.",
                    CreatedAt = new DateTime(2024, 7, 12, 12, 0, 0)
                }
            );

            // Seed EventParticipants
            modelBuilder.Entity<EventParticipants>().HasData(
                new
                {
                    EventId = 1,
                    UserId = user1Id,
                    Role = ParticipantRole.Organizer,
                    JoinedAt = new DateTime(2024, 6, 1, 9, 0, 0),
                    ModifiedAt = (DateTime?)null,
                    ModifiedBy = (int?)null
                },
                new
                {
                    EventId = 1,
                    UserId = user2Id,
                    Role = ParticipantRole.Attendee,
                    JoinedAt = new DateTime(2024, 6, 3, 11, 0, 0),
                    ModifiedAt = (DateTime?)null,
                    ModifiedBy = (int?)null
                },
                new
                {
                    EventId = 2,
                    UserId = user2Id,
                    Role = ParticipantRole.Organizer,
                    JoinedAt = new DateTime(2024, 7, 10, 10, 0, 0),
                    ModifiedAt = (DateTime?)null,
                    ModifiedBy = (int?)null
                }
            );
        }
    }

}
