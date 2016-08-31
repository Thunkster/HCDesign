#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: VmLocator.cs
// Date: 2016-08-26

#endregion

using HCDesign.ViewModels;

namespace HCDesign
{
    public class VmLocator
    {
        public MainCanvasVm MainCanvasVm => ProgramKernel.Get<MainCanvasVm>();
        public MainToolbarVm MainToolbarVm => ProgramKernel.Get<MainToolbarVm>();
        public MainMenuVm MainMenuVm => ProgramKernel.Get<MainMenuVm>();
    }
}