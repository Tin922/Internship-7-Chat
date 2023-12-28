namespace Chat.Data.Entities.Models
{
    public class Group
    {
        
        
            public int GroupId { get; set; }
            public string Name { get; set; }
           
            public ICollection<GroupUser> GroupUsers { get; set; } = new List<GroupUser>();
            public ICollection<GroupMessage> GroupMessages { get; set; } = new List<GroupMessage>();
        
    }
}
