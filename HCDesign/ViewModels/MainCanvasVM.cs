#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainCanvasVM.cs
// Date: 2016-08-24

#endregion

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using HCDesign.Common.StateMachine;
using HCDesign.Models;


namespace HCDesign.ViewModels
{
    public class MainCanvasVm
    {
        private bool testLineAdded = false;
        private readonly IStateMachine stateMachine;
        private readonly MainCanvasModel canvasModel;

        public MainCanvasVm(ISettingsModel model, IStateMachine state)
        {
            model.Initialize();
            stateMachine = state;
            canvasModel = new MainCanvasModel(model);
        }

        public Brush BackgroundBrush => canvasModel.BackgroundBrush;
        public Brush ForegroundBrush => canvasModel.ForegroundBrush;


        public void HandleEvent(object sender, RoutedEventArgs eArgs)
        {
            // If this is a child element, the child 
            // will handle within the element itself
            if ((sender != eArgs.Source) || ((sender as Canvas) == null))
            {
                return;
            }

            var mainCanvas = (Canvas) sender;

            // When the canvas throws the "Loaded" event
            // it is ready to go. We can now capture the
            // canvas instance created in xaml
            if (eArgs.RoutedEvent.Name == "Loaded")
            {
                canvasModel.SetCanvas(mainCanvas);
                eArgs.Handled = true;
                return;
            }

            // A mouse down here means add or delete an element (so far)
            if (eArgs.RoutedEvent.Name == "MouseDown")
            {
                var rEvent = (MouseButtonEventArgs) eArgs;

                switch (stateMachine.ElementOperation)
                {
                    case ElementOperation.Add:
                        if (!testLineAdded)
                        {
                            Debug.WriteLine("MainCanvasVM::ElementOperation.Add() -- Start");
                            canvasModel.AddElement(rEvent, stateMachine.SelectedToolbarButton);
                            testLineAdded = true;
                            Debug.WriteLine("MainCanvasVM::ElementOperation.Add() -- Completed");
                        }
                        break;

                    case ElementOperation.Delete:
                        eArgs.Handled = true;
                        Debug.WriteLine("MainCanvasVM::ElementOperation.Delete -- Completed");
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(stateMachine.ElementOperation));
                }
            }
        }
    }
}