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
    [Serializable]
    [TypeConverter(typeof(ConsolePageConfigTypeConverter))]
    public class ConsolePageConfig
    {
        private static Font DefaultFont = new Font("Comic Sans MS", 12f);

        public ConsolePageConfig()/* : this(string.Empty, Color.Black) */ 
        {
            PageName = "Page";
            PageColor = Color.Red;
            PageFont = DefaultFont;
        }

        public ConsolePageConfig(string name) : this(name, Color.Red, null) { }
        public ConsolePageConfig(string name, Color c) : this(name, c, null) { }
        public ConsolePageConfig(string name, Color c, Font f)
        {
            PageName = name;
            PageColor = c;
            PageFont = (f == null) ? DefaultFont : f;
        }

        [Category("Required")]
        [DefaultValue("Page")]
        public string PageName { get; set; }// = "Page";
        [Category("Required")]
        [DefaultValue(typeof(Color), "Red")]
        public Color PageColor { get; set; }// = Color.Red;
        [Category("Required")]
        [DefaultValue(typeof(Font), "Comic Sans MS, 12pt")]
        public Font PageFont { get; set; }

        public override string ToString() => $"Page: {PageName}";
        //public override string ToString() => PageName;
#if WTF
        public override bool Equals(object obj)
        {
            if (!(obj is ConsolePageConfig)) return base.Equals(obj);
            return Equals((ConsolePageConfig)obj);
        }

        private static Random myRand = new Random();

        public override int GetHashCode() => myRand.Next(1000000);

        public bool Equals(ConsolePageConfig cpc) => (cpc == null) ? false : cpc.PageName == PageName && cpc.PageColor == PageColor && cpc.PageFont == PageFont;

        public static bool operator ==(ConsolePageConfig c1, ConsolePageConfig c2) => (c1 is null && c2 is null) ? true : ((c1 is null || c2 is null) ? false : c1.Equals(c2));

        public static bool operator !=(ConsolePageConfig c1, ConsolePageConfig c2) => !(c1 == c2);
#endif
    }
}
