#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: NinjectBinding.cs
// Date: 2016-08-21

#endregion

using System;
using HCDesign.Models;
using Ninject.Modules;

namespace HCDesign
{
    public class NinjectBinding : NinjectModule
    {
        public override void Load()
        {
            Bind<ISettingsModel>().To<SettingsModel>();
        }
    }
}