#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesignTests
// Filename: SettingsModelTests.cs
// Date: 2016-08-27

#endregion

using System;
using System.Linq;
using System.Windows.Media;
using HCDesign.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HCDesign.Models.Tests
{
    [TestClass()]
    public class SettingsModelTests
    {
        private readonly Color testBackgroundColor = Color.FromRgb(32, 32, 132);
        private readonly Color testForegroundColor = Color.FromRgb(32, 132, 32);
        private const ToolbarButtonEnum TestSelectedToolbarButton = ToolbarButtonEnum.Wire;
        private const bool TestShowGrid = true;


        [TestMethod()]
        public void GetSettingTest()
        {
            // Setup test:
            var testSettings = new Settings()
            {
                BackgroundColor = Color.FromRgb(0,0,0),
                ForegroundColor = Color.FromRgb(0,0,0),
                SelectedToolbarButton = ToolbarButtonEnum.Wire,
                ShowGrid = false
            };

            var settingsModel = new SettingsModel();
            settingsModel.InitializeForTesting(testSettings);

            // Do Test:
            foreach (var settingItem in Enum.GetValues(typeof(SettingsEnum)).Cast<SettingsEnum>())
            {
                switch (settingItem)
                {
                    case SettingsEnum.ShowGrid:
                        settingsModel.SetSetting(settingItem, TestShowGrid);
                        Assert.IsTrue(TestShowGrid == (bool)settingsModel.GetSetting(settingItem));
                        break;
                    case SettingsEnum.SelectedToolbarButton:
                        settingsModel.SetSetting(settingItem, TestSelectedToolbarButton);
                        Assert.IsTrue(TestSelectedToolbarButton == (ToolbarButtonEnum)settingsModel.GetSetting(settingItem));
                        break;
                    case SettingsEnum.BackgroundColor:
                        settingsModel.SetSetting(settingItem, testBackgroundColor);
                        Assert.IsTrue(testBackgroundColor == (Color)settingsModel.GetSetting(settingItem));
                        break;
                    case SettingsEnum.ForegroundColor:
                        settingsModel.SetSetting(settingItem, testForegroundColor);
                        Assert.IsTrue(testForegroundColor == (Color)settingsModel.GetSetting(settingItem));
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }
    }
}