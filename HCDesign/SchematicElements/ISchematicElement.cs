#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: ISchematicElement.cs
// Date: 2016-08-28

#endregion

using System.IO;
using System.Windows;

namespace HCDesign.SchematicElements
{
    internal interface ISchematicElement
    {
        UIElement GetElement();

        void Serialize(StreamWriter writer);

        void Deserialize(StreamReader reader);
    }
}