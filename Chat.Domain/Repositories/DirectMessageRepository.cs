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
        public ResponseResultType Delete(int id)
        {
            var MessageToDelete = DbContext.DirectMessages.Find(id);
            if (MessageToDelete is null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.DirectMessages.Remove(MessageToDelete);

            return SaveChanges();
        }


    }
}
