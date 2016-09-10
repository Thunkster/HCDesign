using Microsoft.VisualStudio.TestTools.UnitTesting;
using HCDesign;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using HCDesign.Common;

namespace HCDesign.Tests
{
    [TestClass()]
    public class SettingsTests
    {
        [TestMethod()]
        public void FromDefaultTest()
        {
            var settings = Settings.FromDefault();

            Assert.IsTrue(settings.ShowGrid);
            Assert.IsTrue(settings.SelectedToolbarButton == ToolbarButtonEnum.Wire);
            Assert.IsTrue(settings.BackgroundColor == Color.FromRgb(16, 16, 16));
            Assert.IsTrue(settings.ForegroundColor == Color.FromRgb(200, 200, 64));
        }
    }
}