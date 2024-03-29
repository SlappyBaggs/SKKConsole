﻿#nullable enable

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
    //[Serializable]
    [TypeConverter(typeof(ConsolePageConfigTypeConverter))]
    public class ConsolePageConfig
    {
        private static Font DefaultFont = new Font("Comic Sans MS", 12f);

        public ConsolePageConfig()/* : this(string.Empty, Color.Black) */ { }
        public ConsolePageConfig(string name, Color c) : this(name, c, null) { }
        
        public ConsolePageConfig(string name, Color c, Font? f)
        {
            PageName = name;
            PageColor = c;
            PageFont = f ?? DefaultFont;
        }

        [Category("Required")]
        public string PageName { get; set; } = String.Empty;
        [Category("Required")]
        public Color PageColor { get; set; } = Color.Empty;
        [Category("Required")]
        public Font? PageFont { get; set; } = null;

        public override string ToString()
        {
            return "Page " + PageName;
        }
    }
}
