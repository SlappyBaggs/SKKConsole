using System;
//using System.Drawing;
using System.Windows.Forms;
using SKKConsoleNS;
using SKKConsoleNS.SKKConsolePageConfig;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SKKConsoleNS.SKKConsoleForm MyConsole;

        public Form1()
        {
            InitializeComponent();

            ConsoleController = skkConsole1;

            MyConsole = ConsoleController.CWindow;

            ConsoleController.ConsoleHidden += () => butShowHide.Text = "Show";

            propertyGrid1.SelectedObject = skkConsole1;
        }


        public SKKConsole ConsoleController { get; set; }

        private void buttonShowHide_Click(object sender, EventArgs e)
        {
            if (butShowHide.Text == "Show")
            {
                ConsoleController.ShowConsole();
                butShowHide.Text = "Hide";
            }
            else
            {
                ConsoleController.HideConsole();
                butShowHide.Text = "Show";
            }
        }

        private void consoleHidden()
        {
        }

        int clickCount_ = 0;
        private void button_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            clickCount_++;
            ConsoleController.Write(s, $"({clickCount_}) {tbMsg.Text}");
        }

        public class TestClass
        {
            public TestClass() : this("") { }
            public TestClass(string t) { Test = t; }
            public string Test { get; set; }

            public override string ToString() => Test;
            public override bool Equals(object obj) => obj is TestClass other && other.Test == Test;
            public override int GetHashCode() => Test.GetHashCode();
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
            
            tbMsg.Clear();
            tbMsg.AppendText($"{b0} : {b1}\r\n");
            tbMsg.AppendText($"{b2} : {b3}\r\n");
            tbMsg.AppendText($"{b4} : {b5}\r\n");
            tbMsg.AppendText($"{b6} : {b7}\r\n");
        }

        private void butBreak_Click(object sender, EventArgs e)
        {
            ConsoleController.Break();
        }
    }
}
