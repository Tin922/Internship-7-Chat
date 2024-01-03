using Chat.Presentation.Abstractions;

namespace Chat.Presentation.Actions
{
    public class RegisterAction : BaseMenuAction
    {
        public RegisterAction(IList<IAction> actions) : base(actions)
        {
            Name = "Register menu";
        }

        public override void Open()
        {
            Console.WriteLine("Register menu");
            base.Open();
        }
    }
}
