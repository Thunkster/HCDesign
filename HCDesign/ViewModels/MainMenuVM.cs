#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: MainMenuVM.cs
// Date: 2016-08-14

#endregion

using System;
using System.Windows;
using System.Windows.Input;
using HCDesign.Commands;
using HCDesign.Models;

namespace HCDesign.ViewModels
{
    public class MainMenuVM
    {
        private readonly SettingsModel settingsModel;

        public MainMenuVM()
        {
            settingsModel = new SettingsModel(this);
        }

        public ICommand NewCommand => new CommandRouter(New);
        public ICommand OpenCommand => new CommandRouter(Open);
        public ICommand SaveCommand => new CommandRouter(Save);
        public ICommand QuitCommand => new CommandRouter(Quit);

        public ICommand ShowGridCommand => new CommandRouter(ShowGrid);



        #region FileMenu Commands
        public void New()
        {
        }

        public void Open()
        {
            var dlg = new Microsoft.Win32.OpenFileDialog
            {
                Multiselect = false,
                DefaultExt = ".png",
                Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif"
            };

            // Display OpenFileDialog by calling ShowDialog method 
            var result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                //var filename = dlg.FileName;
                throw new NotImplementedException();
            }
        }

        public void Save()
        {
        }

        public void Quit()
        {
            Application.Current.Shutdown(0);
        }
        #endregion

        #region SettingsMenu Commands
        public void ShowGrid()
        {
            settingsModel.ShowGrid = (!settingsModel.ShowGrid);
        }
        #endregion
    }
}