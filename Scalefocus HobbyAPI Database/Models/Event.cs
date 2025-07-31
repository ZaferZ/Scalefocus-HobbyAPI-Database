using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


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
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        [ForeignKey("OwnerId")]
        [Required]
        public Guid OwnerId { get; set; }
        [ForeignKey("HobbyId")]
        [Required]
        public int HobbyId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
        [Required]
        public string Location { get; set; } = string.Empty;
        [Required]
        public int Capacity { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("CreatedBy")]
        [Required]
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        [ForeignKey("ModifiedBy")]
        public Guid? ModifiedBy { get; set; }
        public ICollection<Guid>? ParticipantIds { get; set; } = new List<Guid>();
        [Required]
        public EventStatus Status { get; set; } = EventStatus.Scheduled;


        public ICollection<User>? Participants { get; set; } = new List<User>();

        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();

    }
}


