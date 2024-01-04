using Chat.Data.Entities;
using Chat.Data.Entities.Models;
using Chat.Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Chat.Domain.Repositories
{

    public class GroupRepository : BaseRepository
    {
        public GroupRepository(ChatDbContext dbContext) : base(dbContext)
        {
        }

        public ResponseResultType Add(Group group)
        {
            DbContext.Groups.Add(group);

            return SaveChanges();
        }
        public ICollection<Group> GetAll() => DbContext.Groups.ToList();
        public void AttachUser(User user)
        {
            if (DbContext.Entry(user).State == EntityState.Detached)
            {
                DbContext.Users.Attach(user);
                DbContext.Entry(user).State = EntityState.Modified;
            }
        }
        public GroupUser GetById(int id)
        {
            return DbContext.GroupUsers.Find(id);
        }
        public ICollection<Group> GetChannelsNotJoinedByUser(int userId)
        {
            return DbContext.Groups
                .Where(g => !g.GroupUsers.Any(gu => gu.UserId == userId))
                .ToList();
        }
        public Group GetByName(string groupName)
        {
            return DbContext.Groups.FirstOrDefault(g => g.Name == groupName);
        }
        public ResponseResultType AddUserToGroup(int groupId, int userId)
        {
            var group = DbContext.Groups.Find(groupId);
            var user = DbContext.Users.Find(userId);

            if (group == null || user == null)
            {
                return ResponseResultType.NotFound;
            }

            var groupUser = new GroupUser { GroupId = groupId, UserId = userId };
            DbContext.GroupUsers.Add(groupUser);

            return SaveChanges();
        }
        public ICollection<Group> GetChannelsJoinedByUser(int userId)
        {
            return DbContext.GroupUsers
                .Where(gu => gu.UserId == userId)
                .Select(gu => gu.Group)
                .ToList();
        }

        


    }
}
