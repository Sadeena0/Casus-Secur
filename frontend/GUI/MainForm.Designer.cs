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
            this.MainSplit = new System.Windows.Forms.SplitContainer();
            this.MapButtonsSplit = new System.Windows.Forms.SplitContainer();
            this.Map = new GMap.NET.WindowsForms.GMapControl();
            this.ButtonLayout = new System.Windows.Forms.TableLayoutPanel();
            this.ClearListBtn = new System.Windows.Forms.Button();
            this.ResetMapBtn = new System.Windows.Forms.Button();
            this.InputOptionsBox = new System.Windows.Forms.GroupBox();
            this.ClearSelectionBtn = new System.Windows.Forms.Button();
            this.InputRemoteTextBox = new System.Windows.Forms.TextBox();
            this.InputBtnRemote = new System.Windows.Forms.RadioButton();
            this.InputBtnLocal = new System.Windows.Forms.RadioButton();
            this.IPDataList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).BeginInit();
            this.MainSplit.Panel1.SuspendLayout();
            this.MainSplit.Panel2.SuspendLayout();
            this.MainSplit.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonsSplit)).BeginInit();
            this.MapButtonsSplit.Panel1.SuspendLayout();
            this.MapButtonsSplit.Panel2.SuspendLayout();
            this.MapButtonsSplit.SuspendLayout();
            this.ButtonLayout.SuspendLayout();
            this.InputOptionsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // MainSplit
            // 
            this.MainSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainSplit.Location = new System.Drawing.Point(0, 0);
            this.MainSplit.Name = "MainSplit";
            // 
            // MainSplit.Panel1
            // 
            this.MainSplit.Panel1.Controls.Add(this.MapButtonsSplit);
            // 
            // MainSplit.Panel2
            // 
            this.MainSplit.Panel2.Controls.Add(this.IPDataList);
            this.MainSplit.Size = new System.Drawing.Size(1280, 720);
            this.MainSplit.SplitterDistance = 813;
            this.MainSplit.TabIndex = 0;
            // 
            // MapButtonsSplit
            // 
            this.MapButtonsSplit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MapButtonsSplit.Location = new System.Drawing.Point(0, 0);
            this.MapButtonsSplit.Name = "MapButtonsSplit";
            this.MapButtonsSplit.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // MapButtonsSplit.Panel1
            // 
            this.MapButtonsSplit.Panel1.Controls.Add(this.Map);
            // 
            // MapButtonsSplit.Panel2
            // 
            this.MapButtonsSplit.Panel2.Controls.Add(this.ButtonLayout);
            this.MapButtonsSplit.Size = new System.Drawing.Size(813, 720);
            this.MapButtonsSplit.SplitterDistance = 542;
            this.MapButtonsSplit.TabIndex = 0;
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
            this.ButtonLayout.Controls.Add(this.ClearListBtn, 2, 0);
            this.ButtonLayout.Controls.Add(this.ResetMapBtn, 1, 0);
            this.ButtonLayout.Controls.Add(this.InputOptionsBox, 0, 0);
            this.ButtonLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ButtonLayout.Location = new System.Drawing.Point(0, 0);
            this.ButtonLayout.Name = "ButtonLayout";
            this.ButtonLayout.RowCount = 1;
            this.ButtonLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ButtonLayout.Size = new System.Drawing.Size(813, 174);
            this.ButtonLayout.TabIndex = 0;
            // 
            // ClearListBtn
            // 
            this.ClearListBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ClearListBtn.Location = new System.Drawing.Point(545, 3);
            this.ClearListBtn.Name = "ClearListBtn";
            this.ClearListBtn.Size = new System.Drawing.Size(265, 168);
            this.ClearListBtn.TabIndex = 2;
            this.ClearListBtn.Text = "Clear list";
            this.ClearListBtn.UseVisualStyleBackColor = true;
            this.ClearListBtn.Click += new System.EventHandler(this.ClearListButton_Click);
            // 
            // ResetMapBtn
            // 
            this.ResetMapBtn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ResetMapBtn.Location = new System.Drawing.Point(274, 3);
            this.ResetMapBtn.Name = "ResetMapBtn";
            this.ResetMapBtn.Size = new System.Drawing.Size(265, 168);
            this.ResetMapBtn.TabIndex = 1;
            this.ResetMapBtn.Text = "Reset map";
            this.ResetMapBtn.UseVisualStyleBackColor = true;
            this.ResetMapBtn.Click += new System.EventHandler(this.ResetMapButton_Click);
            // 
            // InputOptionsBox
            // 
            this.InputOptionsBox.Controls.Add(this.ClearSelectionBtn);
            this.InputOptionsBox.Controls.Add(this.InputRemoteTextBox);
            this.InputOptionsBox.Controls.Add(this.InputBtnRemote);
            this.InputOptionsBox.Controls.Add(this.InputBtnLocal);
            this.InputOptionsBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InputOptionsBox.Location = new System.Drawing.Point(3, 3);
            this.InputOptionsBox.Name = "InputOptionsBox";
            this.InputOptionsBox.Size = new System.Drawing.Size(265, 168);
            this.InputOptionsBox.TabIndex = 3;
            this.InputOptionsBox.TabStop = false;
            this.InputOptionsBox.Text = "Input Options";
            // 
            // ClearSelectionBtn
            // 
            this.ClearSelectionBtn.Location = new System.Drawing.Point(9, 136);
            this.ClearSelectionBtn.Name = "ClearSelectionBtn";
            this.ClearSelectionBtn.Size = new System.Drawing.Size(250, 23);
            this.ClearSelectionBtn.TabIndex = 3;
            this.ClearSelectionBtn.Text = "Clear selection";
            this.ClearSelectionBtn.UseVisualStyleBackColor = true;
            this.ClearSelectionBtn.Click += new System.EventHandler(this.ClearSelectionBtn_Click);
            // 
            // InputRemoteTextBox
            // 
            this.InputRemoteTextBox.Enabled = false;
            this.InputRemoteTextBox.ForeColor = System.Drawing.Color.Gray;
            this.InputRemoteTextBox.Location = new System.Drawing.Point(35, 85);
            this.InputRemoteTextBox.Name = "InputRemoteTextBox";
            this.InputRemoteTextBox.Size = new System.Drawing.Size(224, 22);
            this.InputRemoteTextBox.TabIndex = 2;
            this.InputRemoteTextBox.Text = "Enter IP address";
            this.InputRemoteTextBox.Enter += new System.EventHandler(this.InputRemoteTextBox_Enter);
            this.InputRemoteTextBox.Leave += new System.EventHandler(this.InputRemoteTextBox_Leave);
            // 
            // InputBtnRemote
            // 
            this.InputBtnRemote.AutoSize = true;
            this.InputBtnRemote.Location = new System.Drawing.Point(9, 55);
            this.InputBtnRemote.Name = "InputBtnRemote";
            this.InputBtnRemote.Size = new System.Drawing.Size(76, 20);
            this.InputBtnRemote.TabIndex = 1;
            this.InputBtnRemote.TabStop = true;
            this.InputBtnRemote.Text = "Remote";
            this.InputBtnRemote.UseVisualStyleBackColor = true;
            this.InputBtnRemote.CheckedChanged += new System.EventHandler(this.InputButtonRemote_CheckedChanged);
            // 
            // InputBtnLocal
            // 
            this.InputBtnLocal.AutoSize = true;
            this.InputBtnLocal.Checked = true;
            this.InputBtnLocal.Location = new System.Drawing.Point(9, 25);
            this.InputBtnLocal.Name = "InputBtnLocal";
            this.InputBtnLocal.Size = new System.Drawing.Size(61, 20);
            this.InputBtnLocal.TabIndex = 0;
            this.InputBtnLocal.TabStop = true;
            this.InputBtnLocal.Text = "Local";
            this.InputBtnLocal.UseVisualStyleBackColor = true;
            this.InputBtnLocal.CheckedChanged += new System.EventHandler(this.InputButtonLocal_CheckedChanged);
            // 
            // IPDataList
            // 
            this.IPDataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IPDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IPDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPDataList.Location = new System.Drawing.Point(0, 0);
            this.IPDataList.MultiSelect = false;
            this.IPDataList.Name = "IPDataList";
            this.IPDataList.RowHeadersVisible = false;
            this.IPDataList.RowHeadersWidth = 51;
            this.IPDataList.RowTemplate.Height = 24;
            this.IPDataList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.IPDataList.Size = new System.Drawing.Size(463, 720);
            this.IPDataList.TabIndex = 0;
            this.IPDataList.SelectionChanged += new System.EventHandler(this.IpAddressList_OnRowSelected);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.MainSplit);
            this.Name = "MainForm";
            this.Text = "IP Tracker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.MainSplit.Panel1.ResumeLayout(false);
            this.MainSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MainSplit)).EndInit();
            this.MainSplit.ResumeLayout(false);
            this.MapButtonsSplit.Panel1.ResumeLayout(false);
            this.MapButtonsSplit.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MapButtonsSplit)).EndInit();
            this.MapButtonsSplit.ResumeLayout(false);
            this.ButtonLayout.ResumeLayout(false);
            this.InputOptionsBox.ResumeLayout(false);
            this.InputOptionsBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.IPDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer MainSplit;
        private System.Windows.Forms.SplitContainer MapButtonsSplit;
        private System.Windows.Forms.DataGridView IPDataList;
        private GMap.NET.WindowsForms.GMapControl Map;
        private System.Windows.Forms.TableLayoutPanel ButtonLayout;
        private System.Windows.Forms.Button ClearListBtn;
        private System.Windows.Forms.Button ResetMapBtn;
        private System.Windows.Forms.GroupBox InputOptionsBox;
        private System.Windows.Forms.TextBox InputRemoteTextBox;
        private System.Windows.Forms.RadioButton InputBtnRemote;
        private System.Windows.Forms.RadioButton InputBtnLocal;
        private System.Windows.Forms.Button ClearSelectionBtn;
    }
}

