#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvasModel.cs
// Date: 2016-08-25

#endregion

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HCDesign.Common;
using HCDesign.SchematicElements;
using Ninject;

namespace HCDesign.Models
{
    public class MainCanvasModel
    {
        private readonly ISettingsModel settingsModel;
        private readonly List<ISchematicElement> elements = new List<ISchematicElement>();
        private Canvas currentCanvas;

        [Inject]
        public MainCanvasModel(ISettingsModel model)
        {
            settingsModel = model;
        }

        public Brush BackgroundBrush => settingsModel == null ? new SolidColorBrush(Color.FromRgb(32,32,32)) : new SolidColorBrush(settingsModel.GetSetting(SettingsEnum.BackgroundColor));
        public Brush ForegroundBrush => settingsModel == null ? new SolidColorBrush(Color.FromRgb(220, 220, 220)) : new SolidColorBrush(settingsModel.GetSetting(SettingsEnum.ForegroundColor));

        public void SetCanvas(Canvas sender)
        {
            currentCanvas = sender;
        }

        public bool AddElement(MouseButtonEventArgs eArgs, ToolbarButtonEnum selectedToolbarButton)
        {
            var ptLocation = eArgs.GetPosition(currentCanvas);

            switch (selectedToolbarButton)
            {
                case ToolbarButtonEnum.Wire:
                    Debug.WriteLine("Creating WIRE element");
                    var element = new WireElement("TestName", ptLocation);
                    elements.Add(element);
                    currentCanvas.Children.Add(element.GetElement());
                    element.MouseButtonDownHandler(element.GetElement(), eArgs);
                    return true;

                case ToolbarButtonEnum.Capacitor:
                case ToolbarButtonEnum.Inductor:
                case ToolbarButtonEnum.Resistor:
                case ToolbarButtonEnum.Jfet:
                case ToolbarButtonEnum.Transistor:
                default:
                    throw new NotImplementedException();
            }
        }
    }
}