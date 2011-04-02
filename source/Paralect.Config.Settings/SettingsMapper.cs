using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Paralect.Config.Settings
{
    public class SettingsMapper
    {
        public static TObject Map<TObject>()
            where TObject : class, new()
        {
            return (TObject) Map(typeof(TObject));
        }

        public static Object Map(Type type)
        {
            var obj = Activator.CreateInstance(type);

            PropertyInfo[] infos = type.GetProperties();

            foreach (var info in infos)
            {
                object[] attributes = info.GetCustomAttributes(typeof(SettingsPropertyAttribute), true);

                if (attributes.Length < 1)
                    continue;

                var propertyAttribute = attributes[0] as SettingsPropertyAttribute;

                if (!propertyAttribute.IsEmpty)
                {
                    var configValue = System.Configuration.ConfigurationManager.AppSettings[propertyAttribute.Name];

                    SetValue(info, obj, configValue);
                }
                else
                {
                    var innerObj = SettingsMapper.Map(info.PropertyType);
                    info.SetValue(obj, innerObj, null);
                }
            }
            
            return obj;            
        }

        public static void SetValue(PropertyInfo propertyInfo, Object instance, String value)
        {
            var convertedValue = Convert.ChangeType(value, propertyInfo.PropertyType);
            propertyInfo.SetValue(instance, convertedValue, null);
        }
    }
}
