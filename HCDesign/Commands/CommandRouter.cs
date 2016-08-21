#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: CommandRouter.cs
// Date: 2016-08-14

#endregion

using System;
using System.Windows.Input;

namespace HCDesign.Commands
{
    public class CommandRouter : ICommand
    {
        private readonly Action commandTask;

        public CommandRouter(Action workToDo)
        {
            commandTask = workToDo;
        }


        #region ICommand

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            commandTask();
        }
        #endregion

        protected virtual void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}