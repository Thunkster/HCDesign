#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvasVM.cs
// Date: 2016-08-22

#endregion

using System;
using System.Windows.Input;
using HCDesign.Models;

namespace HCDesign.ViewModels
{
    public class MainCanvasVM
    {
        private readonly MainCanvasModel model;

        public MainCanvasVM()
        {
            model = new MainCanvasModel();
        }


        public void OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}