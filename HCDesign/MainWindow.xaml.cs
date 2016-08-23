#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainWindow.xaml.cs
// Date: 2016-08-14

#endregion

using System.Reflection;
using System.Windows;
using HCDesign.Models;
using Ninject;

namespace HCDesign
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ISettingsModel settingsModel;

        public MainWindow()
        {
            // For Ninject:
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            settingsModel = kernel.Get<ISettingsModel>();

            InitializeComponent();
        }
    }
}