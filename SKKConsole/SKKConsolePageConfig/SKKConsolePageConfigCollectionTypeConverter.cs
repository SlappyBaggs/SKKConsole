using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;

namespace SKKConsoleNS.SKKConsolePageConfig
{
    public class ConsolePageConfigCollectionTypeConverter :  ExpandableObjectConverter
    {
        //public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        //{
        //return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        //}

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            return "ConsolePageConfigCollection";
            //if (destinationType == typeof(string) && value is ConsolePageConfigCollection)
            //{
                //return "ConsolePageConfigCollection";
            //}
            //return base.ConvertTo(context, culture, value, destinationType);
            //ConsolePageConfigCollection collection = value as ConsolePageConfigCollection;
            //if(collection == null) return base.ConvertTo(context, culture, value, destinationType);
            //string ret = string.Empty;
            //foreach(ConsolePageConfig config in collection) ret += ((ret == string.Empty) ? "" : "@") + TypeDescriptor.GetConverter(typeof(ConsolePageConfig)).ConvertToInvariantString(config);
            //return ret;
        }

        //public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        //{
            //return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        //}

        //public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        //{
            //string castedVal = value as string;
            //if(castedVal == null) return base.ConvertFrom(context, culture, value);
            //ConsolePageConfigCollection collection = new ConsolePageConfigCollection();
            //string[] sa = castedVal.Split('@');
            //foreach(string s in sa) collection.Add(TypeDescriptor.GetConverter(typeof(ConsolePageConfig)).ConvertFromInvariantString(s) as ConsolePageConfig);
            //return collection;
        //}
    }
}
