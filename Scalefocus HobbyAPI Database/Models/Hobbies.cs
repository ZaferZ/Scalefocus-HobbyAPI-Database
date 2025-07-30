using System.ComponentModel.DataAnnotations;

namespace Scalefocus_HobbyAPI_Database.Models
{
    public class Hobbies
    {
        [Key]
        [Required]
        public int type_id { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public DateTime date { get; set; }
        [Required]
        public int updated_at { get; set; }
    }
}
