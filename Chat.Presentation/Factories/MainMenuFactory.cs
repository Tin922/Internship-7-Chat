
using Chat.Presentation.Abstractions;
using Chat.Presentation.Actions;
using Chat.Presentation.Extensions;


namespace Chat.Presentation.Factories
{
    public class MainMenuFactory
    {
        public static IList<IAction> CreateActions()
        {
            var actions = new List<IAction>
        {
            LoginFactory.Create(),
            RegisterFactory.Create(),
            new ExitMenuAction(),
        };

            actions.SetActionIndexes();

            return actions;
        }
    }
}
