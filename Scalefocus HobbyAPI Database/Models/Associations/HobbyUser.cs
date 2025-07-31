namespace Scalefocus_HobbyAPI_Database.Models.Associations
{
    public class HobbyUser
    {
        public int HobbiesId { get; set; }
        public Guid UserId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    }
}
