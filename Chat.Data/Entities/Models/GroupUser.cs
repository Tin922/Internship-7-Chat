﻿namespace Chat.Data.Entities.Models
{
    public class GroupUser
    {
        public int GroupUserId { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; } 
    }
}
