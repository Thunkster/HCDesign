#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: Settings.cs
// Date: 2016-08-21

#endregion

using System.Windows.Media;
using System.Xml.Serialization;

namespace HCDesign
{
    [XmlRoot( Namespace = "Thunkster.Net" )]
    public class Settings
    {
        public Settings()
        {
            // Defaults:
            ShowGrid = true;
            LastDirectory = @".\";
            BackgroundBrush = Color.FromRgb(64, 64, 64);
            ForegroundBrush = Color.FromRgb(200, 64, 64);
        }

        [XmlElement]
        public bool ShowGrid { get; set; }

        [XmlElement]
        public string LastDirectory { get; set; }

        [XmlElement]
        public Color BackgroundBrush { get; set; }

        [XmlElement]
        public Color ForegroundBrush { get; set; }
    }
}