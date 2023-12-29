namespace Chat.Presentation.Abstractions
{
    public interface IMenuAction : IAction
    {
        IList<IAction> Actions { get; set; }
    }

}
