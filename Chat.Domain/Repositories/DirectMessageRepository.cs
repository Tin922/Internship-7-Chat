using Chat.Data.Entities.Models;
using Chat.Data.Entities;
using Chat.Domain.Enums;

namespace Chat.Domain.Repositories
{
   
    
        public class DirectMessageRepository : BaseRepository
        {
            public DirectMessageRepository(ChatDbContext dbContext) : base(dbContext)
            {
            }

            public ResponseResultType Add(DirectMessage DirectMessage)
            {
                DbContext.DirectMessages.Add(DirectMessage);

                return SaveChanges();
            }

        
        }
}
