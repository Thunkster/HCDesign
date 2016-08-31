#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvasVM.cs
// Date: 2016-08-24

#endregion

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using HCDesign.Models;


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


        public void HandleEvent(object sender, RoutedEventArgs e)
        {
            if (e.RoutedEvent.Name == "Loaded")
            {
                canvasModel.SetCanvas( (Canvas)sender);
            }            
        }
    }
}