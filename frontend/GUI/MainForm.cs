﻿using GMap.NET.WindowsForms;
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

            Init_Map();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadIPAdresList();
        }

        private void Init_Map() {
            // Initialize GMap.NET
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Set map properties
            map.MapProvider = GMapProviders.GoogleMap;
            map.Position = new PointLatLng(50.88, 5.96);
            map.MinZoom = 1;
            map.MaxZoom = 15;
            map.Zoom = 3;
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
        }


        private void LoadIPAdresList() {
            string connectionString =
                @"Data Source=C:\Users\Tygo van Eerd\OneDrive - Zuyd Hogeschool\P1.3\Casus Secur\backend\connections.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                connection.Open();

                string query = "SELECT ip, appname, times FROM ip_addresses";
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                IPDataList.DataSource = dt;
            }
        }

        private void IPDataList_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
    }
}