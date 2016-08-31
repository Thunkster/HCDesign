#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainToolbarVm.cs
// Date: 2016-08-27

#endregion

using System;
using System.ComponentModel;
using System.Windows.Input;
using HCDesign.Commands;
using HCDesign.Models;

namespace HCDesign.ViewModels
{
    public class MainToolbarVm : INotifyPropertyChanged
    {
        private readonly MainToolbarModel toolbarModel;
        private ISettingsModel SettingsModel { get; }

        public MainToolbarVm(ISettingsModel settingsModel)
        {
            toolbarModel = new MainToolbarModel() {SelectedButton = ToolbarButtonEnum.Wire};

            SettingsModel = settingsModel;
            SettingsModel.Initialize();
        }

        public bool IsWireToggled => (toolbarModel.SelectedButton == ToolbarButtonEnum.Wire);
        public bool IsResistorToggled => (toolbarModel.SelectedButton == ToolbarButtonEnum.Resistor);
        public bool IsCapacitorToggled => (toolbarModel.SelectedButton == ToolbarButtonEnum.Capacitor);
        public bool IsInductorToggled => (toolbarModel.SelectedButton == ToolbarButtonEnum.Inductor);
        public bool IsTransistorToggled => (toolbarModel.SelectedButton == ToolbarButtonEnum.Transistor);


        public ICommand WireButton => new CommandRouter(WireSelected);
        public ICommand ResitorButton => new CommandRouter(ResistorSelected);
        public ICommand CapacitorButton => new CommandRouter(CapacitorSelected);
        public ICommand InductorButton => new CommandRouter(InductorSelected);
        public ICommand TransistorButton => new CommandRouter(TransistorSelected);

        #region Private Methods

        private void WireSelected()
        {
            var old = toolbarModel.SelectedButton;
            toolbarModel.SelectedButton = ToolbarButtonEnum.Wire;

            SendPropertyChanged(old);
            SendPropertyChanged(ToolbarButtonEnum.Wire);
        }

        private void ResistorSelected()
        {
            var old = toolbarModel.SelectedButton;
            toolbarModel.SelectedButton = ToolbarButtonEnum.Resistor;

            SendPropertyChanged(old);
            SendPropertyChanged(ToolbarButtonEnum.Resistor);
        }

        private void CapacitorSelected()
        {
            var old = toolbarModel.SelectedButton;
            toolbarModel.SelectedButton = ToolbarButtonEnum.Capacitor;

            SendPropertyChanged(old);
            SendPropertyChanged(ToolbarButtonEnum.Capacitor);
        }
        private void InductorSelected()
        {
            var old = toolbarModel.SelectedButton;
            toolbarModel.SelectedButton = ToolbarButtonEnum.Inductor;

            SendPropertyChanged(old);
            SendPropertyChanged(ToolbarButtonEnum.Inductor);
        }

        private void TransistorSelected()
        {
            var old = toolbarModel.SelectedButton;
            toolbarModel.SelectedButton = ToolbarButtonEnum.Transistor;

            SendPropertyChanged(old);
            SendPropertyChanged(ToolbarButtonEnum.Transistor);
        }

        private void SendPropertyChanged(ToolbarButtonEnum button)
        {
            switch (button)
            {
                case ToolbarButtonEnum.Wire:
                    OnPropertyChanged(nameof(IsWireToggled));
                    break;
                case ToolbarButtonEnum.Resistor:
                    OnPropertyChanged(nameof(IsResistorToggled));
                    break;
                case ToolbarButtonEnum.Capacitor:
                    OnPropertyChanged(nameof(IsCapacitorToggled));
                    break;
                case ToolbarButtonEnum.Inductor:
                    OnPropertyChanged(nameof(IsInductorToggled));
                    break;
                case ToolbarButtonEnum.Transistor:
                    OnPropertyChanged(nameof(IsTransistorToggled));
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        #endregion

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}