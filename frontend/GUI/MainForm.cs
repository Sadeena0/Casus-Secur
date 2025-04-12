using GMap.NET.WindowsForms;
using GMap.NET;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SQLite;
using System.IO;
using System.Net;
using System.Net.Http;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace GUI {
    public partial class MainForm : Form {
        private GMapOverlay markersOverlay;
        private GMapOverlay routeOverlay;
        private DataTable dt = new DataTable();

        private readonly PointLatLng referencePoint = new PointLatLng(50.88, 5.96);

        private readonly HashSet<string> IoCList = new HashSet<string>(
            File.ReadAllLines($"..\\..\\..\\GUI\\blacklist.txt")
        );

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            Init_Map();

            // Draw initial markers
            UpdateIpAddressList();
            UpdateMarkersFromDataTable();

            // Start update loop
            Timer updateTimer = new Timer();
            updateTimer.Interval = 1000; // 1000ms = 1 second
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        // Update loop
        private void UpdateTimer_Tick(object sender, EventArgs e) {
            Console.Write("Updating... ");

            // Update IpAdDressList
            UpdateIpAddressList();

            // Update markers
            UpdateMarkersFromDataTable();
        }

        // Initialize map
        private void Init_Map() {
            // Initialize GMap.NET
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Set map properties
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.Position = new PointLatLng(25, 15);
            Map.MinZoom = 2;
            Map.MaxZoom = 15;
            Map.Zoom = 2;
            Map.ShowCenter = false;
            Map.DragButton = MouseButtons.Left;
        }

        // Update IP data list
        private void UpdateIpAddressList() {
            // Save UI state
            int scrollIndex = Math.Max(IPDataList.FirstDisplayedScrollingRowIndex, 0);
            string selectedIp = IPDataList.CurrentRow?.Cells["ip"]?.Value?.ToString();
            string sortColumn = IPDataList.SortedColumn?.Name;
            ListSortDirection sortDirection = IPDataList.SortOrder == SortOrder.Descending
                ? ListSortDirection.Descending
                : ListSortDirection.Ascending;

            dt = new DataTable();

            // Get data locally or remotely
            try {
                if(InputButtonLocal.Checked) {
                    Console.WriteLine("Getting data from local");

                    string connectionString =
                        $"Data Source=..\\..\\..\\..\\backend\\connections.db";

                    // Get data from database
                    using(SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                        connection.Open();

                        // Fill data into new DataTable
                        string query = "SELECT ip, appname, times, location, lat, lon FROM ip_addresses";
                        new SQLiteDataAdapter(query, connection).Fill(dt);
                    }
                } else if(InputButtonRemote.Checked) {
                    Console.WriteLine("Getting data from remote");

                    string targetIP = InputRemoteTextBox.Text;

                    // Verify if valid IP Address
                    if(IPAddress.TryParse(targetIP, out _)) {
                        string key = File.ReadAllText("..\\..\\..\\GUI\\.env");
                        key = key.Substring(9, key.Length - 10);

                        // Make client, send request and save response
                        HttpClient client = new HttpClient();
                        HttpResponseMessage response =
                            client.GetAsync($"http://{targetIP}:5000/getdb?key={key}").Result;

                        // Parse into array of arrays
                        var jsonArray =
                            JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync().Result);

                        // Create Datatable with columns
                        dt.Columns.Add("ip", typeof(string));
                        dt.Columns.Add("appname", typeof(string));
                        dt.Columns.Add("times", typeof(int));
                        dt.Columns.Add("location", typeof(string));
                        dt.Columns.Add("lat", typeof(double));
                        dt.Columns.Add("lon", typeof(double));

                        // Populate DataTable
                        foreach(var item in jsonArray) {
                            string ip = item[0]?.ToString() ?? "Unknown IP";
                            string appname = item[3]?.ToString() ?? "Unknown App";
                            string location = item[4]?.ToString() ?? "Unknown Location";
                            int.TryParse(item[5]?.ToString(), out int times);
                            double.TryParse(item[6]?.ToString(), out double lat);
                            double.TryParse(item[7]?.ToString(), out double lng);

                            dt.Rows.Add(ip, appname, times, location, lat, lng);
                        }

                        client.Dispose();
                    }
                }

                // Fill DataTable into DataGridView but hide Lat and Lon columns
                IPDataList.DataSource = dt;

                if(IPDataList.Columns.Contains("lat")) IPDataList.Columns["lat"].Visible = false;
                if(IPDataList.Columns.Contains("lon")) IPDataList.Columns["lon"].Visible = false;
            } catch(Exception e) {
                Console.WriteLine(e);
            }

            // Restore UI state
            if(scrollIndex < IPDataList.Rows.Count)
                IPDataList.FirstDisplayedScrollingRowIndex = scrollIndex;

            if(!string.IsNullOrEmpty(selectedIp)) {
                foreach(DataGridViewRow row in IPDataList.Rows) {
                    if(row.Cells["ip"].Value?.ToString() == selectedIp) {
                        row.Selected = true;
                        IPDataList.CurrentCell = row.Cells[0];
                        IpAddressList_OnRowSelected(row, EventArgs.Empty); // <--
                        break;
                    }
                }
            }

            if(!string.IsNullOrEmpty(sortColumn)) {
                IPDataList.Sort(IPDataList.Columns[sortColumn], sortDirection);
            }
        }

        // Update markers from internal DataTable
        private void UpdateMarkersFromDataTable() {
            // Clear all overlays from the map
            Map.Overlays.Clear();

            // Create fresh overlays
            routeOverlay = new GMapOverlay("routes");
            markersOverlay = new GMapOverlay("markers");

            // Add overlays to map
            Map.Overlays.Add(routeOverlay);
            Map.Overlays.Add(markersOverlay);

            // Add own location first
            GMarkerGoogle referenceMarker = new GMarkerGoogle(referencePoint, GMarkerGoogleType.blue_dot);
            markersOverlay.Markers.Add(referenceMarker);

            // Read all rows from DataTable and draw markers
            foreach (DataRow row in dt.Rows) {
                string ip = row["ip"]?.ToString();

                if (double.TryParse(row["lat"]?.ToString(), out double lat) &&
                    double.TryParse(row["lon"]?.ToString(), out double lon)) {
                    AddMarker(lat, lon, IoCList.Contains(ip));
                }
            }
        }

        private void AddMarker(double lat, double lng, bool isIoC = false) {
            PointLatLng point = new PointLatLng(lat, lng);

            GMarkerGoogle marker = new GMarkerGoogle(point,
                isIoC ? GMarkerGoogleType.red_small : GMarkerGoogleType.green_small);

            // Add Tag for marker clicks
            marker.Tag = new { Lat = lat, Lng = lng };

            markersOverlay.Markers.Add(marker);

            DrawLineToReference(point, isIoC);
        }

        private void DrawLineToReference(PointLatLng destination, bool isIoC) {
            List<PointLatLng> points = new List<PointLatLng> {
                referencePoint,
                destination
            };

            GMapRoute route = new GMapRoute(points, "lineToDest") {
                Stroke = new Pen(isIoC ? Color.Red : Color.Green, 2)
            };

            routeOverlay.Routes.Add(route);
        }

        // Onclick events
        private void IpAddressList_OnRowSelected(object sender, EventArgs e) {
            if (IPDataList.SelectedRows.Count == 0 || markersOverlay == null) {
                return;
            }

            DataGridViewRow row = IPDataList.SelectedRows[0];

            // Check if row contains coordinates
            if (row.Cells["lat"].Value == DBNull.Value || row.Cells["lon"].Value == DBNull.Value)
                return;

            double lat = Convert.ToDouble(row.Cells["lat"].Value);
            double lng = Convert.ToDouble(row.Cells["lon"].Value);

            // Update the corresponding marker
            for (int i = 0; i < markersOverlay.Markers.Count; i++) {
                GMapMarker marker = markersOverlay.Markers[i];

                if (marker.Position.Lat == lat && marker.Position.Lng == lng) {
                    markersOverlay.Markers[i] = new GMarkerGoogle(marker.Position, GMarkerGoogleType.blue_dot);
                }
            }
        }

        private void Map_OnMarkerClick(GMapMarker item, MouseEventArgs e) {
            // Retrieve coordinates
            var coordinates = item.Tag as dynamic;
            double lat = coordinates.Lat;
            double lng = coordinates.Lng;

            // Highlight correct row in DataGridView
            foreach (DataGridViewRow row in IPDataList.Rows) {
                double rowLat = Convert.ToDouble(row.Cells["lat"].Value);
                double rowLng = Convert.ToDouble(row.Cells["lon"].Value);

                // If lat/lng match, select and highlight the row
                if (rowLat == lat && rowLng == lng) {
                    row.Selected = true;
                    IPDataList.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void ResetMapButton_Click(object sender, EventArgs e) {
            Console.Write("Resetting map...");

            Map.Position = new PointLatLng(25, 15);
            Map.Zoom = 2;
        }

        private void ClearListButton_Click(object sender, EventArgs e) {
            string key = File.ReadAllText("..\\..\\..\\GUI\\.env");
            key = key.Substring(9, key.Length - 10);

            Console.WriteLine("Clearing IP Data list...");

            HttpClient client = new HttpClient {
                BaseAddress = new Uri($"http://127.0.0.1:5000/cleardb?key={key}")
            };

            HttpResponseMessage response = client.PostAsync($"http://127.0.0.1:5000/cleardb?key={key}", null).Result;

            client.Dispose();
        }

        private void InputButtonLocal_CheckedChanged(object sender, EventArgs e) {
            if (InputButtonLocal.Checked) {
                InputRemoteTextBox.Enabled = false;
            }
        }

        private void InputButtonRemote_CheckedChanged(object sender, EventArgs e) {
            if (InputButtonRemote.Checked) {
                InputRemoteTextBox.Enabled = true;
            }
        }

        private void InputRemoteTextBox_Enter(object sender, EventArgs e) {
            // If the user hasn't typed anything yet, clear the hint text
            if (InputRemoteTextBox.Text == "Enter IP address") {
                InputRemoteTextBox.Text = "";
                InputRemoteTextBox.ForeColor = Color.Black;
            }
        }

        private void InputRemoteTextBox_Leave(object sender, EventArgs e) {
            // If the user leaves the textbox empty, restore the hint text
            if (string.IsNullOrWhiteSpace(InputRemoteTextBox.Text)) {
                InputRemoteTextBox.Text = "Enter IP address";
                InputRemoteTextBox.ForeColor = Color.Gray;
            }
        }
    }
}