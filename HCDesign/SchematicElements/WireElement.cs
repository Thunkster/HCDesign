#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: LineElement.cs
// Date: 2016-08-28

#endregion

using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace HCDesign.SchematicElements
{
    public class WireElement : ISchematicElement
    {
        private readonly ObservableCollection<Shape> shapeCollection = new ObservableCollection<Shape>();
        private readonly PointCollection ptCollection = new PointCollection();

        public WireElement()
        {
            ptCollection.Add(new Point(0, 0));
            ptCollection.Add(new Point(0, 0));
            shapeCollection.Add(new Line());
        }

        public int SelectedPoint { get; set; }


        public void HandleEvent(Canvas sender, MouseButtonEventArgs args)
        {
            switch (args.ChangedButton)
            {
                case MouseButton.Left:
                    if (args.ButtonState == MouseButtonState.Pressed)
                    {
                        DoLeftButtonPress(sender, args);
                        return;
                    }
                    DoLeftButtonReleased(sender, args);
                    break;
            }
        }

        private void DoLeftButtonReleased(Canvas sender, MouseButtonEventArgs args)
        {
            throw new System.NotImplementedException();
        }

        private void DoLeftButtonPress(Canvas sender, MouseButtonEventArgs args)
        {
            throw new System.NotImplementedException();
        }


        public ObservableCollection<Shape> GetShape()
        {
            return shapeCollection;
            
        }

    }
}