#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: StateMachine.cs
// Date: 2016-09-03

#endregion

namespace HCDesign.Common.StateMachine
{
    public class StateMachine : IStateMachine
    {
        public StateMachine()
        {
            ElementOperation = ElementOperation.Add;
            SelectedToolbarButton = ToolbarButtonEnum.Wire;
        }

        public ElementOperation ElementOperation { get; set; }
        public ToolbarButtonEnum SelectedToolbarButton { get; set; }
    }
}