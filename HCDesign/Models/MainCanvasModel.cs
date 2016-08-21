using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace HCDesign.Models
{
    public class MainCanvasModel
    {
        private readonly SettingsModel settingsModel;

        public MainCanvasModel(SettingsModel settings)
        {
            settingsModel = settings;
        }

        public Brush BackgroundBrush => settingsModel.BackgroundBrush;
        public Brush ForegroundBrush => settingsModel.ForegroundBrush;
    }
}
