#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: SettingsModel.cs
// Date: 2016-08-14

#endregion

using System;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Xml.Serialization;
using HCDesign.Common;


namespace HCDesign.Models
{
    public class SettingsModel : ISettingsModel, INotifyPropertyChanged
    {
        private Settings settings;

        public SettingsModel()
        {
             Load();
        }

        public dynamic GetSetting(SettingsEnum setting)
        {
            switch (setting)
            {
                case SettingsEnum.ShowGrid:
                    return ShowGrid;

                case SettingsEnum.LastDirectory:
                    return LastDirectory;

                case SettingsEnum.BackgroundBrush:
                    return BackgroundBrush;

                case SettingsEnum.ForegroundBrush:
                    return ForegroundBrush;
            }

            return null;
        }

        public void SetSetting(SettingsEnum setting, dynamic value)
        {
            switch (setting)
            {
                case SettingsEnum.ShowGrid:
                    ShowGrid = value;
                    break;

                case SettingsEnum.LastDirectory:
                    LastDirectory = value;
                    break;

                case SettingsEnum.BackgroundBrush:
                    BackgroundBrush = value;
                    break;

                case SettingsEnum.ForegroundBrush:
                    ForegroundBrush = value;
                    break;

                default:
                    throw new NotImplementedException(setting.ToString());
            }
        }



        // Private:
        // ////////////////////////////////////// 
        private bool ShowGrid
        {
            get { return settings.ShowGrid; }
            set { settings.ShowGrid = value; OnPropertyChanged(); }
        }

        private string LastDirectory
        {
            get { return settings.LastDirectory; }
            set { settings.LastDirectory = value; OnPropertyChanged(); }
        }


        // Main Canvas:
        private Color BackgroundBrush
        {
            get { return settings.BackgroundBrush; }
            set { settings.BackgroundBrush = value; OnPropertyChanged(); }
        }

        private Color ForegroundBrush
        {
            get { return settings.ForegroundBrush; }
            set { settings.ForegroundBrush = value; OnPropertyChanged(); }
        }



        #region ISettingsModel
        public void Load()
        {
            var filePath = Properties.Settings.Default.AppSettingsPath;

            if (!File.Exists(filePath))
            {
                settings = new Settings();
                Save();

                return;
            }

            var xmlSerializer = new XmlSerializer(typeof(Settings));
            using (var textStream = new StreamReader(filePath))
            {
                xmlSerializer.Deserialize(textStream);
            }
        }

        public void Save()
        {
            var filePath = Properties.Settings.Default.AppSettingsPath;

            var xmlSerializer = new XmlSerializer(typeof(Settings));
            using (var textStream = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(textStream, settings);
            }
        }
        #endregion 

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}