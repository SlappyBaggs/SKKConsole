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

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ConsoleData = skkConsoleData1;

            SKKConsole.OnConsoleHidden += () => { butShowHide.Text = "Show"; };

            propertyGrid1.SelectedObject = skkConsoleData1;
        }

        
        public SKKConsoleData ConsoleData { get; set; }

        private void buttonShowHide_Click(object sender, EventArgs e)
        {
            if (butShowHide.Text == "Show")
            {
                SKKConsole.ShowConsole();
                butShowHide.Text = "Hide";
            }
            else
            {
                SKKConsole.HideConsole();
                butShowHide.Text = "Show";
            }
        }

        private void consoleHidden()
        {
        }
        
        private void button_Click(object sender, EventArgs e)
        {
            string s = (sender as Button).Text;
            SKKConsole.Write(tbMsg.Text, ((Button)sender).Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
        }
    }
}
