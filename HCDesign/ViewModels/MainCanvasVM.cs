#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvasVM.cs
// Date: 2016-08-19

#endregion

using System.Windows.Input;
using HCDesign.Commands;
using HCDesign.Models;

namespace HCDesign.ViewModels
{
    public class MainCanvasVM
    {
        private readonly MainCanvasModel canvasModel;

        public MainCanvasVM(SettingsModel settings)
        {
            canvasModel = new MainCanvasModel(settings);
        }


        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        public MainCanvasModel Model => canvasModel;
    }
}