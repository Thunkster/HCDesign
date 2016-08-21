#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: Settings.cs
// Date: 2016-08-14

#endregion

using System.IO;
using System.Runtime.Serialization;
using System.Windows.Media;
using System.Windows.Navigation;
using HCDesign.Models;

namespace HCDesign
{
    public class Settings
    {
        public Settings()
        {
            // Defaults:
            ShowGrid = true;
            LastDirectory = @".\";
            BackgroundBrush = new SolidColorBrush(Color.FromRgb(64, 64, 64));
            ForegroundBrush = new SolidColorBrush(Color.FromRgb(200, 64, 64));
        }

        public bool ShowGrid { get; set; }

        public string LastDirectory { get; set; }

        public Brush BackgroundBrush { get; }
        public Brush ForegroundBrush { get; }


    }
}