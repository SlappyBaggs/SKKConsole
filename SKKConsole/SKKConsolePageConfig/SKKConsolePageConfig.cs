using System.ComponentModel;
using System.Drawing;
using SKKConsoleNS.Data;

namespace SKKConsoleNS.SKKConsolePageConfig
{
    [TypeConverter(typeof(ConsolePageConfigTypeConverter))]
    public class ConsolePageConfigALL : ConsolePageConfig
    {
        public ConsolePageConfigALL() : base(Defaults.PageALLName) { }
        public ConsolePageConfigALL(string name) : this(Defaults.PageALLName, Color.Empty, null) { }
        public ConsolePageConfigALL(string name, Color c) : this(Defaults.PageALLName, c, null) { }
        public ConsolePageConfigALL(string name, Color c, Font f)
        {
            PageName = Defaults.PageALLName;
            PageColor = Defaults.PageALLColor;
            PageFont = new Font(Defaults.PageALLFontName, Defaults.PageALLFontSize);
        }

        [Browsable(false)]
        public override string PageName
        {
            get => Defaults.PageALLName;
            set { }
        }
    }

    //[Serializable]
    [TypeConverter(typeof(ConsolePageConfigTypeConverter))]
    public class ConsolePageConfig
    {
        public ConsolePageConfig() : this(Defaults.PageName) { }
        public ConsolePageConfig(string name) : this(name, Color.Empty, null) { }
        public ConsolePageConfig(string name, Color c) : this(name, c, null) { }
        public ConsolePageConfig(string name, Color c, Font f)
        {
            PageName = name;
            PageColor = (c != Color.Empty) ? c : SKKConsoleData.NextColor;
            PageFont = (f != null) ? f : SKKConsoleData.DefaultFont;
        }

        private string pageName_;
        [Category("Required")]
        [DefaultValue(Defaults.PageFontName)]
        public virtual string PageName
        {
            get => pageName_;
            set => pageName_ = (PageName == Defaults.PageALLName) ? PageName : value;
        }
        [Category("Required")]
        [DefaultValue(typeof(Color), Defaults.PageColor)]
        public Color PageColor { get; set; }// = Color.Red;
        [Category("Required")]
        [DefaultValue(typeof(Font), Defaults.PageFontString)]
        public Font PageFont { get; set; }

        public override string ToString() => $"{PageName}{ConsolePageConfigTypeConverter.delim_}{PageColor.Name}{ConsolePageConfigTypeConverter.delim_}{PageFont.ToString()}";
        public override bool Equals(object obj)
        {
            if (!(obj is ConsolePageConfig)) return base.Equals(obj);
            return Equals((ConsolePageConfig)obj);
        }

        public override int GetHashCode() => (int)(PageName.Length * PageColor.ToArgb() * PageFont.Size);

        //public bool Equals(ConsolePageConfig cpc) => (cpc == null) ? false : cpc.PageName == PageName && cpc.PageColor == PageColor && cpc.PageFont == PageFont;
        public bool Equals(ConsolePageConfig cpc) => (cpc == null) ? false : cpc.PageName.Equals(PageName) && cpc.PageColor.Equals(PageColor) && cpc.PageFont.Equals(PageFont);

        public static bool operator ==(ConsolePageConfig c1, ConsolePageConfig c2) => (c1 is null && c2 is null) ? true : ((c1 is null || c2 is null) ? false : c1.Equals(c2));

        public static bool operator !=(ConsolePageConfig c1, ConsolePageConfig c2) => !(c1 == c2);
    }
}
