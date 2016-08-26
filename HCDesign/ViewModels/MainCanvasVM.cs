#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvasVM.cs
// Date: 2016-08-24

#endregion

using System.Windows.Media;
using HCDesign.Models;
using Ninject;


namespace HCDesign.ViewModels
{
    public class MainCanvasVm
    {
        private readonly MainCanvasModel canvasModel;

        public MainCanvasVm(ISettingsModel model)
        {
            model.Initialize();
            canvasModel = new MainCanvasModel(model);
        }

        public Brush BackgroundBrush => canvasModel.BackgroundBrush;
        public Brush ForegroundBrush => canvasModel.ForegroundBrush;
    }
}