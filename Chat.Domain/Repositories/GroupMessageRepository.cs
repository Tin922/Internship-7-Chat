﻿using Chat.Data.Entities.Models;
using Chat.Data.Entities;
using Chat.Domain.Enums;

namespace Chat.Domain.Repositories
{
    public class GroupMessageRepository : BaseRepository
    {
        public GroupMessageRepository(ChatDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(GroupMessage GroupMessage)
        {
            DbContext.GroupMessages.Add(GroupMessage);

            return SaveChanges();
        }


    }
}
