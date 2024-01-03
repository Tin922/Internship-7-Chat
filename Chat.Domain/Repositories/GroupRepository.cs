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

     
    }
}
