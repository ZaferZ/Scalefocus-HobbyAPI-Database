namespace Scalefocus_HobbyAPI_Database.Models.Associations
{
    public class TaskUser
    {
        public int TasksId { get; set; }
        public Guid UserId { get; set; }
        public bool IsCompleted { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedAt { get; set; } = DateTime.UtcNow;
        public Guid? ModifiedBy { get; set; } = null;


    }
}
