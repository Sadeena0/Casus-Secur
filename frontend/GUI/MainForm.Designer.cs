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
            this.map = new GMap.NET.WindowsForms.GMapControl();
            this.IPDataList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplitContainer)).BeginInit();
            this.MainSplitContainer.Panel1.SuspendLayout();
            this.MainSplitContainer.Panel2.SuspendLayout();
            this.MainSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonsSplitContainer)).BeginInit();
            this.MapButtonsSplitContainer.Panel1.SuspendLayout();
            this.MapButtonsSplitContainer.SuspendLayout();
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
            this.MapButtonsSplitContainer.Panel1.Controls.Add(this.map);
            this.MapButtonsSplitContainer.Size = new System.Drawing.Size(800, 664);
            this.MapButtonsSplitContainer.SplitterDistance = 390;
            this.MapButtonsSplitContainer.TabIndex = 0;
            // 
            // map
            // 
            this.map.Bearing = 0F;
            this.map.CanDragMap = true;
            this.map.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map.EmptyTileColor = System.Drawing.Color.Navy;
            this.map.GrayScaleMode = false;
            this.map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            this.map.LevelsKeepInMemmory = 5;
            this.map.Location = new System.Drawing.Point(0, 0);
            this.map.MarkersEnabled = true;
            this.map.MaxZoom = 2;
            this.map.MinZoom = 2;
            this.map.MouseWheelZoomEnabled = true;
            this.map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            this.map.Name = "map";
            this.map.NegativeMode = false;
            this.map.PolygonsEnabled = true;
            this.map.RetryLoadTile = 0;
            this.map.RoutesEnabled = true;
            this.map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.map.ShowTileGridLines = false;
            this.map.Size = new System.Drawing.Size(800, 390);
            this.map.TabIndex = 0;
            this.map.Zoom = 0D;
            // 
            // IPDataList
            // 
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
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonsSplitContainer)).EndInit();
            this.MapButtonsSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.IPDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplitContainer;
        private System.Windows.Forms.SplitContainer MapButtonsSplitContainer;
        private System.Windows.Forms.DataGridView IPDataList;
        private GMap.NET.WindowsForms.GMapControl map;
    }
}

