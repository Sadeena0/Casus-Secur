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

        private DataTable dt = new DataTable();

        private readonly HashSet<string> IoCList = new HashSet<string>(
            File.ReadAllLines($"..\\..\\..\\GUI\\blacklist.txt")
        );

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            Init_Map();

            // Draw initial markers
            UpdateMarkersFromDatabase();
            UpdateIpAddressList();

            Timer updateTimer = new Timer();
            updateTimer.Interval = 1000; // 1000ms = 1 second
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        private void UpdateTimer_Tick(object sender, EventArgs e) {
            Console.WriteLine("Updating...");

            // Update IpAdDressList
            UpdateIpAddressList();

            // Update markers
            UpdateMarkersFromDatabase();
        }


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

        // Add all locations from database
        private void UpdateMarkersFromDatabase() {
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

        // Add single marker
        private void AddMarker(double lat, double lng, bool isIoC = false) {
            PointLatLng point = new PointLatLng(lat, lng);

            GMarkerGoogle marker = new GMarkerGoogle(point,
                isIoC ? GMarkerGoogleType.red_small : GMarkerGoogleType.green_small);

            markersOverlay.Markers.Add(marker);

            // Draw line from this point to reference point
            DrawLineToReference(point, isIoC);
        }

        // Draw line from referencepoint to marker
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

        // Update IP data list
        private void UpdateIpAddressList() {
            // Clear list
            dt = new DataTable();

            try {
                string connectionString =
                    $"Data Source={Directory.GetParent(Application.StartupPath).Parent.Parent.Parent.FullName}\\backend\\connections.db";

                // Get data from database
                using (SQLiteConnection connection = new SQLiteConnection(connectionString)) {
                    connection.Open();

                    string query = "SELECT ip, appname, times, location, lat, lon FROM ip_addresses";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                    adapter.Fill(dt);

                    // Fill data into DataGridView but hide Lat and Lon columns
                    IPDataList.DataSource = dt;
                    IPDataList.Columns["lat"].Visible = false;
                    IPDataList.Columns["lon"].Visible = false;
                }
            } catch (Exception e) {
                Console.WriteLine(e);
            }
        }

        // Onclick events
        private void IoCButton_Click(object sender, EventArgs e) {
            Console.WriteLine("Opening IoC window...");

            IoC secondForm = new IoC();
            secondForm.Show();
        }

        private void ResetMapButton_Click(object sender, EventArgs e) {
            Console.Write("Resetting map...");

            Map.Position = new PointLatLng(25, 15);
            Map.Zoom = 2;
        }

        private void ClearListButton_Click(object sender, EventArgs e) {
            Console.WriteLine("Clearing IP Data list...");

            dt.Clear();
        }
    }
}