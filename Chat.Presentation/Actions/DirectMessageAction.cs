
using Chat.Presentation.Abstractions;
using System.Xml.Linq;

namespace Chat.Presentation.Actions
{
    public class DirectMessageAction : BaseMenuAction
    {
        public DirectMessageAction(IList<IAction> actions) : base(actions)
        {
            Name = "Privatne poruke";
        }

        public override void Open()
        {
            Console.WriteLine("Privatne poruke");
            base.Open();
        }

    }

}
