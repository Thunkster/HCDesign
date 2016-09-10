#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: Settings.cs
// Date: 2016-08-21

#endregion

using System.Windows.Media;
using System.Xml.Serialization;

namespace HCDesign.Common
{
    [XmlRoot( Namespace = "Thunkster.Net" )]
    public class Settings
    {
        [XmlElement]
        public bool ShowGrid { get; set; }

        [XmlElement]
        public ToolbarButtonEnum SelectedToolbarButton { get; set; }

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
                SelectedToolbarButton = ToolbarButtonEnum.Wire,
                BackgroundColor = Color.FromRgb(16, 16, 16),
                ForegroundColor = Color.FromRgb(200, 200, 64)
            };
        }
    }
}