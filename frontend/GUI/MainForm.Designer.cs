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
            this.IPDataList = new System.Windows.Forms.DataGridView();
            this.InputOptionsBox = new System.Windows.Forms.GroupBox();
            this.InputButtonLocal = new System.Windows.Forms.RadioButton();
            this.InputButtonRemote = new System.Windows.Forms.RadioButton();
            this.InputRemoteTextBox = new System.Windows.Forms.TextBox();
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
            this.InputOptionsBox.SuspendLayout();
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
            this.MainSplitContainer.Size = new System.Drawing.Size(1280, 720);
            this.MainSplitContainer.SplitterDistance = 813;
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
            this.MapButtonsSplitContainer.Size = new System.Drawing.Size(813, 720);
            this.MapButtonsSplitContainer.SplitterDistance = 542;
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
            this.Map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionWithoutCenter;
            this.Map.Name = "Map";
            this.Map.NegativeMode = false;
            this.Map.PolygonsEnabled = true;
            this.Map.RetryLoadTile = 0;
            this.Map.RoutesEnabled = true;
            this.Map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            this.Map.SelectedAreaFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(65)))), ((int)(((byte)(105)))), ((int)(((byte)(225)))));
            this.Map.ShowTileGridLines = false;
            this.Map.Size = new System.Drawing.Size(813, 542);
            this.Map.TabIndex = 0;
            this.Map.Zoom = 2D;
            this.Map.OnMarkerClick += new GMap.NET.WindowsForms.MarkerClick(this.Map_OnMarkerClick);
            // 
            // ButtonLayout
            // 
            this.ButtonLayout.ColumnCount = 3;
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.ButtonLayout.Controls.Add(this.ClearListButton, 2, 0);
            this.ButtonLayout.Controls.Add(this.ResetMapButton, 1, 0);
            this.ButtonLayout.Controls.Add(this.InputOptionsBox, 0, 0);
            this.ButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLayout.Location = new System.Drawing.Point(0, 0);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayout.Size = new System.Drawing.Size(813, 174);
            this.ButtonLayout.TabIndex = 0;
            // 
            // ClearListButton
            // 
            this.ClearListButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearListButton.Location = new System.Drawing.Point(545, 3);
            this.ClearListButton.Name = "ClearListButton";
            this.ClearListButton.Size = new System.Drawing.Size(265, 168);
            this.ClearListButton.TabIndex = 2;
            this.ClearListButton.Text = "Clear list";
            this.ClearListButton.UseVisualStyleBackColor = true;
            this.ClearListButton.Click += new System.EventHandler(this.ClearListButton_Click);
            // 
            // ResetMapButton
            // 
            this.ResetMapButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetMapButton.Location = new System.Drawing.Point(274, 3);
            this.ResetMapButton.Name = "ResetMapButton";
            this.ResetMapButton.Size = new System.Drawing.Size(265, 168);
            this.ResetMapButton.TabIndex = 1;
            this.ResetMapButton.Text = "Reset map";
            this.ResetMapButton.UseVisualStyleBackColor = true;
            this.ResetMapButton.Click += new System.EventHandler(this.ResetMapButton_Click);
            // 
            // IPDataList
            // 
            this.IPDataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IPDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IPDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPDataList.Location = new System.Drawing.Point(0, 0);
            this.IPDataList.MultiSelect = false;
            this.IPDataList.Name = "IPDataList";
            this.IPDataList.RowHeadersWidth = 51;
            this.IPDataList.RowTemplate.Height = 24;
            this.IPDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IPDataList.Size = new System.Drawing.Size(463, 720);
            this.IPDataList.TabIndex = 0;
            this.IPDataList.SelectionChanged += new System.EventHandler(this.IpAddressList_OnRowSelected);
            // 
            // InputOptionsBox
            // 
            this.InputOptionsBox.Controls.Add(this.InputRemoteTextBox);
            this.InputOptionsBox.Controls.Add(this.InputButtonRemote);
            this.InputOptionsBox.Controls.Add(this.InputButtonLocal);
            this.InputOptionsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputOptionsBox.Location = new System.Drawing.Point(3, 3);
            this.InputOptionsBox.Name = "InputOptionsBox";
            this.InputOptionsBox.Size = new System.Drawing.Size(265, 168);
            this.InputOptionsBox.TabIndex = 3;
            this.InputOptionsBox.TabStop = false;
            this.InputOptionsBox.Text = "Input Options";
            // 
            // InputButtonLocal
            // 
            this.InputButtonLocal.AutoSize = true;
            this.InputButtonLocal.Checked = true;
            this.InputButtonLocal.Location = new System.Drawing.Point(9, 25);
            this.InputButtonLocal.Name = "InputButtonLocal";
            this.InputButtonLocal.Size = new System.Drawing.Size(72, 24);
            this.InputButtonLocal.TabIndex = 0;
            this.InputButtonLocal.TabStop = true;
            this.InputButtonLocal.Text = "Local";
            this.InputButtonLocal.UseVisualStyleBackColor = true;
            this.InputButtonLocal.CheckedChanged += new System.EventHandler(this.InputButtonLocal_CheckedChanged);
            // 
            // InputButtonRemote
            // 
            this.InputButtonRemote.AutoSize = true;
            this.InputButtonRemote.Location = new System.Drawing.Point(9, 55);
            this.InputButtonRemote.Name = "InputButtonRemote";
            this.InputButtonRemote.Size = new System.Drawing.Size(91, 24);
            this.InputButtonRemote.TabIndex = 1;
            this.InputButtonRemote.TabStop = true;
            this.InputButtonRemote.Text = "Remote";
            this.InputButtonRemote.UseVisualStyleBackColor = true;
            this.InputButtonRemote.CheckedChanged += new System.EventHandler(this.InputButtonRemote_CheckedChanged);
            // 
            // InputRemoteTextBox
            // 
            this.InputRemoteTextBox.Enabled = false;
            this.InputRemoteTextBox.ForeColor = System.Drawing.Color.Gray;
            this.InputRemoteTextBox.Location = new System.Drawing.Point(35, 85);
            this.InputRemoteTextBox.Name = "InputRemoteTextBox";
            this.InputRemoteTextBox.Size = new System.Drawing.Size(224, 26);
            this.InputRemoteTextBox.TabIndex = 2;
            this.InputRemoteTextBox.Text = "Enter IP address";
            this.InputRemoteTextBox.Enter += new System.EventHandler(this.InputRemoteTextBox_Enter);
            this.InputRemoteTextBox.Leave += new System.EventHandler(this.InputRemoteTextBox_Leave);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
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
            this.InputOptionsBox.ResumeLayout(false);
            this.InputOptionsBox.PerformLayout();
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
        private System.Windows.Forms.GroupBox InputOptionsBox;
        private System.Windows.Forms.TextBox InputRemoteTextBox;
        private System.Windows.Forms.RadioButton InputButtonRemote;
        private System.Windows.Forms.RadioButton InputButtonLocal;
    }
}

