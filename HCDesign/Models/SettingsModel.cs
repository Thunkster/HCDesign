#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: SettingsModel.cs
// Date: 2016-08-14

#endregion

using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Media;
using System.Xml.Serialization;
using HCDesign.Common;
using HCDesign.ViewModels;

namespace HCDesign.Models
{
    public class SettingsModel : INotifyPropertyChanged, ISettingsModel
    {
        private readonly MainMenuVM mainMenuVM;
        private readonly Settings settings;

        public SettingsModel(MainMenuVM mainMenuVm)
        {
            mainMenuVM = mainMenuVm;
            settings = Load();
        }

        public bool ShowGrid
        {
            get { return settings.ShowGrid; }
            set { settings.ShowGrid = value; OnPropertyChanged(); }
        }

        public string LastDirectory
        {
            get { return settings.LastDirectory; }
            set { settings.LastDirectory = value; OnPropertyChanged(); }
        }


        // Main Canvas:
        public Brush BackgroundBrush => settings.BackgroundBrush;
        public Brush ForegroundBrush => settings.ForegroundBrush;


        public dynamic GetSetting(SettingsEnum setting)
        {
            throw new System.NotImplementedException();
        }


        #region ISettingsModel
        public Settings Load()
        {
            var filePath = Properties.Settings.Default.AppSettingsPath;
            var loadedSetting = new Settings();

            if (!File.Exists(filePath))
            {
                return loadedSetting;
            }

            var xmlSerializer = new XmlSerializer(typeof(Settings));
            var textStream = new StreamReader(filePath);

            xmlSerializer.Deserialize(textStream);

            return loadedSetting;
        }

        public void Save(Settings settings)
        {
            var filePath = Properties.Settings.Default.AppSettingsPath;

            var xmlSerializer = new XmlSerializer(typeof(Settings));
            var textStream = new StreamWriter(filePath);

            xmlSerializer.Serialize(textStream, settings);
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