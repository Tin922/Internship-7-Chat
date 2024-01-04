using Chat.Data.Entities.Models;
using Chat.Data.Entities;
using Chat.Domain.Enums;
using Microsoft.EntityFrameworkCore;

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
        public ResponseResultType Delete(int id)
        {
            var MessageToDelete = DbContext.GroupMessages.Find(id);
            if (MessageToDelete is null)
            {
                return ResponseResultType.NotFound;
            }

            DbContext.GroupMessages.Remove(MessageToDelete);

            return SaveChanges();
        }
        public ICollection<GroupMessage> GetAll() => DbContext.GroupMessages.ToList();

        public List<GroupMessage> GetChannelMessages(int groupId)
        {
            var messages = DbContext.GroupMessages
                .Include(gm => gm.Sender)
                .Where(gm => gm.GroupId == groupId)
                .OrderBy(gm => gm.Timestamp)
                .ToList();

            return messages;
        }


        public ResponseResultType AddMessageToChannel(int groupId, int senderUserId, string text)
        {
            var group = DbContext.Groups.Find(groupId);
            var sender = DbContext.Users.Find(senderUserId);

            if (group == null || sender == null)
            {
                return ResponseResultType.NotFound;
            }

            var groupMessage = new GroupMessage
            {
                GroupId = groupId,
                SenderId = senderUserId,
                Timestamp = DateTime.UtcNow,
                Text = text
            };

            DbContext.GroupMessages.Add(groupMessage);

            return SaveChanges();
        }

    }
}
