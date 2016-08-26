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
        [XmlElement]
        public bool ShowGrid { get; set; }

        [XmlElement]
        public string LastDirectory { get; set; }

        [XmlElement]
        public Color BackgroundColor { get; set; }

        [XmlElement]
        public Color ForegroundColor { get; set; }

        public static Settings FromDefault()
        {
            // Defaults:
            return new Settings()
            {
                ShowGrid = true,
                LastDirectory = @".\",
                BackgroundColor = Color.FromRgb(0, 64, 64),
                ForegroundColor = Color.FromRgb(200, 64, 64)
            };
        }
    }
}