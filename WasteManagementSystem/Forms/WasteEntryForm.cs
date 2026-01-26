using System;
using System.Windows.Forms;
using WasteManagementSystem.Models;

namespace WasteManagementSystem.Forms
{
    public partial class WasteEntryForm : Form
    {
        public WasteEntry Result { get; private set; }

        public WasteEntryForm()
        {
            InitializeComponent();
            cmbType.SelectedIndex = 0;
            InitializeLocations();
        }

        private System.Collections.Generic.Dictionary<string, string[]> _regionLocationMap;

        private void InitializeLocations()
        {
            _regionLocationMap = new System.Collections.Generic.Dictionary<string, string[]>
            {
                { "Kab. Bandung Barat", new[] { "TPPAS Sarimukti - Cipatat, Kab. Bandung Barat" } },
                { "Kab. Bandung", new[] { "TPPAS Legok Nangka - Nagreg, Kab. Bandung" } },
                { "Kab. Bogor", new[] { "TPPAS Lulut Nambo - Klapanunggal, Kab. Bogor", "TPA Galuga - Cibungbulang, Kab. Bogor" } },
                { "Kab. Cirebon", new[] { "TPPAS Cirebon Raya - Ciwaringin, Kab. Cirebon", "TPA Gunungsantri & Kubangdeleg - Palimanan & Karangwareng, Kab. Cirebon" } },
                { "Kab. Bekasi", new[] { "TPA Burangkeng - Setu, Kab. Bekasi" } },
                { "Kota Bekasi", new[] { "TPA Sumur Batu - Bantar Gebang, Kota Bekasi" } },
                { "Kota Depok", new[] { "TPA Cipayung - Cipayung, Kota Depok" } },
                { "Kab. Karawang", new[] { "TPA Jalupang - Kotabaru, Kab. Karawang" } },
                { "Kab. Purwakarta", new[] { "TPA Cikolotok - Pasawahan, Kab. Purwakarta" } },
                { "Kab. Subang", new[] { "TPA Penembong & Jalumpang - Subang, Kab. Subang" } },
                { "Kab. Indramayu", new[] { "TPA Pecuk & Kertawinangun - Sindang & Kandanghaur, Kab. Indramayu" } },
                { "Kota Cirebon", new[] { "TPA Kopi Luhur - Argasunya, Kota Cirebon" } },
                { "Kab. Majalengka", new[] { "TPA Heuleut - Kadipaten, Kab. Majalengka" } },
                { "Kab. Sumedang", new[] { "TPA Sukanyiru - Sumedang Utara, Kab. Sumedang" } },
                { "Kab. Garut", new[] { "TPA Pasirbajing - Banyuresmi, Kab. Garut" } },
                { "Kota Tasikmalaya", new[] { "TPA Ciangir - Tamansari, Kota Tasikmalaya" } },
                { "Kab. Tasikmalaya", new[] { "TPA Nangkaleah - Mangunreja, Kab. Tasikmalaya" } },
                { "Kab. Ciamis", new[] { "TPA Handapherang - Cijeungjing, Kab. Ciamis" } },
                { "Kota Banjar", new[] { "TPA Gunung Tumpeng - Pataruman, Kota Banjar" } },
                { "Kab. Pangandaran", new[] { "TPA Purbahayu - Pangandaran, Kab. Pangandaran" } },
                { "Kota Sukabumi", new[] { "TPA Cikundul - Lembursitu, Kota Sukabumi" } },
                { "Kab. Sukabumi", new[] { "TPA Cimenteng - Cikembar, Kab. Sukabumi" } },
                { "Kab. Cianjur", new[] { "TPA Pasir Sembung - Cilaku, Kab. Cianjur" } }
            };

            foreach (var region in _regionLocationMap.Keys)
            {
                cmbRegion.Items.Add(region);
            }
            
            if (cmbRegion.Items.Count > 0) cmbRegion.SelectedIndex = 0;
        }

        private void cmbRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbLocation.Items.Clear();
            if (cmbRegion.SelectedItem != null)
            {
                string selectedRegion = cmbRegion.SelectedItem.ToString();
                if (_regionLocationMap.ContainsKey(selectedRegion))
                {
                    cmbLocation.Items.AddRange(_regionLocationMap[selectedRegion]);
                    if (cmbLocation.Items.Count > 0) cmbLocation.SelectedIndex = 0;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (numWeight.Value <= 0)
            {
                MessageBox.Show("Berat harus lebih dari 0.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (cmbLocation.SelectedItem == null)
            {
                MessageBox.Show("Silakan pilih lokasi pembuangan.", "Validasi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var locationMapping = new System.Collections.Generic.Dictionary<string, (double Lat, double Lon)>
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

            string selectedLoc = cmbLocation.SelectedItem.ToString();
            double lat = -6.9175; // Default Bandung center
            double lon = 107.6191;

            if (locationMapping.ContainsKey(selectedLoc))
            {
                lat = locationMapping[selectedLoc].Lat;
                lon = locationMapping[selectedLoc].Lon;
            }

            Result = new WasteEntry
            {
                WasteType = cmbType.SelectedItem.ToString(),
                Weight = (double)numWeight.Value,
                Location = selectedLoc,
                Description = txtDescription.Text,
                Status = "Pending",
                Latitude = lat,
                Longitude = lon,
                CreatedAt = DateTime.Now
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
