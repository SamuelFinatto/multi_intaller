using System;
using System.Reflection;

namespace MultiSVC.Core.Helpers
{
    public enum CompareType
    {
        Lower,
        Greater,
        Same,
        NotDefined
    }

    public static class Assembly
    {
        public static Version GetAssemblyVersion(string assemblyPath)
            => AssemblyName.GetAssemblyName(assemblyPath).Version;

        public static CompareType CompareWith(this Version myVersion, Version another)
        {
            var value = myVersion.CompareTo(another);

            switch (value)
            {
                case 0:
                    return CompareType.Same;

                case 1:
                    return CompareType.Greater;

                case -1:
                    return CompareType.Lower;

                default:
                    return CompareType.NotDefined;
            }
        }
    }
}