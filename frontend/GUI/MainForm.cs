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

namespace GUI {
    public partial class MainForm : Form {
        public MainForm() {
            InitializeComponent();

        }

        private void MainForm_Load(object sender, EventArgs e) {
            GMaps.Instance.Mode = AccessMode.ServerOnly;

            map.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            map.Position = new GMap.NET.PointLatLng(50.88, 5.96); // Example: Paris
            map.MinZoom = 2;
            map.MaxZoom = 18;
            map.Zoom = 10;
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
        }
    }
}
