

using Chat.Data.Entities.Models;
using Chat.Domain.Factories;
using Chat.Domain.Repositories;
using Chat.Presentation.Abstractions;
using Chat.Presentation.Actions;
using Chat.Presentation.Extensions;

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

        };

            actions.SetActionIndexes();

            return actions;
        }
    }
}
