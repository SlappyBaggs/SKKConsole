#nullable enable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Globalization;

namespace ConsolePageBase
{
    [Serializable]
    [TypeConverter(typeof(ConsolePageConfigTypeConverter))]
    public class ConsolePageConfig
    {
        private static Font DefaultFont = new Font("Comic Sans MS", 12f);

        public ConsolePageConfig(string name, Color c, Font? f)
        {
            PageName = name;
            PageColor = c;
            PageFont = f ?? DefaultFont;
        }

        public string PageName { get; set; } = String.Empty;
        public Color PageColor { get; set; } = Color.Empty;
        public Font? PageFont { get; set; } = null;
    }

    public class ConsolePageConfigTypeConverter : TypeConverter
    {
        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            return destinationType == typeof(string) || base.CanConvertTo(context, destinationType);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            ConsolePageConfig? config = value as ConsolePageConfig;
            return
                config!.PageName + ";" +
                config!.PageColor.ToArgb() + ";" +
                TypeDescriptor.GetConverter(typeof(Font)).ConvertToString(config.PageFont);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            return sourceType == typeof(string) || base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            var casted = value as string;
            if (casted == null) return base.ConvertFrom(context, culture, value);
            string[] sa = casted.Split(';');
            return new ConsolePageConfig(sa[0], Color.FromArgb(Int32.Parse(sa[1])), TypeDescriptor.GetConverter(typeof(Font)).ConvertFromString(sa[2]) as Font);
        }
    }
}

