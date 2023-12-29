using Chat.Data.Entities;
using Chat.Data.Entities.Models;
using Chat.Domain.Enums;

namespace Chat.Domain.Repositories
{
    public class GroupUserRepository : BaseRepository
    {
        public GroupUserRepository(ChatDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(GroupUser groupUser)
        {
            DbContext.GroupUsers.Add(groupUser);

            return SaveChanges();
        }

    }

}
