#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: App.xaml.cs
// Date: 2016-08-26

#endregion

using System.Windows;
using HCDesign.Common;
using HCDesign.Models;
using Ninject;

namespace HCDesign
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            ProgramKernel.Initialize(new ControlsNinjectModule());
            ComposeObjects();
            Current.MainWindow.Show();
        }


        private static void ComposeObjects()
        {
            // Load program settings:
            var settings = ProgramKernel.Get<SettingsModel>();
            settings.Load();

            Current.MainWindow = ProgramKernel.Get<MainWindow>();
            Current.MainWindow.Title = "HCDesing with Ninject";
        }
    }
}