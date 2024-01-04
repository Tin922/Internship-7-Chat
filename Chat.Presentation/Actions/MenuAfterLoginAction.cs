using Chat.Presentation.Abstractions;

namespace Chat.Presentation.Actions
{
    public class MenuAfterLoginAction : BaseMenuAction
    {
        public MenuAfterLoginAction(IList<IAction> actions) : base(actions)
        {
            Name = "MenuAfterLoginAction menu";
        }

        public override void Open()
        {
            Console.WriteLine("MenuAfterLoginAction menu");
            base.Open();
        }
    }
}
