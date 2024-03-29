﻿using ComponentFactory.Krypton.Toolkit;
using ComponentFactory.Krypton.Navigator;
using SKKConsoleNS.SKKConsolePageConfig;

namespace SKKConsoleNS
{
    partial class SKKConsoleForm
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
            this._navigator = new ComponentFactory.Krypton.Navigator.KryptonNavigator();
            this.pageALL = new ComponentFactory.Krypton.Navigator.KryptonPage();
            ((System.ComponentModel.ISupportInitialize)(this._navigator)).BeginInit();
            this._navigator.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pageALL)).BeginInit();
            this.SuspendLayout();
            // 
            // _navigator
            // 
            this._navigator.Bar.BarMapExtraText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.None;
            this._navigator.Bar.BarMapImage = ComponentFactory.Krypton.Navigator.MapKryptonPageImage.Small;
            this._navigator.Bar.BarMapText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.TextTitle;
            this._navigator.Bar.CheckButtonStyle = ComponentFactory.Krypton.Toolkit.ButtonStyle.Standalone;
            this._navigator.Bar.ItemMinimumSize = new System.Drawing.Size(80, 20);
            this._navigator.Bar.ItemSizing = ComponentFactory.Krypton.Navigator.BarItemSizing.SameHeight;
            this._navigator.Bar.TabBorderStyle = ComponentFactory.Krypton.Toolkit.TabBorderStyle.RoundedOutsizeMedium;
            this._navigator.Bar.TabStyle = ComponentFactory.Krypton.Toolkit.TabStyle.HighProfile;
            this._navigator.Button.ButtonDisplayLogic = ComponentFactory.Krypton.Navigator.ButtonDisplayLogic.Context;
            this._navigator.Button.CloseButtonAction = ComponentFactory.Krypton.Navigator.CloseButtonAction.RemovePageAndDispose;
            this._navigator.Button.CloseButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this._navigator.Button.ContextButtonAction = ComponentFactory.Krypton.Navigator.ContextButtonAction.SelectPage;
            this._navigator.Button.ContextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Hide;
            this._navigator.Button.ContextMenuMapImage = ComponentFactory.Krypton.Navigator.MapKryptonPageImage.Small;
            this._navigator.Button.ContextMenuMapText = ComponentFactory.Krypton.Navigator.MapKryptonPageText.TextTitle;
            this._navigator.Button.NextButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
            this._navigator.Button.NextButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Logic;
            this._navigator.Button.NextButtonShortcut = System.Windows.Forms.Keys.None;
            this._navigator.Button.PreviousButtonAction = ComponentFactory.Krypton.Navigator.DirectionButtonAction.ModeAppropriateAction;
            this._navigator.Button.PreviousButtonDisplay = ComponentFactory.Krypton.Navigator.ButtonDisplay.Logic;
            this._navigator.Button.PreviousButtonShortcut = System.Windows.Forms.Keys.None;
            this._navigator.Dock = System.Windows.Forms.DockStyle.Fill;
            this._navigator.Group.GroupBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this._navigator.Group.GroupBorderStyle = ComponentFactory.Krypton.Toolkit.PaletteBorderStyle.ControlClient;
            this._navigator.Header.HeaderStyleBar = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this._navigator.Header.HeaderStylePrimary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Primary;
            this._navigator.Header.HeaderStyleSecondary = ComponentFactory.Krypton.Toolkit.HeaderStyle.Secondary;
            this._navigator.Location = new System.Drawing.Point(0, 0);
            this._navigator.MinimumSize = new System.Drawing.Size(800, 450);
            this._navigator.Name = "_navigator";
            this._navigator.NavigatorMode = ComponentFactory.Krypton.Navigator.NavigatorMode.BarTabGroup;
            this._navigator.PageBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.ControlClient;
            this._navigator.Pages.AddRange(new ComponentFactory.Krypton.Navigator.KryptonPage[] {
            this.pageALL});
            this._navigator.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparklePurple;
            this._navigator.Panel.PanelBackStyle = ComponentFactory.Krypton.Toolkit.PaletteBackStyle.PanelClient;
            this._navigator.SelectedIndex = 0;
            this._navigator.Size = new System.Drawing.Size(800, 450);
            this._navigator.TabIndex = 1;
            this._navigator.Text = "_navigator";
            // 
            // pageALL
            // 
            this.pageALL.AutoHiddenSlideSize = new System.Drawing.Size(200, 200);
            this.pageALL.Flags = 65534;
            this.pageALL.LastVisibleSet = true;
            this.pageALL.MinimumSize = new System.Drawing.Size(50, 50);
            this.pageALL.Name = "pageALL";
            this.pageALL.Size = new System.Drawing.Size(798, 424);
            this.pageALL.Text = "ALL";
            this.pageALL.ToolTipStyle = ComponentFactory.Krypton.Toolkit.LabelStyle.ToolTip;
            this.pageALL.ToolTipTitle = "Page ToolTip";
            this.pageALL.UniqueName = "D93213EA45B94D84C0B9B8A32C22ED95";
            // 
            // SKKConsole
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._navigator);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(816, 489);
            this.Name = "SKKConsole";
            this.PaletteMode = ComponentFactory.Krypton.Toolkit.PaletteMode.SparkleOrange;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SKKConsole";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.SKKConsole_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this._navigator)).EndInit();
            this._navigator.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pageALL)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KryptonNavigator _navigator;
        private KryptonPage pageALL;
    }
}