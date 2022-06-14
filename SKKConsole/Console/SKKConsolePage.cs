using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace SKKConsoleNS
{
    public partial class SKKConsolePage : UserControl
    {
        public SKKConsolePage() : this("NoName")
        {
        }

        public SKKConsolePage(string name)
        {
            InitializeComponent();
            this.Name = name;
        }

        //internal KryptonRichTextBox RTB { get => tbRich; }

        private void butClear_Click(object sender, EventArgs e)
        {
            tbRich.Clear();
        }

        private void tbRich_TextChanged(object sender, EventArgs e)
        {
            butClear.Enabled = (tbRich.Text == String.Empty) ? ButtonEnabled.False : ButtonEnabled.True;
            int lines = tbRich.Lines.Count();
            string c = tbRich.SelectionColor.ToString();
            string f = tbRich.SelectionFont.ToString();
            groupPage.ValuesSecondary.Heading = lines.ToString() + " line" + ((lines != 1) ? "s" : "") + "  /  " + c + "  /  " + f;
            tbRich.ScrollToCaret();
        }
    }
}
