

using Chat.Domain.Factories;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Presentation.Actions;

namespace Chat.Presentation.Factories
{
    public class LoginFactory
    {
        public static LoginAction Create()
        {
            var actions = new List<IAction>
        {
            new Login(RepositoryFactory.Create<UserRepository>()),           
            new ExitMenuAction()
        };

            var menuAction = new LoginAction(actions);
            return menuAction;
        }
    }
}
