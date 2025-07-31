using System.ComponentModel.DataAnnotations;

namespace Scalefocus_HobbyAPI_Database.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Username { get; set; } = string.Empty;

        [Required]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        public string LastName { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        public string PasswordHash { get; set; } = string.Empty;

        public ICollection<Event> Events{ get; set; } = new List<Event>();
        public ICollection<Hobbies> Hobbies { get; set; } = new List<Hobbies>();

        public ICollection<TaskEntity> Tasks { get; set; } = new List<TaskEntity>();
    }
}
                 