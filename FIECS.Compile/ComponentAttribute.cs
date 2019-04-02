using System;
using System.Collections.Generic;
using System.Text;

namespace FIECS.Core
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = false, Inherited = false)]
    public class ComponentAttribute : Attribute
    {
    }
}