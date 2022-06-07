#nullable enable

using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using SKKConsoleNS.SKKConsolePageConfig;

namespace SKKConsoleNS
{
    public delegate void ConsoleHidden();

    public partial class SKKConsole : KryptonForm
    {
        /// <summary>
        /// Make the SKKConsoleWindow a singleton class
        /// </summary>
        private static SKKConsole? _instance = null;

        private static IntPtr _handleMagic;

        public static SKKConsole CWindow
        {
            get
            {
                if(_instance == null) _instance = new SKKConsole();
                _handleMagic = _instance.Handle;
                return _instance;
            } 
        }
        public static bool Showing { get { return CWindow.Visible; } }
        public static void ShowConsole()
        {
            //if(CWindow.InvokeRequired)
            if (Hidden) CWindow.Show();
        }
        public static bool Hidden { get { return !Showing; } }
        public static void HideConsole() { if (Showing) CWindow.Hide(); }

        // Does this have to be exposed??
        private static Color defColor = Color.Red;
        public static Color SKKConsoleDefaultColor { get => defColor; }



        private static Font defFont = new Font("Comic Sans MS", 12f);
        public static Font SKKConsoleDefaultFont { get => defFont; }

        public static event ConsoleHidden? OnConsoleHidden;
        
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();
        //Font? myFont;

        private SKKConsole()
        {
            InitializeComponent();
            _navigator.Pages.Clear();
            AddCategory("ALL", SKKConsoleDefaultColor, SKKConsoleDefaultFont);
            
            InitFont();
            InitDefaultPages();
        }

        private void InitFont()
        {
            byte[] fontData = Properties.Resources.fontDejaVuSansMono;
            IntPtr fontPtr = System.Runtime.InteropServices.Marshal.AllocCoTaskMem(fontData.Length);
            System.Runtime.InteropServices.Marshal.Copy(fontData, 0, fontPtr, fontData.Length);
            uint dummy = 0;
            fonts.AddMemoryFont(fontPtr, Properties.Resources.fontDejaVuSansMono.Length);
            AddFontMemResourceEx(fontPtr, (uint)Properties.Resources.fontDejaVuSansMono.Length, IntPtr.Zero, ref dummy);
            System.Runtime.InteropServices.Marshal.FreeCoTaskMem(fontPtr);

            //myFont = new Font(fonts.Families[0], 16.0F);
            //myFont = new Font("Playball", 16.0F);
        }
        
        public void InitDefaultPages()
        {
            _navigator.Pages.Clear();
            dictRTB.Clear();
            AddCategory("ALL", SKKConsoleDefaultColor, SKKConsoleDefaultFont);

            foreach (ConsolePageConfig page in skkConsoleData1.DefaultPages)
            {
                AddCategory(page.PageName, page.PageColor, page.PageFont ?? SKKConsoleDefaultFont);
            }
        }



        /******************************************************
            A few ways to add a category page.  All functions
            take the category name as a parameter.

         
            Made private so we will be the only one who can 
            add category pages.  These functions create a new
            page, but the page is empty.  I don't want pages
            to be shown (or even exist) if they have no
            messages.  Since we are the only one who can make
            a page we can guarantee we only do so when it won't
            be empty.  
        ******************************************************/
        private void AddPage(string name) { AddCategory(name); }
        //private void AddCat(string name) { AddCategory(name); }
        
        private void AddCategory(string name)
        {
            AddCategory(name, skkConsoleData1.GetNC(), (name == "ALL") ? skkConsoleData1.PageAllFont : skkConsoleData1.DefaultFont);
        }

        //private void AddCategory(string name, Color col_)
        //{
            //AddCategory(name, col_, SKKConsoleDefaultFont);
        //}
        
        //private void AddCategory(string name, Font font_)
        //{
            //AddCategory(name, skkConsoleData1.GetNC(), font_);
        //}

        private void AddCategory(string name, Color col_, Font font_)
        {
            bool b;
            IntPtr temp;
            if (!(b = HasPage(name)))
            {
                KryptonPage kp = new KryptonPage(name);
                kp.Name = name;
                SKKConsolePage skkPage = new SKKConsolePage(name);
                skkPage.Name = name;
                skkPage.Dock = DockStyle.Fill;
                kp.Controls.Add(skkPage);
                skkPage.tbRich.SelectionColor = col_;
                skkPage.tbRich.SelectionFont = font_;
                _navigator.Pages.Add(kp);

                temp = kp.Handle;
                temp = skkPage.tbRich.Handle;
                dictRTB.Add(name, skkPage.tbRich);
            }
            List<string> keys = dictRTB.Keys.ToList();
        }

        private Dictionary<string, KryptonRichTextBox> dictRTB = new Dictionary<string, KryptonRichTextBox>();


        /**********************************************************
            A property that returns whether a category/page exists
            or has been created.  The value returned is real-time.
            
            The category will have had to have been written to at
            least once or else it wouldn't have beeb created yet.
            So 'HasPage' could return 'false' at any point in the
            program and then return 'true' some time after that.
        **********************************************************/
        public bool HasPage(string _name)
        {
            IEnumerable<KryptonPage> _page =
                from page in _navigator.Pages
                where page.Text == _name
                select page;

            //int c1 = _page.Count;
            int c2 = _page.Count();
            return _page.Count() > 0;
        }

        /*************************************************************
            User can add console messages with this function.
        
            If the desired output category is 'ALL', this function will exit and do nothing

            If the desired output category doesn't exist, this function will create it (togglable option?)

            Writes the comment to the category page in category's font & color

            Writes the comment to the 'ALL' page in category's font & color
         *************************************************************/
        public static void Write(string msg, string cat)
        {
            SKKConsole con = CWindow;
            CWindow.Invoke(new Action(() => Write2(msg, cat)));
        }
        
        public static void Write2(string msg, string cat)
        {
            if (cat == "ALL") return;

            Dictionary<string, KryptonRichTextBox> skkTemp = CWindow.dictRTB;

            KryptonNavigator? nav = (CWindow.Controls["_navigator"] as KryptonNavigator);

            if(nav == null) return; // throw

            CWindow.AddPage(cat);

            if (!msg.EndsWith(Environment.NewLine)) msg += Environment.NewLine;
            
            KryptonRichTextBox rtb1 = CWindow.dictRTB[cat];
            KryptonRichTextBox rtb2 = CWindow.dictRTB["ALL"];

            Color c = rtb1.SelectionColor;
            Font f = rtb1.SelectionFont;
            rtb1.SelectionStart = rtb1.Text.Length;
            rtb1.AppendText(msg);
            rtb1.SelectionLength = msg.Length;
            rtb1.SelectionColor = c;
            rtb1.SelectionFont = f;

            rtb2.SelectionColor = rtb1.SelectionColor;
            rtb2.SelectionFont = rtb1.SelectionFont;

            rtb2.AppendText(msg);
            rtb1.SelectionStart = rtb1.Text.Length;
            rtb1.SelectionLength = 0;
        }

        private void SKKConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
                if (OnConsoleHidden != null) OnConsoleHidden();
            }
        }
    }
}
