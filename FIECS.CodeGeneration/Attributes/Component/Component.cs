using System;
using System.Diagnostics;

namespace FIECS.Attributes.Component
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    [Conditional("CodeGeneration")]
    public class Component : Attribute
    {
    }
}
