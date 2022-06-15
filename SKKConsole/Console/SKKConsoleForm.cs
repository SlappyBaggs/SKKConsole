﻿using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using SKKConsoleNS.SKKConsolePageConfig;
using SKKConsoleNS.Data;

namespace SKKConsoleNS
{
    public delegate void ConsoleHidden();

    public partial class SKKConsoleForm : KryptonForm
    {
#if EMBED_FONTS
        [System.Runtime.InteropServices.DllImport("gdi32.dll")]
        private static extern IntPtr AddFontMemResourceEx(IntPtr pbFont, uint cbFont, IntPtr pdv, [System.Runtime.InteropServices.In] ref uint pcFonts);
        private PrivateFontCollection fonts = new PrivateFontCollection();

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
#endif
        internal event ConsoleHidden OnConsoleHidden = delegate { };

        private SKKConsole myData_ = null;
        public SKKConsoleForm(SKKConsole data)
        {
            InitializeComponent();
            myData_ = data;
            IntPtr _handleMagic = Handle;

#if EMBED_FONTS
            InitFont();
#endif

            OnConsoleHidden += myData_.OnConsoleHidden;
            InitDefaultPages();
        }

        public void InitDefaultPages()
        {
            _navigator.Pages.Clear();
            //dictRTB.Clear();
            dictData.Clear();
            AddCategory("ALL", Color.Empty, null);

            foreach (ConsolePageConfig page in myData_.DefaultPages)
                AddCategory(page.PageName, page.PageColor, page.PageFont /*?? SKKConsoleDefaultFont*/);
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
        private void AddPage(string name) => AddCategory(name);
        private void AddCategory(string name) => AddCategory(name, myData_.NextColor);
        private void AddCategory(string name, Color col_) => AddCategory(name, col_, myData_.DefaultFont);
        private void AddCategory(string name, Color col_, Font font_)
        {
            if (HasPage(name)) return;
            KryptonPage kp = new KryptonPage(name);
            kp.Name = name;
            SKKConsolePage skkPage = new SKKConsolePage(name);
            skkPage.Name = name;
            skkPage.Dock = DockStyle.Fill;
            kp.Controls.Add(skkPage);
            if(col_ != Color.Empty) skkPage.tbRich.SelectionColor = skkPage.oldColor_ = col_;
            if(font_ != null) skkPage.tbRich.SelectionFont = font_;
            _navigator.Pages.Add(kp);

            // Force Handle generation
            int temp = kp.Handle.ToInt32() + skkPage.tbRich.Handle.ToInt32();
           
            dictData.Add(name, (col_, font_));
        }

        private Dictionary<string, (Color PageColor, Font PageFont)> dictData = new Dictionary<string, (Color, Font)>();

        /**********************************************************
            A property that returns whether a category/page exists
            or has been created.  The value returned is real-time.
            
            The category will have had to have been written to at
            least once or else it wouldn't have beeb created yet.
            So 'HasPage' could return 'false' at any point in the
            program and then return 'true' some time after that.
        **********************************************************/
        public bool HasPage(string _name) => dictData.Keys.Contains(_name);

        /*************************************************************
            User can add console messages with this function.
        
            If the desired output category is 'ALL', this function will exit and do nothing

            If the desired output category doesn't exist, this function will create it,
            using the next color index of the DefaultColors and DefaultFont
            (make auto-generation a togglable option???)

            Writes the comment to both the ALL page and the category page in
            category's font & color
         *************************************************************/
        internal void Write(string cat, string msg)
        {
            if (InvokeRequired) { Invoke((Action)delegate { Write(msg, cat); }); }
            else
            {
                if (cat == "ALL") return;

                // Why are we checking this?????
                KryptonNavigator nav = (Controls["_navigator"] as KryptonNavigator);
                if (nav == null) return;

                // Attempt to add, if already exists then nothing happens
                AddPage(cat);

                // Ensure the 'msg' ends with a newline
                msg += msg.EndsWith(Environment.NewLine)?"":Environment.NewLine;

                KryptonRichTextBox rtb1 = (nav.Pages[cat].Controls[cat] as SKKConsolePage).tbRich;
                KryptonRichTextBox rtb2 = (nav.Pages["ALL"].Controls["ALL"] as SKKConsolePage).tbRich;

                // Set PageALL's Color and Font to rtb1's
                rtb2.SelectionColor = rtb1.SelectionColor = dictData[cat].PageColor;
                rtb2.SelectionFont = rtb1.SelectionFont = dictData[cat].PageFont;

                // Set selection start to end of current texts in rtb1 & rtb2
                rtb1.SelectionStart = rtb1.Text.Length;
                rtb2.SelectionStart = rtb2.Text.Length;

                // Add new text to rtb1 & rtb2
                rtb1.AppendText(msg);
                rtb2.AppendText(msg);
            }
        }
        private void SKKConsole_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Check if user closed the box
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // If they did, cancel the close and hide it instead, to prevent disposal
                e.Cancel = true;
                Hide();
                OnConsoleHidden();
            }
        }
    }
}
