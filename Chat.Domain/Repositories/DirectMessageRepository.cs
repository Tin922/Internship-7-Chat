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

        public List<DirectMessage> GetDirectMessagesBetweenUsers(int senderId, int receiverId)
        {
            var sender = DbContext.Users.Find(senderId);
            var receiver = DbContext.Users.Find(receiverId);

            if (sender == null || receiver == null)
            {
                return new List<DirectMessage>();
            }

            var messages = DbContext.DirectMessages
                .Where(message =>
                    (message.SenderId == senderId && message.ReceiverId == receiverId) ||
                    (message.SenderId == receiverId && message.ReceiverId == senderId))
                .OrderBy(message => message.Timestamp)
                .ToList();

            return messages;
        }
        public List<User> GetUsersCommunicatedWith(int userId)
        {
            var senders = DbContext.DirectMessages
                .Where(message => message.SenderId == userId)
                .OrderByDescending(message => message.Timestamp)
                .Select(message => message.Receiver)
                .ToList();

            var receivers = DbContext.DirectMessages
                .Where(message => message.ReceiverId == userId)
                .OrderByDescending(message => message.Timestamp)
                .Select(message => message.Sender)
                .ToList();

            var usersCommunicatedWith = senders.Concat(receivers).Distinct().ToList();

            return usersCommunicatedWith;
        }



    }
}
