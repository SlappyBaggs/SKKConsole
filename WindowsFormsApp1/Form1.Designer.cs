namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.butShowHide = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this._panelFUCK = new ComponentFactory.Krypton.Toolkit.KryptonPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.tbMsg = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.propertyGrid1 = new System.Windows.Forms.PropertyGrid();
            this.skkConsoleData1 = new SKKConsoleNS.SKKConsoleData(this.components);
            ((System.ComponentModel.ISupportInitialize)(this._panelFUCK)).BeginInit();
            this.SuspendLayout();
            // 
            // butShowHide
            // 
            this.butShowHide.Location = new System.Drawing.Point(36, 32);
            this.butShowHide.Name = "butShowHide";
            this.butShowHide.Size = new System.Drawing.Size(75, 23);
            this.butShowHide.TabIndex = 0;
            this.butShowHide.Text = "Show";
            this.butShowHide.UseVisualStyleBackColor = true;
            this.butShowHide.Click += new System.EventHandler(this.buttonShowHide_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(203, 32);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 2;
            this.button3.Text = "Calibration";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(203, 61);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Emoting";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(203, 90);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 4;
            this.button5.Text = "ListOrder";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(203, 119);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(75, 23);
            this.button6.TabIndex = 5;
            this.button6.Text = "Sound";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button_Click);
            // 
            // _panelFUCK
            // 
            this._panelFUCK.Location = new System.Drawing.Point(178, 178);
            this._panelFUCK.Name = "_panelFUCK";
            this._panelFUCK.Size = new System.Drawing.Size(100, 100);
            this._panelFUCK.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(203, 148);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Dialog";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button_Click);
            // 
            // tbMsg
            // 
            this.tbMsg.Location = new System.Drawing.Point(368, 32);
            this.tbMsg.Multiline = true;
            this.tbMsg.Name = "tbMsg";
            this.tbMsg.Size = new System.Drawing.Size(336, 110);
            this.tbMsg.TabIndex = 8;
            this.tbMsg.Text = "You can also do this in a shorter way using LinQ.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(87, 317);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Dialog";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // propertyGrid1
            // 
            this.propertyGrid1.Location = new System.Drawing.Point(368, 148);
            this.propertyGrid1.Name = "propertyGrid1";
            this.propertyGrid1.Size = new System.Drawing.Size(336, 290);
            this.propertyGrid1.TabIndex = 10;
            // 
            // skkConsoleData1
            // 
            this.skkConsoleData1.DefaultColors = ((System.Collections.Generic.List<System.Drawing.Color>)(resources.GetObject("skkConsoleData1.DefaultColors")));
            this.skkConsoleData1.DefaultConfig = ((SKKConsoleNS.SKKConsolePageConfig.ConsolePageConfig)(resources.GetObject("skkConsoleData1.DefaultConfig")));
            this.skkConsoleData1.DefaultPages.Add(((SKKConsoleNS.SKKConsolePageConfig.ConsolePageConfig)(resources.GetObject("skkConsoleData1.DefaultPages"))));
            this.skkConsoleData1.DefaultPages.Add(((SKKConsoleNS.SKKConsolePageConfig.ConsolePageConfig)(resources.GetObject("skkConsoleData1.DefaultPages1"))));
            this.skkConsoleData1.DefaultPages.Add(((SKKConsoleNS.SKKConsolePageConfig.ConsolePageConfig)(resources.GetObject("skkConsoleData1.DefaultPages2"))));
            this.skkConsoleData1.DefaultPages.Add(((SKKConsoleNS.SKKConsolePageConfig.ConsolePageConfig)(resources.GetObject("skkConsoleData1.DefaultPages3"))));
            this.skkConsoleData1.DefaultPages.Add(((SKKConsoleNS.SKKConsolePageConfig.ConsolePageConfig)(resources.GetObject("skkConsoleData1.DefaultPages4"))));
            this.skkConsoleData1.DefaultPages.Add(((SKKConsoleNS.SKKConsolePageConfig.ConsolePageConfig)(resources.GetObject("skkConsoleData1.DefaultPages5"))));
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.propertyGrid1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.tbMsg);
            this.Controls.Add(this.button1);
            this.Controls.Add(this._panelFUCK);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.butShowHide);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this._panelFUCK)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butShowHide;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private ComponentFactory.Krypton.Toolkit.KryptonPanel _panelFUCK;
        private System.Windows.Forms.Button button1;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbMsg;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.PropertyGrid propertyGrid1;
        private SKKConsoleNS.SKKConsoleData skkConsoleData1;
    }
}

