using System;
using System.Windows.Forms;
using WasteManagementSystem.Models;
using WasteManagementSystem.Services;
using WasteManagementSystem.Forms;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace WasteManagementSystem.Controls
{
    public partial class WasteManagementControl : UserControl
    {
        private User _user;
        private WasteService _service;

        public WasteManagementControl(User user)
        {
            InitializeComponent();
            _user = user;
            _service = new WasteService();
            SetupPermissions();
            LoadData();
        }
        
        // Parameterless constructor for Designer support
        public WasteManagementControl()
        {
            InitializeComponent();
            _service = new WasteService();
        }

        private void SetupPermissions()
        {
            if (_user == null) return;

            // Admin: Full CRUD access
            if (_user.Role == "Admin")
            {
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnComplete.Visible = true;
                btnExport.Visible = true;
            }
            // Petugas: Input, Edit, Update Status
            else if (_user.Role == "Petugas")
            {
                btnAdd.Visible = true;
                btnEdit.Visible = true;
                btnDelete.Visible = false;
                btnComplete.Visible = true;
                btnExport.Visible = true;
            }
            // Masyarakat: No access to this control (should not reach here)
            else if (_user.Role == "Masyarakat")
            {
                btnAdd.Visible = false;
                btnEdit.Visible = false;
                btnDelete.Visible = false;
                btnComplete.Visible = false;
                btnExport.Visible = false;
            }
        }

        private void LoadData()
        {
            if (_user == null) return;

            bool showHistory = chkShowHistory.Checked;

            if (_user.Role == "Masyarakat")
            {
                dgvData.DataSource = showHistory ? _service.GetByUserId(_user.Id) : _service.GetPendingByUserId(_user.Id);
            }
            else
            {
                dgvData.DataSource = showHistory ? _service.GetAll() : _service.GetPending();
            }
            
            ConfigureGrid();
        }

        private void chkShowHistory_CheckedChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ConfigureGrid()
        {
            if (dgvData.Columns.Count == 0) return;

            // --- Modern Styling ---
            dgvData.EnableHeadersVisualStyles = false;
            dgvData.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvData.ColumnHeadersDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(32, 178, 170); // LightSeaGreen
            dgvData.ColumnHeadersDefaultCellStyle.ForeColor = System.Drawing.Color.White;
            dgvData.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvData.ColumnHeadersHeight = 40;
            
            dgvData.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(143, 188, 143); // DarkSeaGreen
            dgvData.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            dgvData.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvData.RowTemplate.Height = 35;
            dgvData.AlternatingRowsDefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(245, 255, 250); // MintCream
            
            dgvData.BorderStyle = BorderStyle.None;
            dgvData.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvData.GridColor = System.Drawing.Color.FromArgb(220, 220, 220);
            // ----------------------

            // Hide technical columns
            if (dgvData.Columns["Id"] != null) dgvData.Columns["Id"].Visible = false;
            if (dgvData.Columns["UserId"] != null) dgvData.Columns["UserId"].Visible = false;
            // UpdatedAt is now shown

            // Rename and formatting
            if (dgvData.Columns["WasteType"] != null) dgvData.Columns["WasteType"].HeaderText = "Jenis Sampah";
            if (dgvData.Columns["Weight"] != null) dgvData.Columns["Weight"].HeaderText = "Berat (Kg)";
            if (dgvData.Columns["Location"] != null) dgvData.Columns["Location"].HeaderText = "Lokasi Pembuangan";
            if (dgvData.Columns["Status"] != null) dgvData.Columns["Status"].HeaderText = "Status";
            if (dgvData.Columns["Description"] != null) dgvData.Columns["Description"].HeaderText = "Keterangan";
            if (dgvData.Columns["CreatedAt"] != null)
            {
                dgvData.Columns["CreatedAt"].HeaderText = "Tanggal Dibuat";
                dgvData.Columns["CreatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
            if (dgvData.Columns["UpdatedAt"] != null)
            {
                dgvData.Columns["UpdatedAt"].HeaderText = "Waktu Selesai";
                dgvData.Columns["UpdatedAt"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new WasteEntryForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    var entry = form.Result;
                    entry.UserId = _user.Id;
                try
                {
                    _service.Add(entry);
                    LoadData();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Gagal menyimpan data ke database: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                var row = dgvData.SelectedRows[0];
                string id = row.Cells["Id"].Value?.ToString();
                string wasteType = row.Cells["WasteType"].Value?.ToString();
                double weight = Convert.ToDouble(row.Cells["Weight"].Value);
                string location = row.Cells["Location"].Value?.ToString();
                string description = row.Cells["Description"].Value?.ToString();

                using (var form = new WasteEntryForm())
                {
                    // Pre-fill form (will need to modify WasteEntryForm to support this)
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        var updatedEntry = form.Result;
                        updatedEntry.Id = id;
                        updatedEntry.UserId = _user.Id;
                        updatedEntry.UpdatedAt = DateTime.Now;

                        try
                        {
                            _service.Update(updatedEntry);
                            LoadData();
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show($"Gagal mengupdate data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Pilih data terlebih dahulu untuk diedit.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                QuestPDF.Settings.License = LicenseType.Community;
                var data = (System.Collections.Generic.IEnumerable<WasteEntry>)dgvData.DataSource;

                if (data == null) return;

                var document = Document.Create(container =>
                {
                    container.Page(page =>
                    {
                        page.Size(PageSizes.A4);
                        page.Margin(2, Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.DefaultTextStyle(x => x.FontSize(11));

                        page.Header()
                            .Text("Laporan Data Sampah")
                            .SemiBold().FontSize(20).FontColor(Colors.Blue.Medium);

                        page.Content()
                            .PaddingVertical(1, Unit.Centimetre)
                            .Table(table =>
                            {
                                table.ColumnsDefinition(columns =>
                                {
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                    columns.RelativeColumn();
                                });

                                table.Header(header =>
                                {
                                    header.Cell().Element(CellStyle).Text("Tipe");
                                    header.Cell().Element(CellStyle).Text("Berat (kg)");
                                    header.Cell().Element(CellStyle).Text("Lokasi");
                                    header.Cell().Element(CellStyle).Text("Status");

                                    static IContainer CellStyle(IContainer container)
                                    {
                                        return container.DefaultTextStyle(x => x.SemiBold()).PaddingVertical(5).BorderBottom(1).BorderColor(Colors.Black);
                                    }
                                });

                                foreach (var item in data)
                                {
                                    table.Cell().Element(CellStyle).Text(item.WasteType);
                                    table.Cell().Element(CellStyle).Text(item.Weight.ToString());
                                    table.Cell().Element(CellStyle).Text(item.Location);
                                    table.Cell().Element(CellStyle).Text(item.Status);

                                    static IContainer CellStyle(IContainer container)
                                    {
                                        return container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                                    }
                                }
                            });

                        page.Footer()
                            .AlignCenter()
                            .Text(x =>
                            {
                                x.Span("Page ");
                                x.CurrentPageNumber();
                            });
                    });
                });

                string path = $"Report_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";
                document.GeneratePdf(path);
                MessageBox.Show($"Export berhasil: {path}", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Open file
                try 
                { 
                    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo(path) { UseShellExecute = true }); 
                } catch { }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gagal export PDF: " + ex.Message);
            }
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                var row = dgvData.SelectedRows[0];
                string id = row.Cells["Id"].Value.ToString();
                _service.UpdateStatus(id, "Completed");
                LoadData();
            }
            else
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvData.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Yakin hapus data ini?", "Konfirmasi", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    var row = dgvData.SelectedRows[0];
                    string id = row.Cells["Id"].Value.ToString();
                    _service.Delete(id);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Pilih data terlebih dahulu.");
            }
        }
    }
}
