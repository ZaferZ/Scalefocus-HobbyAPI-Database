using System.ComponentModel.DataAnnotations;

namespace Scalefocus_HobbyAPI_Database.Models
{
    public class TaskEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
        [Required]
        public bool IsCompleted { get; set; } = false;

        public DateTime ModifiedAt { get; set; }

        public ICollection<Event> Events { get; set; } = new List<Event>();
        public ICollection<User> Users { get; set; } = new List<User>();
    }
}
