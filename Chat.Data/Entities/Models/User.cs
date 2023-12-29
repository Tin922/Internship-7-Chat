
namespace Chat.Data.Entities.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public bool IsAdmin { get; set; }
       

        public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
        public ICollection<DirectMessage> SentDirectMessages { get; set; } = new List<DirectMessage>();
        public ICollection<DirectMessage> ReceivedDirectMessages { get; set; } = new List<DirectMessage>();
        public ICollection<Group> Groups { get; set; } = new List<Group>();
        public ICollection<GroupMessage> SentGroupMessages { get; set; } = new List<GroupMessage>();
    }
}

