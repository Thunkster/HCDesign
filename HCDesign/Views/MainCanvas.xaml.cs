#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvas.xaml.cs
// Date: 2016-08-24

#endregion

using System.Windows.Controls;
using System.Windows.Input;
using HCDesign.ViewModels;


namespace HCDesign.Views
{
    /// <summary>
    ///     Interaction logic for DrawingArea.xaml
    /// </summary>
    public partial class MainCanvas : UserControl
    {
        public MainCanvas()
        {
            InitializeComponent();
        }

        private void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            //throw new System.NotImplementedException();
        }
    }
}