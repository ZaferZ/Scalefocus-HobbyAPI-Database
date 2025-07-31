namespace Scalefocus_HobbyAPI_Database.Models.Associations
{
    public class EventParticipants
    {
        public int EventId { get; set; }
        public Guid UserId { get; set; }


        // payload
        public ParticipantRole Role { get; set; } = 0;
        public DateTime JoinedAt { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public int? ModifiedBy { get; set; }
    }

    public enum ParticipantRole
    {
        Attendee = 0,
        Organizer = 1,
        Speaker = 2,
        Volunteer = 3
    }
}
