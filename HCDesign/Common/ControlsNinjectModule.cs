#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: ControlsNinjectModule.cs
// Date: 2016-08-26

#endregion

using HCDesign.Models;
using Ninject.Modules;

namespace HCDesign.Common
{
    public class ControlsNinjectModule : NinjectModule
    {
        public override void Load()
        {
            // MainCanvas:
            Bind<ISettingsModel>().To<SettingsModel>().InSingletonScope();
            Bind<MainCanvasModel>().ToSelf().InTransientScope();
            Bind<MainMenuModel>().ToSelf().InTransientScope();
        }
    }
}