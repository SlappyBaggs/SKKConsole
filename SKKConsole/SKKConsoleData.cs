using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SKKConsoleNS.SKKConsolePageConfig;

namespace SKKConsoleNS
{
    //[Serializable]
    public partial class SKKConsoleData : Component
    {
        public SKKConsoleData()
        {
            InitializeComponent();

            //AddDefPages();
        }

        public SKKConsoleData(IContainer container)
        {
            container.Add(this);

            InitializeComponent();

            SKKConsole.OnConsoleHidden += OnConsoleHidden;

            //AddDefPages();
        }

        public static SKKConsole CWindow { get { return SKKConsole.CWindow; } }
        public static bool Showing { get { return SKKConsole.Showing; } }
        public static void ShowConsole() { SKKConsole.ShowConsole(); }
        public static bool Hidden { get { return !Showing; } }
        public static void HideConsole() { SKKConsole.HideConsole(); }

        public static event ConsoleHidden OnConsoleHidden;

        public void Write(string s1, string s2) { SKKConsole.Write(s1, s2); }


        //private void AddDefPages()
        //{ 
        //DefaultPages.Add(new ConsolePageConfig("Scott1", Color.Lime, new Font("DK Cool Crayon", 17f)));
        //DefaultPages.Add(new ConsolePageConfig("Bagels", Color.Orange, new Font("Dot 28", 24f)));
        //DefaultPages.Add(new ConsolePageConfig("DocP", Color.Peru, new Font("Ink Free", 24f)));
        //}

        [Browsable(true)]
        [Category("PageALL Options")]
        [DisplayName("PageALL Color")]
        [Description("Color of text for PageALL")]
        [DefaultValue(typeof(Color), "255,0,0")]
        public Color PageAllColor { get; set; } = Color.Red;

        [Browsable(true)]
        [Category("PageALL Options")]
        [DisplayName("PageALL Font")]
        [Description("Font used for PageALL")]
        [DefaultValue(typeof(Font), "Consolas, 10pt")]
        public Font PageAllFont { get; set; } = new Font("Consolas", 10f);

        [Browsable(true)]
        [Category("Page Options")]
        [DisplayName("DefaultFont")]
        [Description("Font given to Pages that do not explicitly set one")]
        [DefaultValue(typeof(Font), "Consolas, 10pt")]
        public Font DefaultFont { get; set; } = new Font("Consolas", 10f);

        [Browsable(true)]
        [Category("Page Options")]
        [DisplayName("DefaultColors")]
        [Description("Colors to choose from for Pages that do not explicitly set one")]
        public List<Color> DefaultColors { get; set; } = new List<Color>()
        {
            Color.Red,
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
            Color.Purple
        };

        /*
        public List<Font> DefaultFonts { get; set; } = new List<Font>()
        {
            new Font("NegativeSpace", 24f),
            new Font("Comic Sans MS", 20f),
            new Font("Alien Encounters", 15f),
            new Font("PWPerspective", 27f),
            new Font("Blood Thirst",21f)
        };
        
        private int fontIndex = 0;
        public Font GetNF()
        {
            if (fontIndex == DefaultFonts.Count) fontIndex = 0;
            Font ret = DefaultFonts[fontIndex++];
            return ret;// DefaultColors[colorIndex++];
        }
        */

        private int colorIndex = 0;
        public Color GetNC()
        {
            if (colorIndex == DefaultColors.Count) colorIndex = 0;
            return DefaultColors[colorIndex++];
        }

        //ConsolePageConfigCollection myDefPages = new ConsolePageConfigCollection();

        [Browsable(true)]
        [Category("Page Options")]
        [DisplayName("DefaultPages")]
        [Description("Pages to auto-create on start")]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Editor(typeof(CollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]
        //[TypeConverter(typeof(ConsolePageConfigCollectionTypeConverter))]
        //public List<ConsolePageConfig> DefaultPages { get; private set; } = new List<ConsolePageConfig>();
        public ConsolePageConfigCollection DefaultPages { get; private set; } = new ConsolePageConfigCollection();
    }
}

