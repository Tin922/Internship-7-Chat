

using Chat.Data.Entities.Models;
using Chat.Domain.Factories;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Presentation.Actions;

namespace Chat.Presentation.Factories
{
    public class DirectMessageFactory
    {
        public static DirectMessageAction Create()
        {
            var actions = new List<IAction>
        {
            new ShowAllUsersForMessages(RepositoryFactory.Create<UserRepository>(), RepositoryFactory.Create<DirectMessageRepository>()),
            new ShowAllUsersChats(RepositoryFactory.Create<DirectMessageRepository>()),

            new ExitMenuAction()
        };

            var menuAction = new DirectMessageAction(actions);
            return menuAction;
        }
    }
}
