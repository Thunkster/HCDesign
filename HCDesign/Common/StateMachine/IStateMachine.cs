namespace HCDesign.Common.StateMachine
{
    public interface IStateMachine
    {
        ElementOperation ElementOperation { get; set; }
        ToolbarButtonEnum SelectedToolbarButton { get; set; }
    }
}
