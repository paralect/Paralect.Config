using System;
using System.Collections.Generic;
using System.Text;

namespace Paralect.Config.Settings
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SettingsPrefixAttribute : Attribute
    {
        /// <summary>
        /// Property prefix
        /// </summary>
        public string Prefix { get; set; }

        public SettingsPrefixAttribute(String prefix)
        {
            Prefix = prefix;
        }
    }
}
