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
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ClearListButton = new System.Windows.Forms.Button();
            this.ResetMapButton = new System.Windows.Forms.Button();
            this.IoCButton = new System.Windows.Forms.Button();
            this.IPDataList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonsSplitContainer)).BeginInit();
            this.MapButtonsSplitContainer.Panel1.SuspendLayout();
            this.MapButtonsSplitContainer.Panel2.SuspendLayout();
            this.MapButtonsSplitContainer.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPDataList)).BeginInit();
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
            // 
            // MainSplitContainer.Panel2
            // 
            this.MainSplitContainer.Panel2.Controls.Add(this.IPDataList);
            this.MainSplitContainer.Size = new System.Drawing.Size(1258, 664);
            this.MainSplitContainer.SplitterDistance = 800;
            this.MainSplitContainer.TabIndex = 0;
            // 
            // MapButtonsSplitContainer
            // 
            this.MapButtonsSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapButtonsSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.MapButtonsSplitContainer.Name = "MapButtonsSplitContainer";
            this.MapButtonsSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MapButtonsSplitContainer.Panel1
            // 
            this.MapButtonsSplitContainer.Panel1.Controls.Add(this.Map);
            // 
            // MapButtonsSplitContainer.Panel2
            // 
            this.MapButtonsSplitContainer.Panel2.Controls.Add(this.ButtonLayout);
            this.MapButtonsSplitContainer.Size = new System.Drawing.Size(800, 664);
            this.MapButtonsSplitContainer.SplitterDistance = 500;
            this.MapButtonsSplitContainer.TabIndex = 0;
            // 
            // Map
            // 
            this.Map.Bearing = 0F;
            this.Map.CanDragMap = true;
            this.Map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Map.EmptyTileColor = System.Drawing.Color.Navy;
            this.Map.GrayScaleMode = false;
            this.Map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.Map.LevelsKeepInMemmory = 5;
            this.Map.Location = new System.Drawing.Point(0, 0);
            this.Map.MarkersEnabled = true;
            this.Map.MaxZoom = 2;
            this.Map.MinZoom = 15;
            this.Map.MouseWheelZoomEnabled = true;
            this.Map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.Map.Name = "Map";
            this.Map.NegativeMode = false;
            this.Map.PolygonsEnabled = true;
            this.Map.RetryLoadTile = 0;
            this.Map.RoutesEnabled = true;
            this.Map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map.ShowTileGridLines = false;
            this.Map.Size = new System.Drawing.Size(800, 500);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 2D;
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.ColumnCount = 3;
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonLayout.Controls.Add(this.ClearListButton, 2, 0);
            this.ButtonLayout.Controls.Add(this.ResetMapButton, 1, 0);
            this.ButtonLayout.Controls.Add(this.IoCButton, 0, 0);
            this.ButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLayout.Location = new System.Drawing.Point(0, 0);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayout.Size = new System.Drawing.Size(800, 160);
            this.ButtonLayout.TabIndex = 0;
            // 
            // IoCButton
            // 
            this.IoCButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IoCButton.Location = new System.Drawing.Point(3, 3);
            this.IoCButton.Name = "IoCButton";
            this.IoCButton.Size = new System.Drawing.Size(260, 154);
            this.IoCButton.TabIndex = 0;
            this.IoCButton.Text = "Indicators of Compromise";
            this.IoCButton.UseVisualStyleBackColor = true;
            this.IoCButton.Click += new System.EventHandler(this.IoCButton_Click);
            // 
            // ResetMapButton
            // 
            this.ResetMapButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetMapButton.Location = new System.Drawing.Point(269, 3);
            this.ResetMapButton.Name = "ResetMapButton";
            this.ResetMapButton.Size = new System.Drawing.Size(260, 154);
            this.ResetMapButton.TabIndex = 1;
            this.ResetMapButton.Text = "Reset map";
            this.ResetMapButton.UseVisualStyleBackColor = true;
            this.ResetMapButton.Click += new System.EventHandler(this.ResetMapButton_Click);
            // 
            // ClearListButton
            // 
            this.ClearListButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearListButton.Location = new System.Drawing.Point(535, 3);
            this.ClearListButton.Name = "ClearListButton";
            this.ClearListButton.Size = new System.Drawing.Size(262, 154);
            this.ClearListButton.TabIndex = 2;
            this.ClearListButton.Text = "Clear list";
            this.ClearListButton.UseVisualStyleBackColor = true;
            this.ClearListButton.Click += new System.EventHandler(this.ClearListButton_Click);
            // 
            // IPDataList
            // 
            this.IPDataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IPDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IPDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPDataList.Location = new System.Drawing.Point(0, 0);
            this.IPDataList.Name = "IPDataList";
            this.IPDataList.RowHeadersWidth = 51;
            this.IPDataList.RowTemplate.Height = 24;
            this.IPDataList.Size = new System.Drawing.Size(454, 664);
            this.IPDataList.TabIndex = 0;
            this.IPDataList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.IPDataList_CellContentClick);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1258, 664);
            this.Controls.Add(this.MainSplitContainer);
            this.Name = "MainForm";
            this.Text = "IP Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainSplitContainer.Panel1.ResumeLayout(false);
            this.MainSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).EndInit();
            this.MainSplitContainer.ResumeLayout(false);
            this.MapButtonsSplitContainer.Panel1.ResumeLayout(false);
            this.MapButtonsSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonsSplitContainer)).EndInit();
            this.MapButtonsSplitContainer.ResumeLayout(false);
            this.ButtonLayout.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IPDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer MapButtonsSplitContainer;
        private System.Windows.Forms.DataGridView IPDataList;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.TableLayoutPanel ButtonLayout;
        private System.Windows.Forms.Button ClearListButton;
        private System.Windows.Forms.Button ResetMapButton;
        private System.Windows.Forms.Button IoCButton;
    }
}

