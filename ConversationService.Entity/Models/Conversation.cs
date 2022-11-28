using System;

namespace ConversationService.Entity.Models
{
    public class Conversation
    {
        public int Id { get; set; }
        public string Messages { get; set; }
        public int ClientId { get; set; }
        public DateTime StartMeetingDate { get; set; }
        public DateTime? EndMeetingDate { get; set; }
        public string MeetingTopic { get; set; }
        public string ConversationStatus { get; set; }
        public string ClosedBy { get; set; }
        public int MeetingId { get; set; }
    }
}