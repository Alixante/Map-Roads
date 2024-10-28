using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;


namespace UltRoads2
{
    public partial class FolderBrowserDialog : Form
    {
        GMapOverlay roadsOverlay = new GMapOverlay("roads");
        private string selectedFolderPath; // Variable to store selected folder path
        public FolderBrowserDialog()
        {
            InitializeComponent();
            InitializeMap();
        }

        private void InitializeMap()
        {
            gMapControl1.MapProvider = GMapProviders.GoogleMap; // Choose your preferred map provider
            gMapControl1.Position = new PointLatLng(41.3851, 2.1734); // Set initial position (Barcelona)
            gMapControl1.MinZoom = 1;
            gMapControl1.MaxZoom = 20;
            gMapControl1.Zoom = 10;
        }

        private void btnLoadGeoJson_Click(object sender, EventArgs e)
        {

        }

        private void LoadGeoJson(string filePath)
        {
            string geoJson = File.ReadAllText(filePath);
            var geoJsonObject = JsonConvert.DeserializeObject<JObject>(geoJson);

            foreach (var feature in geoJsonObject["features"])
            {
                var geometry = feature["geometry"];
                if (geometry["type"].ToString() == "Point")
                {
                    var coordinates = geometry["coordinates"].ToObject<double[]>();
                    var point = new PointLatLng(coordinates[1], coordinates[0]);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_dot);
                    gMapControl1.Overlays.Add(new GMapOverlay("markers") { Markers = { marker } });
                }
                // Handle other geometry types (LineString, Polygon) as needed
            }

            gMapControl1.Refresh();
        }

        private void LoadGeoJsonToMap(string geoJsonFilePath)
        {
            try
            {
                if (!File.Exists(geoJsonFilePath))
                {
                    MessageBox.Show($"File not found: {geoJsonFilePath}");
                    return;
                }

                // Read the GeoJSON file content
                string geoJsonContent = File.ReadAllText(geoJsonFilePath);

                // Parse the GeoJSON using Newtonsoft.Json
                var geoJson = JObject.Parse(geoJsonContent);

                // Extract the features (roads)
                var features = geoJson["features"];
                int markerInterval = int.Parse(txtEliminationCount.Text); // Adjust this to set how often markers are placed

                if (features != null)
                {
                    int pointCounter = 0;

                    foreach (var feature in features)
                    {
                        var coordinates = feature["geometry"]["coordinates"];
                        if (coordinates != null && feature["geometry"]["type"].ToString() == "LineString")
                        {
                            List<PointLatLng> points = new List<PointLatLng>();
                            foreach (var coord in coordinates)
                            {
                                double lon = (double)coord[0];
                                double lat = (double)coord[1];
                                points.Add(new PointLatLng(lat, lon));

                                // Place a marker at every interval
                                if (pointCounter % markerInterval == 0)
                                {
                                    var marker = new GMarkerGoogle(new PointLatLng(lat, lon), GMarkerGoogleType.orange_dot);
                                    roadsOverlay.Markers.Add(marker);
                                }
                                pointCounter++;
                            }

                            // Create a route and add it to the overlay
                            GMapRoute route = new GMapRoute(points, "roadRoute")
                            {
                                Stroke = new Pen(Color.Blue, 2)
                            };
                            roadsOverlay.Routes.Add(route);
                        }
                    }

                    // Add the overlay to the map control
                    gMapControl1.Overlays.Add(roadsOverlay);
                    gMapControl1.Refresh(); // Redraw the map
                }
                else
                {
                    MessageBox.Show("No features found in the GeoJSON file.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading GeoJSON: {ex.Message}");
            }
        }

        private void btnLoadGeoJson_Click_1(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "GeoJSON files (*.geojson)|*.geojson|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string geoJsonPath = openFileDialog.FileName;
                    LoadGeoJsonToMap(geoJsonPath);
                }
            }
        }
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            // Create an instance of FolderBrowserDialog
            ChooseFolder();
        }

        

        private void getJSON()
        {
            var client = new RestClient("https://overpass-api.de/api/interpreter");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");

            string areaName = regionName.Text;
            string timeout = txtTimeout.Text;
            string query = $@"
            [out:json][timeout:{timeout}];
            area[name='{areaName}']->.searchArea;
            (way['highway'~'motorway|trunk|primary'](area.searchArea););
            out body; >; out skel qt;";

            request.AddParameter("data", query);
            lblSpecificProgress.Text = "Sending request to Overpass API...";
            var response = client.Execute(request);

            lblSpecificProgress.Text = "Received response from Overpass API.";
            if (response.IsSuccessful)
            {
                lblSpecificProgress.Text = "Road data retrieved successfully.";

                string jsonFilePath = Path.Combine(selectedFolderPath, "roads_catalonia.json"); // Save in selected path
                SaveDataToFile(response.Content, jsonFilePath);
                lblSpecificProgress.Text = $"Road data saved to {jsonFilePath}";
            }
            else
            {
                lblOverallProgress.Text = "An error has occurred. Probable timeout";
                MessageBox.Show("There has been an error: Probable timeout or wrong region input");
            }
        }
        static void SaveDataToFile(string content, string filePath)
        {
            File.WriteAllText(filePath, content);
        }

        private void folderBrowserDialog1_HelpRequest(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click_1(object sender, EventArgs e)
        {
            ChooseFolder();
        }
        private void ChooseFolder()
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                selectedFolderPath = folderBrowserDialog1.SelectedPath; // Store selected path
                lblDownloadProgress.Text = selectedFolderPath;
            }
        }

        private void btnDownloadJSON_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                ChooseFolder(); // Prompt for folder selection if not yet selected
            }

            lblOverallProgress.Text = "Downloading data from API...";
            getJSON();
            lblOverallProgress.Text = "Successfully downloaded. Converting...";
            mainGEO();

            string outputPath = Path.Combine(selectedFolderPath, "output2.geojson");
            LoadGeoJsonToMap(outputPath);

            lblOverallProgress.Text = $"Successfully optimized. Saved to: {outputPath}";
            gMapControl1.Zoom = 8;
            gMapControl1.Refresh();
        }


        private void ShowComment(string s)
        {
            lblSpecificProgress.Text = s;
        }


        // GEOJSON part
        private void mainGEO()
        {
            string inputFilePath = Path.Combine(selectedFolderPath, "roads_catalonia.json"); // Input from selected path
            string outputFilePath = Path.Combine(selectedFolderPath, "output2.geojson"); // Output to selected path

            try
            {
                string jsonData = File.ReadAllText(inputFilePath);
                lblSpecificProgress.Text = "Input JSON data read successfully.";
                Thread.Sleep(500);
                lblSpecificProgress.Text = "Processing JSON data...";

                string geoJsonData = ConvertToGeoJson(jsonData);
                if (!string.IsNullOrEmpty(geoJsonData))
                {
                    File.WriteAllText(outputFilePath, geoJsonData);
                    lblSpecificProgress.Text = "GeoJSON data saved";
                }
                else
                {
                    lblSpecificProgress.Text = "Conversion failed to convert OSM JSON to GeoJSON.";
                }
            }
            catch (Exception ex)
            {
                lblSpecificProgress.Text = $"Error: {ex.Message}";
            }
        }

        static string ConvertToGeoJson(string jsonData)
        {
            try
            {
                var osmJson = JObject.Parse(jsonData);
                var elements = osmJson["elements"];

                if (elements != null && elements.Type == JTokenType.Array && elements.Count() > 0)
                {
                    ///MessageBox.Show($"Number of elements found: {elements.Count()}");
                    JObject geoJson = new JObject
                    {
                        { "type", "FeatureCollection" },
                        { "features", new JArray() }
                    };

                    var features = (JArray)geoJson["features"];
                    var nodeCache = new Dictionary<string, (double lat, double lon)>();

                    // Populate the node cache
                    int processedNodes = 0;
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            ///MessageBox.Show($"Processed nodes: {processedNodes}/{elements.Count()}");
                            ///Thread.Sleep(100); // Update progress every 100ms
                        }
                    });

                    foreach (var element in elements)
                    {
                        if (element["type"]?.ToString() == "node")
                        {
                            var id = element["id"]?.ToString();
                            if (element["lat"] != null && element["lon"] != null && id != null)
                            {
                                double lat = element["lat"].ToObject<double>();
                                double lon = element["lon"].ToObject<double>();
                                nodeCache[id] = (lat, lon);
                            }
                        }

                        processedNodes++;
                    }

                    // Process ways and collect features
                    int processedWays = 0;
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            ///MessageBox.Show($"Processed ways: {processedWays}/{elements.Count()}");
                            ///Thread.Sleep(100); // Update progress every 100ms
                        }
                    });

                    foreach (var element in elements)
                    {
                        if (element["type"]?.ToString() == "way" && element["nodes"] != null)
                        {
                            JObject feature = new JObject
                            {
                                { "type", "Feature" },
                                { "properties", new JObject() },
                                { "geometry", new JObject
                                    {
                                        { "type", "LineString" },
                                        { "coordinates", new JArray() }
                                    }
                                }
                            };

                            var coordinates = (JArray)feature["geometry"]?["coordinates"];
                            var nodeIds = element["nodes"]?.ToObject<JArray>();

                            List<(double lat, double lon)> points = new List<(double lat, double lon)>();

                            foreach (var node in nodeIds)
                            {
                                var nodeId = node.ToString();
                                if (nodeCache.TryGetValue(nodeId, out var nodeData))
                                {
                                    points.Add(nodeData);
                                }
                            }

                            // Apply intersection handling and simplification for 90-degree turns
                            var simplifiedPoints = SimplifyRoadWith90DegreeCorners(points);

                            // Add simplified points to the coordinates
                            foreach (var point in simplifiedPoints)
                            {
                                coordinates?.Add(new JArray(Math.Round(point.lon, 6), Math.Round(point.lat, 6)));
                            }

                            features.Add(feature);
                        }

                        processedWays++;
                    }

                    ///MessageBox.Show($"Total features after optimization: {features.Count}");

                    return geoJson.ToString();
                }
                else
                {
                    MessageBox.Show("No elements found in the JSON response or elements property is not an array.");
                    return null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error converting OSM JSON to GeoJSON: {ex.Message}");
                return null;
            }
        }

        // Function to handle roads and ensure 90-degree turns at intersections
        static List<(double lat, double lon)> SimplifyRoadWith90DegreeCorners(List<(double lat, double lon)> points)
        {
            if (points.Count < 2) return points;

            List<(double lat, double lon)> simplifiedPoints = new List<(double lat, double lon)>
            {
                points[0] // Start with the first point
            };

            for (int i = 1; i < points.Count - 1; i++)
            {
                var previous = points[i - 1];
                var current = points[i];
                var next = points[i + 1];

                // Calculate angles between segments
                double angle = CalculateAngle(previous, current, next);

                if (Math.Abs(angle - 90) < 20) // Tolerance for near 90-degree angles
                {
                    // Force the turn to be a 90-degree angle
                    var cornerPoint = Get90DegreeTurnPoint(previous, current, next);
                    simplifiedPoints.Add(cornerPoint);
                }
                else
                {
                    simplifiedPoints.Add(current);
                }
            }

            simplifiedPoints.Add(points.Last()); // End with the last point

            return simplifiedPoints;
        }

        // Calculate the angle between three points
        static double CalculateAngle((double lat, double lon) prev, (double lat, double lon) current, (double lat, double lon) next)
        {
            double deltaY1 = current.lat - prev.lat;
            double deltaX1 = current.lon - prev.lon;
            double deltaY2 = next.lat - current.lat;
            double deltaX2 = next.lon - current.lon;

            double angle1 = Math.Atan2(deltaY1, deltaX1) * (180 / Math.PI);
            double angle2 = Math.Atan2(deltaY2, deltaX2) * (180 / Math.PI);

            double angle = Math.Abs(angle1 - angle2);
            return angle > 180 ? 360 - angle : angle;
        }

        // Get the 90-degree turn point between two segments
        static (double lat, double lon) Get90DegreeTurnPoint((double lat, double lon) prev, (double lat, double lon) current, (double lat, double lon) next)
        {
            // Find midpoint between current and next to approximate 90-degree turn
            double midLat = (current.lat + next.lat) / 2;
            double midLon = (current.lon + next.lon) / 2;

            return (midLat, midLon);
        }
        private void btnLoadFromAPI_Click(object sender, EventArgs e)
        {

            LoadGeoJsonToMap("C:\\Users\\usuario\\Desktop\\Nueva_carpeta\\output2.geojson");
        }

        private void optiGEOJSON_Click(object sender, EventArgs e)
        {
            //mainGEO(geoJsonPath);
        }
        private void btnOpti_Click(object sender, EventArgs e)
        {

        }

        private void btnCaptureMapImage_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(selectedFolderPath))
            {
                ChooseFolder(); // Ensure a folder is selected
            }

            // Capture the current map view
            using (Bitmap bitmap = new Bitmap(gMapControl1.Width, gMapControl1.Height))
            {
                gMapControl1.DrawToBitmap(bitmap, new Rectangle(0, 0, bitmap.Width, bitmap.Height));

                // Save the image in the selected folder
                string imagePath = Path.Combine(selectedFolderPath, "MapCapture.png");
                bitmap.Save(imagePath, System.Drawing.Imaging.ImageFormat.Png);

                MessageBox.Show($"Map image saved to {imagePath}");
            }
        }

    }
}
