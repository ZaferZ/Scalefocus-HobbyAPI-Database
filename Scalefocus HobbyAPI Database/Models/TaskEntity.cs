using System.ComponentModel.DataAnnotations;

namespace Scalefocus_HobbyAPI_Database.Models
{
    public class TaskEntity
    {
        [Key]
        public int TaskId { get; set; }
        [Required]
        public string Title { get; set; }
        
        public string Description { get; set; }
        [Required]
        public bool IsCompleted { get; set; } = false;
        
        public DateTime ModifiedAt { get; set; }
     
    }
}
