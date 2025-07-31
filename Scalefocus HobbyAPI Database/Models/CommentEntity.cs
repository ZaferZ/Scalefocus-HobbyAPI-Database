
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Scalefocus_HobbyAPI_Database.Models
{
    public class CommentEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        [Required]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; }  
        [Required]
        public Guid UserId { get; set; }
        [Required]
        public int EventId { get; set; }
    }
}
