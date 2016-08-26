#region Copyright notice & File header

// Copyright 2016-2016 Emil Saraga (Thunkster)
// Solution: HCDesign, Project: HCDesign
// Filename: ProgramKernel.cs
// Date: 2016-08-26

#endregion

using Ninject;
using Ninject.Modules;

namespace HCDesign
{
    public static class ProgramKernel
    {
        private static StandardKernel kernel;

        public static T Get<T>()
        {
            return kernel.Get<T>();
        }

        public static void Initialize(params INinjectModule[] modules)
        {
            if (kernel == null)
            {
                kernel = new StandardKernel(modules);
            }
        }
    }
}