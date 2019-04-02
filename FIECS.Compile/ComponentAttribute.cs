using System;

namespace FIECS.Compile
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class ComponentAttribute : Attribute
    {
    }
}