namespace WindowsFormsApp2
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
            ComponentFactory.Krypton.Navigator.KryptonPage pageALL;
            this.kryptonNavigator1 = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.kryptonRichTextBox1 = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            pageALL = new ComponentFactory.Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).BeginInit();
            this.kryptonNavigator1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(pageALL)).BeginInit();
            pageALL.SuspendLayout();
            this.SuspendLayout();
            // 
            // kryptonNavigator1
            // 
            this.kryptonNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonNavigator1.Location = new System.Drawing.Point(0, 0);
            this.kryptonNavigator1.Name = "kryptonNavigator1";
            this.kryptonNavigator1.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            pageALL});
            this.kryptonNavigator1.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.kryptonNavigator1.SelectedIndex = 0;
            this.kryptonNavigator1.Size = new System.Drawing.Size(800, 450);
            this.kryptonNavigator1.TabIndex = 0;
            this.kryptonNavigator1.Text = "kryptonNavigator1";
            // 
            // pageALL
            // 
            pageALL.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            pageALL.Controls.Add(this.kryptonRichTextBox1);
            pageALL.Flags = 65534;
            pageALL.LastVisibleSet = true;
            pageALL.MinimumSize = new System.Drawing.Size(50, 50);
            pageALL.Name = "pageALL";
            pageALL.Size = new System.Drawing.Size(798, 424);
            pageALL.Text = "ALL";
            pageALL.ToolTipTitle = "Page ToolTip";
            pageALL.UniqueName = "8FD0012E3D6149640CA21039F2DD8199";
            // 
            // kryptonRichTextBox1
            // 
            this.kryptonRichTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kryptonRichTextBox1.Location = new System.Drawing.Point(0, 0);
            this.kryptonRichTextBox1.Name = "kryptonRichTextBox1";
            this.kryptonRichTextBox1.Size = new System.Drawing.Size(798, 424);
            this.kryptonRichTextBox1.StateCommon.Back.Color1 = System.Drawing.Color.Black;
            this.kryptonRichTextBox1.TabIndex = 0;
            this.kryptonRichTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.kryptonNavigator1);
            this.Name = "Form1";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.kryptonNavigator1)).EndInit();
            this.kryptonNavigator1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(pageALL)).EndInit();
            pageALL.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ComponentFactory.Krypton.Navigator.KryptonNavigator kryptonNavigator1;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox kryptonRichTextBox1;
    }
}

