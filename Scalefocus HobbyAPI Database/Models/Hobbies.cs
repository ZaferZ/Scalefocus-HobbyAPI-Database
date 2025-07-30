using System.ComponentModel.DataAnnotations;

namespace Scalefocus_HobbyAPI_Database.Models
{
    public class Hobbies
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public int Updated_at { get; set; }
    }
}
