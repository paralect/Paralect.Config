using System;
using System.Collections.Generic;
using System.Text;

namespace Paralect.Config.Settings
{
    public class SettingsPropertyAttribute : Attribute
    {
        public string Name { get; set; }
        public Type Type { get; set; }

        /// <summary>
        /// By default type is String
        /// </summary>
        public SettingsPropertyAttribute(String name, Type type)
        {
            Name = name;
            Type = type;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Attribute"/> class.
        /// </summary>
        public SettingsPropertyAttribute(string name) : this(name, typeof(String))
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="T:System.Attribute"/> class.
        /// </summary>
        public SettingsPropertyAttribute()
        {
        }

        public Boolean IsEmpty
        {
            get { return Name == null; }
        }
    }
}
