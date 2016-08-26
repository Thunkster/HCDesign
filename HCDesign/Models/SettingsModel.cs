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
    public class SettingsModel : ISettingsModel, INotifyPropertyChanged, IDisposable
    {
        private bool isDirty = false;
        private bool isLoaded = false;

        private Settings settings = new Settings();

        public void Initialize()
        {
            if (isDirty)
            {
                Save();
                return;
            }

            if (!isLoaded)
            {
                Load();
            }
        }

        public dynamic GetSetting(SettingsEnum setting)
        {
            switch (setting)
            {
                case SettingsEnum.ShowGrid:
                    return ShowGrid;

                case SettingsEnum.LastDirectory:
                    return LastDirectory;

                case SettingsEnum.BackgroundColor:
                    return BackgroundColor;

                case SettingsEnum.ForegroundColor:
                    return ForegroundColor;

                default:
                    throw new NotImplementedException(setting.ToString());
            }
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

                case SettingsEnum.BackgroundColor:
                    BackgroundColor = value;
                    break;

                case SettingsEnum.ForegroundColor:
                    ForegroundColor = value;
                    break;

                default:
                    throw new NotImplementedException(setting.ToString());
            }
            isDirty = true;
        }

        #region Private method implementation

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
        private Color BackgroundColor
        {
            get { return settings.BackgroundColor; }
            set { settings.BackgroundColor = value; OnPropertyChanged(); }
        }

        private Color ForegroundColor
        {
            get { return settings.ForegroundColor; }
            set { settings.ForegroundColor = value; OnPropertyChanged(); }
        }

        #endregion

        #region ISettingsModel
        public void Load()
        {
            var filePath = Properties.Settings.Default.AppSettingsPath;

            if (!File.Exists(filePath))
            {
                settings = Settings.FromDefault();
                Save();
            }
            else
            {
                var xmlSerializer = new XmlSerializer(typeof(Settings));
                using (var textStream = new StreamReader(filePath))
                {
                    settings = (Settings)xmlSerializer.Deserialize(textStream);
                }
            }
            isLoaded = true;
        }

        public void Save()
        {
            var filePath = Properties.Settings.Default.AppSettingsPath;

            var xmlSerializer = new XmlSerializer(typeof(Settings));
            using (var textStream = new StreamWriter(filePath))
            {
                xmlSerializer.Serialize(textStream, settings);
            }

            isDirty = false;
        }
        #endregion 

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        #region IDesposable

        public void Dispose()
        {
            Save();
            isLoaded = false;
        }

        #endregion 

    }
}