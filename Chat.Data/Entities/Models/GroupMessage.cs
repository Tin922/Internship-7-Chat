namespace Chat.Data.Entities.Models
{
    public class GroupMessage
    {
        public int GroupMessageId { get; set; }
        public int SenderId { get; set; }
        public int GroupId { get; set; }
        public string Text { get; set; }
        public DateTime Timestamp { get; set; }

        public User Sender { get; set; }
        public Group Group { get; set; }
    }
}

