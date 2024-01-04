
using Chat.Presentation.Abstractions;
using System.Xml.Linq;

namespace Chat.Presentation.Actions
{
    public class DirectMessageAction : BaseMenuAction
    {
        public DirectMessageAction(IList<IAction> actions) : base(actions)
        {
            Name = "Direct Messages menu";
        }

        public override void Open()
        {
            Console.WriteLine("Direct Messages menu");
            base.Open();
        }

    }

}
