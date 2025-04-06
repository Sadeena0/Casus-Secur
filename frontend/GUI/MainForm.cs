using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;

namespace GUI {
    public partial class MainForm : Form 
    {
        private string connectionString = @"Data Source=C:\Users\britt\Desktop\school\HBO-ICT jaar 1\Blok 3\Security\casus\Casus-Secur\backend\connections.db";
        public MainForm() 
        {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e) 
        {
            LoadData();
        }
        private void LoadData()
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT ip, appname, times FROM ip_addresses";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, conn);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                dataGridView1.DataSource = dt;
            }
        }
    }
}
