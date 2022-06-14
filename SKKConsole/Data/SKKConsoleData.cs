using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using SKKConsoleNS.SKKConsolePageConfig;

namespace SKKConsoleNS.Data
{
    public partial class SKKConsoleData : Component
    {
        public SKKConsoleData()
        {
            InitializeComponent();
        }

        public SKKConsoleData(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private SKKConsole myConsole_ = null;

        public SKKConsole CWindow { get => myConsole_ ?? (myConsole_ = new SKKConsole(this)); }
        public bool Showing { get => CWindow.Visible; }
        public bool Hidden { get => !Showing; }
        public void ShowConsole() => CWindow.Show();
        public void HideConsole() => CWindow.Hide();
        public void ToggleConsole() { if (Showing) HideConsole(); else ShowConsole(); }

        public event ConsoleHidden ConsoleHidden = delegate { };
        public void OnConsoleHidden() => ConsoleHidden();

        public void Write(string s1, string s2) { CWindow.Write(s1, s2); }

        private static Font defaultFont_ = new Font(Defaults.PageFontName, Defaults.PageFontSize);

        [Browsable(true)]
        [Category("Page Options")]
        [DisplayName("Default Font")]
        [Description("Font given to Pages that do not explicitly set one")]
        [DefaultValue(typeof(Font), Defaults.PageFontString)]
        public Font DefFont
        { 
            get => defaultFont_;
            set => defaultFont_ = value;
        }

        [Browsable(false)]
        public static Font DefaultFont { get => defaultFont_; }

        [Browsable(false)]
        private static List<Color> DefaultColors_ { get; set; } = new List<Color>()
        {
            Color.Pink,
            Color.Lime,
            Color.Green,
            Color.Cyan,
            Color.Blue,
            Color.White,
            Color.LightYellow,
            Color.Yellow,
            Color.Magenta,
            Color.LightGray,
            Color.Gray,
            Color.Purple,
            Color.Red
        };
        private static int colorIndex = 0;

        [Browsable(true)]
        [Category("Page Options")]
        [DisplayName("DefaultColors")]
        [Description("Colors to choose from for Pages that do not explicitly set one")]
        public List<Color> DefaultColors
        {
            get => SKKConsoleData.DefaultColors_;
            set => SKKConsoleData.DefaultColors_ = value;
        }

        [Browsable(false)]
        public static Color NextColor
        {
            get
            {
                if (colorIndex >= SKKConsoleData.DefaultColors_.Count) colorIndex = 0;
                return DefaultColors_[colorIndex++];
            }
        }

        [Browsable(true)]
        [Category("Page Options")]
        [DisplayName("Page ALL Page")]
        [Description("Setup for the main 'ALL' page")]
        [TypeConverter(typeof(ConsolePageConfigTypeConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(typeof(ConsolePageConfigALL), Defaults.PageALLString)]
        public ConsolePageConfigALL PageALLConfig { get; set; } = new ConsolePageConfigALL(Defaults.PageALLFontName, Defaults.PageALLColor, new Font(Defaults.PageALLFontName, Defaults.PageALLFontSize));


        [Browsable(true)]
        [Category("Page Options")]
        [DisplayName("DefaultPages")]
        [Description("Pages to auto-create on start")]
        [TypeConverter(typeof(ConsolePageConfigCollectionTypeConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public ConsolePageConfigCollection DefaultPages { get; set; } = new ConsolePageConfigCollection();
    }
}
