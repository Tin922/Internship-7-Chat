using Chat.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Configuration;


namespace Chat.Domain.Factories
{
    public static class DbContextFactory
    {
        public static ChatDbContext GetChatDbContext()
        {
            var options = new DbContextOptionsBuilder()
                .UseNpgsql(ConfigurationManager.ConnectionStrings["Chat"].ConnectionString)
                .Options;

            return new ChatDbContext(options);
        }
    }

}
