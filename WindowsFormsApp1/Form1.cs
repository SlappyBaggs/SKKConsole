using System;
using System.Drawing;
using System.Windows.Forms;
using SKKConsoleNS.SKKConsolePageConfig;
using SKKConsoleNS.Data;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SKKConsoleNS.SKKConsole MyConsole;

        public Form1()
        {
            InitializeComponent();

            ConsoleData = skkConsoleData1;

            MyConsole = ConsoleData.CWindow;

            ConsoleData.ConsoleHidden += () => butShowHide.Text = "Show";

            propertyGrid1.SelectedObject = skkConsoleData1;
        }


        public SKKConsoleData ConsoleData { get; set; }

        private void buttonShowHide_Click(object sender, EventArgs e)
        {
            if (butShowHide.Text == "Show")
            {
                ConsoleData.ShowConsole();
                butShowHide.Text = "Hide";
            }
            else
            {
                ConsoleData.HideConsole();
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
            ConsoleData.Write(s, $"({clickCount_}) {tbMsg.Text}();
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
            
            ConsolePageConfigALL configALL = ConsoleData.PageALLConfig;
            ConsolePageConfig conf1 = new ConsolePageConfig("ALL", Color.Red, new Font("Comic Sans MS", 12));
            ConsolePageConfigALL conf2 = new ConsolePageConfigALL("ALL", Color.Red, new Font("Comic Sans MS", 12));

            bool b8 = configALL == conf1;
            bool b9 = configALL.Equals(conf1);

            bool ba = configALL == conf2;
            bool bb = conf1.Equals(conf2);

            
            tbMsg.Clear();
            tbMsg.AppendText($"{b0} : {b1}\r\n");
            tbMsg.AppendText($"{b2} : {b3}\r\n");
            tbMsg.AppendText($"{b4} : {b5}\r\n");
            tbMsg.AppendText($"{b6} : {b7}\r\n");
            tbMsg.AppendText($"{b8} : {b9}\r\n");
            tbMsg.AppendText($"{ba} : {bb}\r\n");
        }
    }
}
