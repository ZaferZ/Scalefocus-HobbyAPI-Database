namespace Scalefocus_HobbyAPI_Database.Models.Associations
{
    public class EventTasks
    {
        public int TasksId { get; set; }
        public int EventId { get; set; }


        // payload
        public TaskRole Role { get; set; } = 0;
        public DateTime AddedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }

    public enum TaskRole
    {
        NormalTask = 0,
        RequiredTask = 1,
        ImportantTask = 2
    }
}
