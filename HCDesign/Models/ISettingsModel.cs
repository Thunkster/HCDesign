#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: ISettings.cs
// Date: 2016-08-21

#endregion

using System.Windows.Media;
using HCDesign.Common;

namespace HCDesign.Models
{
    public interface ISettingsModel
    {
        // Get any setting from the model:
        dynamic GetSetting(SettingsEnum setting);

        void SetSetting(SettingsEnum setting, dynamic value);

        // Load settings model from file:
        void Load();

        // Save settings model to file:
        void Save();
    }
}