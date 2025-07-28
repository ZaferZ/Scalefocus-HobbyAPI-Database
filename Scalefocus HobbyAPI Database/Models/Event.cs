using System.ComponentModel.DataAnnotations;


namespace Scalefocus_HobbyAPI_Database.Models
{
        public enum EventStatus
        {
            Scheduled = 0,
            Cancelled = 1,
            Completed = 2
        }
        public class Event
        {
            [Key]
            public Guid Id { get; set; }
            [Required]
            public string? Title { get; set; }
            [Required]
            public string? Description { get; set; }
            [Required]
            public Guid OwnerId { get; set; }
            [Required]
            public Guid HobbyId { get; set; }
            [Required]
            public DateTime StartDate { get; set; }
            [Required]
            public DateTime EndDate { get; set; }
            [Required]
            public string? Location { get; set; }
            [Required]
            public int Capacity { get; set; }
            [Required]
            public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
            [Required]
            public Guid CreatedBy { get; set; }
            public DateTime? ModifiedAt { get; set; }
            public Guid? ModifiedBy { get; set; }
            public List<Guid>? ParticipantIds { get; set; } = new();
            [Required]
            public EventStatus Status { get; set; } = EventStatus.Scheduled;

        }
    }


