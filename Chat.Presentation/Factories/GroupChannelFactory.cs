

using Chat.Data.Entities.Models;
using Chat.Domain.Factories;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Presentation.Actions;

namespace Chat.Presentation.Factories
{
    public class GroupChannelFactory
    {
        public static GroupChannelAction Create()
        {
            var actions = new List<IAction>
        {
            new GroupChannelAddNewChannel(RepositoryFactory.Create<GroupRepository>()),
            new GroupChannelEnter(RepositoryFactory.Create<GroupRepository>(), RepositoryFactory.Create<UserRepository>()),
            new GroupChannelListAllEnteredChannels(RepositoryFactory.Create<GroupRepository>(), RepositoryFactory.Create<GroupMessageRepository>()),
            new ExitMenuAction()
        };

            var menuAction = new GroupChannelAction(actions);
            return menuAction;
        }
    }
}
