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
using GMap.NET.MapProviders;

namespace GUI {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadIPAdresList();
            Init_Map();
        }

        private void Init_Map() {
            // Initialize GMap.NET
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Set map properties
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.Position = new PointLatLng(50.88, 5.96);
            Map.MinZoom = 1;
            Map.MaxZoom = 15;
            Map.Zoom = 3;
            Map.ShowCenter = false;
            Map.DragButton = MouseButtons.Left;
        }


        private void LoadIPAdresList() {
            try {
                string connectionString =
                    $"Data Source={Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName}\\backend\\connections.db";

                // Get data from database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                    connection.Open();

                    string query = "SELECT ip, appname, times, location FROM ip_addresses";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    IPDataList.DataSource = dt;
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        private void IPDataList_CellContentClick(object sender, DataGridViewCellEventArgs e) { }

        private void button1_Click(object sender, EventArgs e)
        {
            IoC secondForm = new IoC();
            secondForm.Show();
        }
    }
}