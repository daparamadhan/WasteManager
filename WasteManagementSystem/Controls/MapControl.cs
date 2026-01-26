using System;
using System.Windows.Forms;
using Microsoft.Web.WebView2.Core;

namespace WasteManagementSystem.Controls
{
    public partial class MapControl : UserControl
    {
        public MapControl()
        {
            InitializeComponent();
            InitializeAsync();
        }

        async void InitializeAsync()
        {
            try
            {
                webView.DefaultBackgroundColor = System.Drawing.Color.White;
                
                await webView.EnsureCoreWebView2Async(null);
                
                // Enable DevTools for debugging
                webView.CoreWebView2.Settings.AreDevToolsEnabled = true;
                
                // Fetch data
                var service = new WasteManagementSystem.Services.WasteService();
                var wasteSummary = service.GetWasteByLocation();

                var locations = new System.Collections.Generic.Dictionary<string, (double Lat, double Lon)>
                {
                    { "TPPAS Sarimukti - Cipatat, Kab. Bandung Barat", (-6.8373, 107.3364) },
                    { "TPPAS Legok Nangka - Nagreg, Kab. Bandung", (-7.0197, 107.8285) },
                    { "TPPAS Lulut Nambo - Klapanunggal, Kab. Bogor", (-6.4912, 106.9178) },
                    { "TPPAS Cirebon Raya - Ciwaringin, Kab. Cirebon", (-6.6833, 108.3833) },
                    { "TPA Burangkeng - Setu, Kab. Bekasi", (-6.3541, 107.0383) },
                    { "TPA Sumur Batu - Bantar Gebang, Kota Bekasi", (-6.3471, 106.9922) },
                    { "TPA Galuga - Cibungbulang, Kab. Bogor", (-6.5417, 106.6583) },
                    { "TPA Cipayung - Cipayung, Kota Depok", (-6.4355, 106.7797) },
                    { "TPA Jalupang - Kotabaru, Kab. Karawang", (-6.3833, 107.4500) },
                    { "TPA Cikolotok - Pasawahan, Kab. Purwakarta", (-6.5167, 107.4833) },
                    { "TPA Penembong & Jalumpang - Subang, Kab. Subang", (-6.5714, 107.7589) },
                    { "TPA Pecuk & Kertawinangun - Sindang & Kandanghaur, Kab. Indramayu", (-6.3275, 108.3247) },
                    { "TPA Kopi Luhur - Argasunya, Kota Cirebon", (-6.7561, 108.5553) },
                    { "TPA Gunungsantri & Kubangdeleg - Palimanan & Karangwareng, Kab. Cirebon", (-6.7025, 108.4111) },
                    { "TPA Heuleut - Kadipaten, Kab. Majalengka", (-6.7328, 108.1611) },
                    { "TPA Sukanyiru - Sumedang Utara, Kab. Sumedang", (-6.8411, 107.9211) },
                    { "TPA Pasirbajing - Banyuresmi, Kab. Garut", (-7.1528, 107.9011) },
                    { "TPA Ciangir - Tamansari, Kota Tasikmalaya", (-7.3528, 108.2111) },
                    { "TPA Nangkaleah - Mangunreja, Kab. Tasikmalaya", (-7.3328, 108.1111) },
                    { "TPA Handapherang - Cijeungjing, Kab. Ciamis", (-7.3228, 108.3811) },
                    { "TPA Gunung Tumpeng - Pataruman, Kota Banjar", (-7.3828, 108.5311) },
                    { "TPA Purbahayu - Pangandaran, Kab. Pangandaran", (-7.6828, 108.4811) },
                    { "TPA Cikundul - Lembursitu, Kota Sukabumi", (-6.9528, 106.9111) },
                    { "TPA Cimenteng - Cikembar, Kab. Sukabumi", (-6.9828, 106.8111) },
                    { "TPA Pasir Sembung - Cilaku, Kab. Cianjur", (-6.8228, 107.1211) }
                };

                string markersJs = "";
                foreach (var loc in locations)
                {
                    double weight = wasteSummary.ContainsKey(loc.Key) ? wasteSummary[loc.Key] : 0;
                    string nameText = loc.Key.Replace("'", "\\'");
                    
                    // Use double quotes for HTML to avoid conflict with single quotes used in .bindPopup('')
                    string labelHtml = weight > 0 
                        ? $"<br/><b style=\"color:red\">Total: {weight} Kg</b>" 
                        : "<br/><i>Belum ada data masuk</i>";
                    
                    markersJs += $@"
                        L.marker([{loc.Value.Lat}, {loc.Value.Lon}], {{icon: redIcon}})
                         .addTo(map)
                         .bindPopup('<b>{nameText}</b>{labelHtml}');";
                }

                string html = $@"
                <!DOCTYPE html>
                <html>
                <head>
                    <meta charset='utf-8' />
                    <style>
                        #map {{ height: 100vh; width: 100vw; margin: 0; padding: 0; background: #eee; }}
                        body {{ margin: 0; padding: 0; overflow: hidden; }}
                        #loading {{ position: fixed; top: 0; left: 0; width: 100%; height: 100%; 
                                     background: white; display: flex; flex-direction: column; align-items: center; 
                                     justify-content: center; z-index: 9999; font-family: sans-serif; }}
                    </style>
                    <script>
                        window.onerror = function(msg, url, line) {{
                            document.getElementById('loading').innerHTML = '<h3 style=""color:red"">Gagal Memuat Peta</h3>' + 
                                '<p>' + msg + '</p>' +
                                '<p>Pastikan Anda terhubung ke Internet.</p>';
                            return false;
                        }};
                    </script>
                    <link rel='stylesheet' href='https://unpkg.com/leaflet@1.9.4/dist/leaflet.css' />
                    <script src='https://unpkg.com/leaflet@1.9.4/dist/leaflet.js'></script>
                </head>
                <body>
                    <div id='loading'>
                        <div style='font-size: 1.2em; margin-bottom: 10px;'>Memproses Peta...</div>
                        <div style='font-size: 0.9em; color: #666;'>Tunggu sebentar...</div>
                    </div>
                    <div id='map'></div>
                    <script>
                        try {{
                            var map = L.map('map').setView([-6.9175, 107.6191], 8);
                            
                            L.tileLayer('https://{{s}}.tile.openstreetmap.org/{{z}}/{{x}}/{{y}}.png', {{
                                attribution: '&copy; OpenStreetMap'
                            }}).addTo(map);

                            var redIcon = new L.Icon({{
                                iconUrl: 'https://raw.githubusercontent.com/pointhi/leaflet-color-markers/master/img/marker-icon-2x-red.png',
                                shadowUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/0.7.7/images/marker-shadow.png',
                                iconSize: [25, 41],
                                iconAnchor: [12, 41],
                                popupAnchor: [1, -34],
                                shadowSize: [41, 41]
                            }});

                            {markersJs}

                            document.getElementById('loading').style.display = 'none';

                        }} catch (e) {{
                            document.getElementById('loading').innerHTML = '<h3 style=""color:red"">Kesalahan Internal Peta</h3>' + e.message;
                        }}
                    </script>
                </body>
                </html>";

                webView.CoreWebView2.NavigateToString(html);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal menginisialisasi Peta: " + ex.Message, "System Error");
            }
        }
    }
}
