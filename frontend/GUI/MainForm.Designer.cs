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
            this.MainTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.MapButtonSplitContainer = new System.Windows.Forms.SplitContainer();
            this.MainTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonSplitContainer)).BeginInit();
            this.MapButtonSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTableLayout
            // 
            this.MainTableLayout.ColumnCount = 2;
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 62.79809F));
            this.MainTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.20191F));
            this.MainTableLayout.Controls.Add(this.MapButtonSplitContainer, 0, 0);
            this.MainTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainTableLayout.Location = new System.Drawing.Point(0, 0);
            this.MainTableLayout.Name = "MainTableLayout";
            this.MainTableLayout.RowCount = 1;
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.MainTableLayout.Size = new System.Drawing.Size(1258, 664);
            this.MainTableLayout.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.MapButtonSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapButtonSplitContainer.Location = new System.Drawing.Point(3, 3);
            this.MapButtonSplitContainer.Name = "splitContainer1";
            this.MapButtonSplitContainer.Size = new System.Drawing.Size(784, 658);
            this.MapButtonSplitContainer.SplitterDistance = 261;
            this.MapButtonSplitContainer.TabIndex = 0;
            this.MapButtonSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.MainTableLayout);
            this.Name = "MainForm";
            this.Text = "IP Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainTableLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonSplitContainer)).EndInit();
            this.MapButtonSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel MainTableLayout;
        private System.Windows.Forms.SplitContainer MapButtonSplitContainer;
    }
}

