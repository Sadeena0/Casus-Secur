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
using GMap.NET.WindowsForms.Markers;

namespace GUI {
    public partial class MainForm : Form {
        private GMapOverlay markersOverlay;
        private GMapOverlay routeOverlay;
        private readonly PointLatLng referencePoint = new PointLatLng(50.88, 5.96);

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            LoadIpAddressList();
            Init_Map();
        }

        private void Init_Map() {
            // Initialize GMap.NET
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            // Set map properties
            Map.MapProvider = GMapProviders.GoogleMap;
            Map.Position = new PointLatLng(25, 15);
            Map.MinZoom = 1;
            Map.MaxZoom = 15;
            Map.Zoom = 2;
            Map.ShowCenter = false;
            Map.DragButton = MouseButtons.Left;

            // Initialize the overlays
            routeOverlay = new GMapOverlay("routes");
            Map.Overlays.Add(routeOverlay);

            markersOverlay = new GMapOverlay("markers");
            Map.Overlays.Add(markersOverlay);

            // Add the markers
            AddReferenceMarker();
            LoadMarkersFromDatabase();
        }

        // Add own location
        private void AddReferenceMarker() {
            GMarkerGoogle referenceMarker = new GMarkerGoogle(referencePoint, GMarkerGoogleType.blue_dot);
            markersOverlay.Markers.Add(referenceMarker);
        }

        // Add all locations from database
        private void LoadMarkersFromDatabase() {
            // For now just test with fake data
            AddMarker(23.13, 113.26, true);
            AddMarker(-33.95, 18.58);
            AddMarker(34, -118.28);
        }

        // Add single marker and draw line from own location to it
        private void AddMarker(double lat, double lng, bool ioc = false) {
            PointLatLng point = new PointLatLng(lat, lng);

            GMarkerGoogle marker = new GMarkerGoogle(point,
                ioc ? GMarkerGoogleType.yellow_small : GMarkerGoogleType.green_small);

            markersOverlay.Markers.Add(marker);

            // Draw line from this point to reference point
            DrawLineToReference(point, ioc);
        }

        private void DrawLineToReference(PointLatLng destination, bool ioc) {
            List<PointLatLng> points = new List<PointLatLng> {
                destination,
                referencePoint
            };

            GMapRoute route = new GMapRoute(points, "lineToDest") {
                Stroke = new Pen(ioc ? Color.Yellow : Color.Green, 2)
            };

            routeOverlay.Routes.Add(route);
        }

        private void LoadIpAddressList() {
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

        private void IoCButton_Click(object sender, EventArgs e) {
            IoC secondForm = new IoC();
            secondForm.Show();
        }

        private void ResetMapButton_Click(object sender, EventArgs e) {
            Map.Position = new PointLatLng(25, 15);
            Map.Zoom = 2;
        }

        private void ClearListButton_Click(object sender, EventArgs e) {
            if (IPDataList.DataSource is DataTable dt) {
                dt.Clear();
            }
        }
    }
}