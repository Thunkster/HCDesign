#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: ISchematicElement.cs
// Date: 2016-08-28

#endregion

using System.Collections.ObjectModel;
using System.Windows.Shapes;

namespace HCDesign.SchematicElements
{
    internal interface ISchematicElement
    {
        ObservableCollection<Shape> GetShape();
    }
}