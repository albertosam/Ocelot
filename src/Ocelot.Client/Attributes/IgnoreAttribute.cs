using System;
using System.Collections.Generic;
using System.Text;

namespace Ocelot.Client.Attributes
{
    /// <summary>
    /// Set Controller that doesn't needs to generate reroutes for Ocelot
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public sealed class IgnoreAttribute : Attribute
    {
        public bool IsGenerator { get; set; } = true;
    }
}
