

using Chat.Domain.Factories;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Presentation.Actions;

namespace Chat.Presentation.Factories
{
    public class RegisterFactory
    {
        public static RegisterAction Create()
        {
            var actions = new List<IAction>
        {
            new Register(RepositoryFactory.Create<UserRepository>()),
            new ExitMenuAction()
        };

            var menuAction = new RegisterAction(actions);
            return menuAction;
        }
    }
}
