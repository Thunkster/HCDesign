#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainToolbarModel.cs
// Date: 2016-08-27

#endregion

using HCDesign.Common;
using HCDesign.ViewModels;
using Ninject;

namespace HCDesign.Models
{
    public class MainToolbarModel
    {
        private readonly ISettingsModel settingsModel;

        [Inject]
        public MainToolbarModel(ISettingsModel model)
        {
            settingsModel = model;
        }

        public ToolbarButtonEnum SelectedButton { get; set; }
    }
}