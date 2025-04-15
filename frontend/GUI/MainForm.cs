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
        // Initializer constants
        private const int DefaultZoom = 2;

        // Updater constants
        private const int UpdateIntervalMs = 1000; // 1000ms = 1 second
        private const string LocalDbPath = @"..\\..\\..\\..\\backend\\connections.db";
        private const string ApiKeyPath = @"..\\..\\..\\GUI\\.env";

        // Map stuff
        private GMapOverlay markersOverlay;
        private GMapOverlay routeOverlay;
        private (double lat, double lng)? selectedMarkerCoords;
        private readonly PointLatLng referencePoint = new PointLatLng(50.88, 5.96);

        private readonly HashSet<string> IoCList = new HashSet<string>(
            File.ReadAllLines($"..\\..\\..\\GUI\\blacklist.txt")
        );

        // IPDataList stuff
        private DataTable dt = new DataTable();
        private bool suppressSelectionEvent;
        private string selectedIp;

        public MainForm() {
            InitializeComponent();
        }

        // Initializers
        private void MainForm_Load(object sender, EventArgs e) {
            Init_Map();

            // Draw initial markers
            UpdateIpAddressList();
            UpdateMarkersFromDataTable();

            // Start update loop
            Timer updateTimer = new Timer();
            updateTimer.Interval = UpdateIntervalMs;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        private void Init_Map() {
            // Initialize GMap.NET
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Set map properties
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.Position = new PointLatLng(25, 15);
            Map.MinZoom = 2;
            Map.MaxZoom = 15;
            Map.Zoom = DefaultZoom;
            Map.ShowCenter = false;
            Map.DragButton = MouseButtons.Left;
        }

        // Update loop
        private void UpdateTimer_Tick(object sender, EventArgs e) {
            System.Diagnostics.Debug.Write($"[{DateTime.Now:HH:mm:ss}] Updating... ");

            // Update IpAdDressList
            UpdateIpAddressList();

            // Update markers
            UpdateMarkersFromDataTable();
        }

        // Updaters
        private void UpdateIpAddressList() {
            suppressSelectionEvent = true; //suppress row select triggers

            IPDataList.SuspendLayout();

            try {
                // Save UI state
                string sortColumn = IPDataList.SortedColumn?.Name;
                ListSortDirection sortDirection = IPDataList.SortOrder == SortOrder.Descending
                    ? ListSortDirection.Descending
                    : ListSortDirection.Ascending;
                int scrollIndex = Math.Max(IPDataList.FirstDisplayedScrollingRowIndex, 0);

                // Create DataTable
                dt = new DataTable();
                dt.Columns.Add("ip", typeof(string));
                dt.Columns.Add("appname", typeof(string));
                dt.Columns.Add("times", typeof(int));
                dt.Columns.Add("location", typeof(string));
                dt.Columns.Add("lat", typeof(double));
                dt.Columns.Add("lon", typeof(double));
                dt.Columns.Add("sent", typeof(long));

                // Get data locally or remotely
                try {
                    if (InputBtnLocal.Checked) {
                        System.Diagnostics.Debug.WriteLine("Getting data from local");

                        string connectionString = $"Data Source={LocalDbPath}";

                        // Get data from database
                        using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                            connection.Open();

                            // Fill data into new DataTable
                            string query = "SELECT ip, appname, times, location, lat, lon, sent FROM ip_addresses";

                            using (SQLiteCommand cmd = new SQLiteCommand(query, connection)) {
                                using (SQLiteDataReader reader = cmd.ExecuteReader()) {
                                    while (reader.Read()) {
                                        if (!reader.IsDBNull(reader.GetOrdinal("lat")) &&
                                            !reader.IsDBNull(reader.GetOrdinal("lon"))) {
                                            string ip = reader["ip"]?.ToString() ?? "Unknown IP";
                                            string appname = reader["appname"]?.ToString() ?? "Unknown App";
                                            string location = reader["location"]?.ToString() ?? "Unknown Location";
                                            double lat = Convert.ToDouble(reader["lat"]);
                                            double lng = Convert.ToDouble(reader["lon"]);
                                            int times = reader.GetInt32(reader.GetOrdinal("times"));
                                            long sent = reader.GetInt64(reader.GetOrdinal("sent"));

                                            dt.Rows.Add(ip, appname, times, location, lat, lng, sent);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else if (InputBtnRemote.Checked) {
                        System.Diagnostics.Debug.WriteLine("Getting data from remote");

                        string targetIp = InputRemoteTextBox.Text;

                        // Verify if valid IP Address
                        if (IPAddress.TryParse(targetIp, out _)) {
                            string key = File.ReadAllText(ApiKeyPath);
                            key = key.Substring(9, key.Length - 10);

                            // Make client, send request and save response
                            using (HttpClient client = new HttpClient()) {
                                using (HttpResponseMessage response =
                                       client.GetAsync($"http://{targetIp}:5000/getdb?key={key}").Result) {
                                    // Parse into array of arrays
                                    var jsonArray =
                                        JsonConvert.DeserializeObject<JArray>(response.Content.ReadAsStringAsync()
                                            .Result);

                                    // Populate DataTable
                                    foreach (var row in jsonArray) {
                                        string ip = row[0]?.ToString() ?? "Unknown IP";
                                        string appname = row[3]?.ToString() ?? "Unknown App";
                                        string location = row[4]?.ToString() ?? "Unknown Location";
                                        int.TryParse(row[5]?.ToString(), out int times);
                                        double.TryParse(row[6]?.ToString(), out double lat);
                                        double.TryParse(row[7]?.ToString(), out double lng);
                                        long.TryParse(row[8]?.ToString(), out long sent);

                                        dt.Rows.Add(ip, appname, times, location, lat, lng, sent);
                                    }
                                }
                            }
                        }
                    }

                    // Create extra prettified column
                    if (!dt.Columns.Contains("sent_pretty")) dt.Columns.Add("sent_pretty", typeof(string));

                    // Copy sent into new column, but make it pretty :3
                    foreach (DataRow row in dt.Rows) {
                        if (row["sent"] != DBNull.Value) {
                            long sent = (long)row["sent"];

                            row["sent_pretty"] = sent >= 1_000_000_000
                                ? $"{sent / 1_000_000_000.0:F1} GB"
                                : sent >= 1_000_000
                                    ? $"{sent / 1_000_000:F1} MB"
                                    : $"{sent / 1_000:F1} kB";
                        }
                    }

                    // Fill DataTable into DataGridView but hide Lat and Lon columns
                    IPDataList.DataSource = dt;
                    if (IPDataList.Columns.Contains("lat")) IPDataList.Columns["lat"].Visible = false;
                    if (IPDataList.Columns.Contains("lon")) IPDataList.Columns["lon"].Visible = false;
                } catch (Exception e) {
                    Console.WriteLine(e);
                } finally {
                    // Restore UI state
                    bool restoredSelection = false;

                    if (!string.IsNullOrEmpty(sortColumn)) {
                        IPDataList.Sort(IPDataList.Columns[sortColumn], sortDirection);
                    }

                    if (!string.IsNullOrEmpty(selectedIp)) {
                        foreach (DataGridViewRow row in IPDataList.Rows) {
                            if (row.Cells["ip"].Value?.ToString() == selectedIp) {
                                row.Selected = true;
                                IPDataList.CurrentCell = row.Cells[0];
                                restoredSelection = true;
                                break;
                            }
                        }
                    }

                    if (scrollIndex < IPDataList.Rows.Count) {
                        IPDataList.FirstDisplayedScrollingRowIndex = scrollIndex;
                    }

                    // If no selection was restored (so nothing was selected), clear default selection (first row)
                    if (!restoredSelection) {
                        IPDataList.ClearSelection();
                        IPDataList.CurrentCell = null;
                    }
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            } finally {
                suppressSelectionEvent = false; // re-enable triggers
                IPDataList.ResumeLayout();
            }
        }

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
                double lat = (double)row["lat"];
                double lng = (double)row["lon"];
                string ip = row["ip"]?.ToString();
                long sent = (long)row["sent"];

                AddMarker(lat, lng, IoCList.Contains(ip), sent);
            }
        }

        private void AddMarker(double lat, double lng, bool isIoC, long sentBytes) {
            PointLatLng point = new PointLatLng(lat, lng);

            bool isSelected = selectedMarkerCoords.HasValue && selectedMarkerCoords.Value.lat == lat &&
                              selectedMarkerCoords.Value.lng == lng;

            GMarkerGoogleType markerType = isSelected
                ? GMarkerGoogleType.blue_dot
                : isIoC
                    ? GMarkerGoogleType.red_small
                    : GMarkerGoogleType.green_small;

            GMarkerGoogle marker = new GMarkerGoogle(point, markerType);

            // Add Tag for marker clicks
            marker.Tag = new { Lat = lat, Lng = lng };

            markersOverlay.Markers.Add(marker);

            DrawLineToReference(point, sentBytes, isIoC, isSelected);
        }

        private void DrawLineToReference(PointLatLng destination, long sentBytes, bool isIoC, bool isSelected) {
            List<PointLatLng> points = new List<PointLatLng> {
                referencePoint,
                destination
            };

            Color color = isSelected
                ? Color.Blue
                : isIoC
                    ? Color.Red
                    : Color.Green;

            int width =
                sentBytes >= 1_000_000_000 // Bigger than 1 gb: width 4
                    ? 4
                    : sentBytes >= 100_000_000 // Bigger than 100 mb: width 3
                        ? 3
                        : sentBytes >= 1_000_000 // Bigger than 1 mb: width 2
                            ? 2
                            : 1;

            GMapRoute route = new GMapRoute(points, "lineToDest") {
                Stroke = new Pen(color, width)
            };

            routeOverlay.Routes.Add(route);
        }

        // Onclick events
        private void IpAddressList_OnRowSelected(object sender, EventArgs e) {
            if (suppressSelectionEvent || IPDataList.SelectedRows.Count == 0 || markersOverlay == null)
                return;

            DataGridViewRow row = IPDataList.SelectedRows[0];

            if (row.Cells["lat"].Value is double lat && row.Cells["lon"].Value is double lon) {
                selectedMarkerCoords = (lat, lon);
            }

            string ip = row.Cells["ip"].Value?.ToString();
            if (!string.IsNullOrEmpty(ip)) {
                selectedIp = ip;
            }
        }

        private void Map_OnMarkerClick(GMapMarker item, MouseEventArgs e) {
            // Retrieve coordinates
            var coordinates = item.Tag as dynamic;
            double lat = coordinates.Lat;
            double lng = coordinates.Lng;

            selectedMarkerCoords = (lat, lng);

            // Highlight correct row in DataGridView
            foreach (DataGridViewRow row in IPDataList.Rows) {
                // If lat/lng match, select and highlight the row
                if ((double)row.Cells["lat"].Value == lat && (double)row.Cells["lon"].Value == lng) {
                    string ip = row.Cells["ip"].Value?.ToString();
                    if (!string.IsNullOrEmpty(ip)) {
                        selectedIp = ip;
                    }

                    IPDataList.ClearSelection();
                    IPDataList.CurrentCell = null;
                    row.Selected = true;
                    IPDataList.FirstDisplayedScrollingRowIndex = row.Index;
                    break;
                }
            }
        }

        private void ResetMapButton_Click(object sender, EventArgs e) {
            Map.Position = new PointLatLng(25, 15);
            Map.Zoom = DefaultZoom;
        }

        private void ClearListButton_Click(object sender, EventArgs e) {
            string key = File.ReadAllText(ApiKeyPath);
            key = key.Substring(9, key.Length - 10);

            using (HttpClient client = new HttpClient()) {
                HttpResponseMessage unused =
                    client.PostAsync($"http://127.0.0.1:5000/cleardb?key={key}", null).Result;
            }
        }

        private void ClearSelectionBtn_Click(object sender, EventArgs e) {
            IPDataList.ClearSelection();
            IPDataList.CurrentCell = null;
            selectedMarkerCoords = null;
        }

        private void InputButtonLocal_CheckedChanged(object sender, EventArgs e) {
            if (InputBtnLocal.Checked) {
                InputRemoteTextBox.Enabled = false;
            }
        }

        private void InputButtonRemote_CheckedChanged(object sender, EventArgs e) {
            if (InputBtnRemote.Checked) {
                InputRemoteTextBox.Enabled = true;
            }
        }

        private void InputRemoteTextBox_Enter(object sender, EventArgs e) {
            if (InputRemoteTextBox.Text == "Enter IP address") {
                InputRemoteTextBox.Text = "";
                InputRemoteTextBox.ForeColor = Color.Black;
            }
        }

        private void InputRemoteTextBox_Leave(object sender, EventArgs e) {
            if (string.IsNullOrWhiteSpace(InputRemoteTextBox.Text)) {
                InputRemoteTextBox.Text = "Enter IP address";
                InputRemoteTextBox.ForeColor = Color.Gray;
            }
        }
    }
}