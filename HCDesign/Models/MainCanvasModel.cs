#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvasModel.cs
// Date: 2016-08-21

#endregion

using System.Windows.Media;
using HCDesign.Common;
using Ninject;

namespace HCDesign.Models
{
    public class MainCanvasModel
    {
        [Inject]
        private ISettingsModel SettingsModel { get; set; }

        public MainCanvasModel()
        {
            BackgroundBrush = new SolidColorBrush(SettingsModel.GetSetting(SettingsEnum.BackgroundBrush));
            ForegroundBrush = new SolidColorBrush(SettingsModel.GetSetting(SettingsEnum.ForegroundBrush));
        }

        public Brush BackgroundBrush { get; }
        public Brush ForegroundBrush { get; }
    }
}