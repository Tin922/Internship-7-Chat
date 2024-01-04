

using Chat.Data.Entities.Models;
using Chat.Domain.Factories;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Presentation.Actions;
using Chat.Presentation.Extensions;
using System.Data;

namespace Chat.Presentation.Factories
{
    public class MenuAfterLogin
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>
        {
            GroupChannelFactory.Create(),
            DirectMessageFactory.Create(),
            new ProfileSettings(RepositoryFactory.Create<UserRepository>()),
            new AdminActions(RepositoryFactory.Create<UserRepository>()),
            new LogoutAction(),

        };      




            actions.SetActionIndexes();

            return actions;
        }
        public class LogoutAction : IAction
        {
            public int MenuIndex { get; set; }
            public string Name { get; set; } = "Logout";

            public void Open()
            {
                
                Login.Logout();
               
            }
        }
    }
}
