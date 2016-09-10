#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: LineElement.cs
// Date: 2016-08-28

#endregion

using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Diagnostics;

namespace HCDesign.SchematicElements
{
    public class WireElement : ISchematicElement
    {
        private enum DragPoint { None, Pt1, Pt2, Both };

        private Line line = null;
        private bool isDragging = true;
        private Point? ptMouseStart;
        private DragPoint dragPoint = DragPoint.None;

        public WireElement(string name, Point initialPoint)
        {
            LineThickness = 2;
            CreateGeometry(name, initialPoint);
        }


        public int LineThickness { get; set; }


        #region Mouse Events
        public void MouseButtonDownHandler(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("WIRE: MouseButtonDownHandler() -- Start");
            var source = sender as Line;
            if (source != null)
            {
                isDragging = true;
                if (line.IsEnabled)
                {
                    ptMouseStart = e.GetPosition((Canvas)source.Parent);
                    line.CaptureMouse();
                }
            }
            Debug.WriteLine("WIRE: MouseButtonDownHandler() -- Completed");
        }

        private void MouseButtonUpHandler(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("WIRE: MouseButtonUpHandler");
            isDragging = false;
            dragPoint = DragPoint.None;
            ptMouseStart = null;
            line.ReleaseMouseCapture();
        }

        private void MouseMoveHandler(object sender, MouseEventArgs e)
        {
            Debug.WriteLine("WIRE: MouseMoveHandler");

            if ((e.LeftButton != MouseButtonState.Pressed) || (!isDragging))
            {
                Debug.WriteLine($"Exit: MouseMoveHandler: e.LeftButton = {e.LeftButton}, isDragging = {isDragging}");
                e.Handled = false;
                line.ReleaseMouseCapture();
                return;
            }

            var lineSource = (Line) sender;
            var parent = (Canvas)lineSource.Parent;
            var ptMouse = e.GetPosition(parent);

            if (!ptMouseStart.HasValue)
            {
                ptMouseStart = ptMouse;
                return;
            }

            Debug.WriteLine($"MouseMoveHandler: ptMouse = {ptMouse}");

            Drag(ptMouse);

            ptMouseStart = ptMouse;
        }
        #endregion

        private void Drag(Point ptMouse)
        {
            Debug.WriteLine("Enter: Drag");
            if (dragPoint == DragPoint.None)
            {
                dragPoint = FindDragPoint(ptMouse);
                Debug.WriteLine($"Found Drag Point: {dragPoint}");
            }

            var dX = ptMouse.X - ptMouseStart.Value.X;
            var dY = ptMouse.Y - ptMouseStart.Value.Y;
            if ((dragPoint == DragPoint.Pt1) || (dragPoint == DragPoint.Both))
            {
                Debug.Write($"Handle Drag P1: Old = ({line.X1}, {line.Y1})  ");
                line.X1 += dX;
                line.Y1 += dY;
                Debug.WriteLine($"New: ({ptMouse.X}, {ptMouse.Y})");
            }

            if ((dragPoint == DragPoint.Pt2) || (dragPoint == DragPoint.Both))
            {
                Debug.Write($"Handle Drag P2: Old = ({line.X2}, {line.Y2})  ");
                line.X2 += dX;
                line.Y2 += dY;
                Debug.WriteLine($"New: ({ptMouse.X}, {ptMouse.Y})");
            }
            Debug.WriteLine("Exit: Drag");
        }

        private DragPoint FindDragPoint(Point ptMouse)
        {
            Debug.Indent();

            var dist0 = Math.Sqrt(Math.Pow(line.X1 - line.X2, 2) + Math.Pow(line.Y1 - line.Y2, 2));
            Debug.WriteLine($"Drag dist0 (line.pt0 to line.pt1): {dist0}");

            var dist1 = Math.Sqrt(Math.Pow(line.X1 - ptMouse.X, 2) + Math.Pow(line.Y1 - ptMouse.Y, 2));
            Debug.WriteLine($"Drag dist1: {dist1}");

            if ( (dist0 < 101) || (dist1 < 25))
            {
                Debug.Unindent();
                return DragPoint.Pt1;
            }

            var dist2 = Math.Sqrt(Math.Pow(line.X2 - ptMouse.X, 2) + Math.Pow(line.Y2 - ptMouse.Y, 2));
            Debug.WriteLine($"Drag dist2: {dist2}");

            if (dist2 < 25)
            {
                Debug.Unindent();
                return DragPoint.Pt2;
            }

            Debug.Unindent();
            return DragPoint.Both;
        }


        private void CreateGeometry(string name, Point initialPoint)
        {
            line = new Line()
            {
                Name = name,
                X1 = initialPoint.X,
                Y1 = initialPoint.Y,
                X2 = initialPoint.X,
                Y2 = initialPoint.Y,
                StrokeThickness = LineThickness,
                Stroke = new SolidColorBrush(Color.FromRgb(100, 200, 100))
            };

            line.MouseDown += MouseButtonDownHandler;
            line.MouseMove += MouseMoveHandler;
            line.MouseUp += MouseButtonUpHandler;
        }

        #region ISchematicElement
        public UIElement GetElement()
        {
            return line;
        }

        public void Serialize(StreamWriter writer)
        {
            throw new System.NotImplementedException();
        }

        public void Deserialize(StreamReader reader)
        {
            throw new System.NotImplementedException();
        }
        #endregion

    }
}