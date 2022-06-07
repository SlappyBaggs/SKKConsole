#nullable enable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.Collections;

namespace SKKConsoleNS.SKKConsolePageConfig
{
    public class ConsolePageConfigTypeConverter : ExpandableObjectConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            //return "YaMama!";
            ConsolePageConfig? config = value as ConsolePageConfig;
            return
                config!.PageName + ";" +
                config.PageColor.ToArgb() + ";" +
                TypeDescriptor.GetConverter(typeof(Font)).ConvertToInvariantString(config.PageFont);
        }
        /*
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var casted = value as string;
            if (casted == null) return base.ConvertFrom(context, culture, value);
            string[] sa = casted.Split(';');
            return new ConsolePageConfig(sa[0], Color.FromArgb(Int32.Parse(sa[1])), TypeDescriptor.GetConverter(typeof(Font)).ConvertFromInvariantString(sa[2]) as Font);
        }
    */
        }
}
