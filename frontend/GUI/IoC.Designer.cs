namespace GUI
{
    partial class IoC
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
            this.IoCDataList = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.IoCDataList)).BeginInit();
            this.SuspendLayout();
            // 
            // IoCDataList
            // 
            this.IoCDataList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.IoCDataList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.IoCDataList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IoCDataList.Location = new System.Drawing.Point(0, 0);
            this.IoCDataList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IoCDataList.Name = "IoCDataList";
            this.IoCDataList.RowHeadersWidth = 51;
            this.IoCDataList.RowTemplate.Height = 24;
            this.IoCDataList.Size = new System.Drawing.Size(900, 562);
            this.IoCDataList.TabIndex = 0;
            this.IoCDataList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // IoC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 562);
            this.Controls.Add(this.IoCDataList);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IoC";
            this.Text = "Indicators of Compromise";
            ((System.ComponentModel.ISupportInitialize)(this.IoCDataList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView IoCDataList;
    }
}