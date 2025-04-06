using GMap.NET;
using System;

namespace GUI {
    partial class MainForm {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.MainSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MapButtonsSplitContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonsSplitContainer)).BeginInit();
            this.MapButtonsSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainSplitContainer
            // 
            this.MainSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MainSplitContainer.Name = "MainSplitContainer";
            // 
            // MainSplitContainer.Panel1
            // 
            this.MainSplitContainer.Panel1.Controls.Add(this.MapButtonsSplitContainer);
            this.MainSplitContainer.Size = new System.Drawing.Size(1258, 664);
            this.MainSplitContainer.SplitterDistance = 800;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // MapButtonsSplitContainer
            // 
            this.MapButtonsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapButtonsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MapButtonsSplitContainer.Name = "MapButtonsSplitContainer";
            this.MapButtonsSplitContainer.Size = new System.Drawing.Size(419, 664);
            this.MapButtonsSplitContainer.SplitterDistance = 800;
            this.MapButtonsSplitContainer.TabIndex = 0;
            this.MapButtonsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.MainSplitContainer);
            this.Name = "MainForm";
            this.Text = "IP Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonsSplitContainer)).EndInit();
            this.MapButtonsSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer MapButtonsSplitContainer;
    }
}

