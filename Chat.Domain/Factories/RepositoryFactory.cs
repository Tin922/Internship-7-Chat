using Chat.Domain.Repositories;

namespace Chat.Domain.Factories
{
    public class RepositoryFactory
    {
        public static TRepository Create<TRepository>()
      where TRepository : BaseRepository
        {
            var dbContext = DbContextFactory.GetChatDbContext();
            var repositoryInstance = Activator.CreateInstance(typeof(TRepository), dbContext) as TRepository;

            return repositoryInstance!;
        }
    }
}
