#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvasModel.cs
// Date: 2016-08-25

#endregion

using System;
using System.Windows.Controls;
using System.Windows.Media;
using HCDesign.Common;
using Ninject;

namespace HCDesign.Models
{
    public class MainCanvasModel
    {
        private readonly ISettingsModel settingsModel;
        private Canvas currentCanvas;

        [Inject]
        public MainCanvasModel(ISettingsModel model)
        {
            settingsModel = model;
        }

        public Brush BackgroundBrush => settingsModel == null ? new SolidColorBrush(Color.FromRgb(64,64,64)) : new SolidColorBrush(settingsModel.GetSetting(SettingsEnum.BackgroundColor));
        public Brush ForegroundBrush => settingsModel == null ? new SolidColorBrush(Color.FromRgb(100, 100, 0)) : new SolidColorBrush(settingsModel.GetSetting(SettingsEnum.ForegroundColor));

        public void SetCanvas(Canvas sender)
        {
            currentCanvas = sender;
        }
    }
}