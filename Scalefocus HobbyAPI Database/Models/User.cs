using System.ComponentModel.DataAnnotations;

namespace Scalefocus_HobbyAPI_Database.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get;set; }

        [Required]
        public string Email { get; set; }

    }
}
