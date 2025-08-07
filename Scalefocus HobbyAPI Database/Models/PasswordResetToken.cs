using System.ComponentModel.DataAnnotations;

namespace Scalefocus_HobbyAPI_Database.Models
{
    public class PasswordResetToken
    {
        [Key]
        public int Id { get; set; }
        public string PasswordResetTokenValue { get; set; }
        public Guid UserId { get; set; }
        
        public DateTime? ExpiryTime { get; set; }

        public User User { get; set; } = null!;
    }
}
