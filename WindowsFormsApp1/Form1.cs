using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SKKConsoleNS;
using ComponentFactory.Krypton.Toolkit;
using SKKConsoleNS.SKKConsolePageConfig;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ConsoleData = skkConsoleData1;

            //SKKConsole.OnConsoleHidden += () => { butShowHide.Text = "Show"; };

            propertyGrid1.SelectedObject = skkConsoleData1;
        }

        
        public SKKConsoleData ConsoleData { get; set; }

        private void buttonShowHide_Click(object sender, EventArgs e)
        {
            if (butShowHide.Text == "Show")
            {
                //SKKConsole.ShowConsole();
                butShowHide.Text = "Hide";
            }
            else
            {
                //SKKConsole.HideConsole();
                butShowHide.Text = "Show";
            }
        }

        private void consoleHidden()
        {
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            //SKKConsole.Write(tbMsg.Text, ((Button)sender).Text);
        }

        public class TestClass
        {
            public TestClass() : this("") { }
            public TestClass(string t) { Test = t; }
            public string Test { get; set; }

            public override string ToString() => Test;

            public override bool Equals(object obj)
            {
                if (obj is TestClass) return ((TestClass)obj).Test == Test;
                return false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ConsolePageConfig c1 = new ConsolePageConfig();
            ConsolePageConfig c2 = new ConsolePageConfig();
            //ConsolePageConfig c3 = c1;

            bool b0 = c1.PageName == c2.PageName;
            bool b1 = c1.PageName.Equals(c2.PageName);
            bool b2 = c1.PageColor == c2.PageColor ;
            bool b3 = c1.PageColor.Equals(c2.PageColor);
            bool b4 = c1.PageFont == c2.PageFont;
            bool b5 = c1.PageFont.Equals(c2.PageFont);
            bool b6 = c1 == c2;
            bool b7 = c1.Equals(c2);
            bool b8 = c1 == skkConsoleData1.DefaultConfig;
            bool b9 = c1.Equals(skkConsoleData1.DefaultConfig);

            tbMsg.Clear();
            tbMsg.AppendText($"{b0} : {b1}\r\n");
            tbMsg.AppendText($"{b2} : {b3}\r\n");
            tbMsg.AppendText($"{b4} : {b5}\r\n");
            tbMsg.AppendText($"{b6} : {b7}\r\n");
            tbMsg.AppendText($"{b8} : {b9}\r\n");
        }
    }
}
