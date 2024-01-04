
using Chat.Presentation.Abstractions;
using System.Xml.Linq;

namespace Chat.Presentation.Actions
{
    public class GroupChannelAction : BaseMenuAction
    {
        public GroupChannelAction(IList<IAction> actions) : base(actions)
        {
            Name = "Grupni kanali";
        }

        public override void Open()
        {
            Console.WriteLine("Grupni kanali");
            base.Open();
        }

    }

}
