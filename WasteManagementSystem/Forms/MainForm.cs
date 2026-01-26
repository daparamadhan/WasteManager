using System;
using System.Drawing;
using System.Windows.Forms;
using WasteManagementSystem.Controls;
using WasteManagementSystem.Models;

namespace WasteManagementSystem.Forms
{
    public partial class MainForm : Form
    {
        private User _user;
        private UserControl _activeControl;

        public MainForm(User user)
        {
            InitializeComponent();
            _user = user;
            lblUser.Text = $"Welcome, {user.FullName} ({user.Role})";
            
            // Role-based menu visibility
            if (_user.Role == "Admin")
            {
                // Admin sees all menus
                btnDashboard.Visible = true;
                btnWaste.Visible = true;
                btnMaps.Visible = true;
                btnChat.Visible = true;
            }
            else if (_user.Role == "Petugas")
            {
                // Petugas sees: Dashboard, Waste Management, Maps
                btnDashboard.Visible = true;
                btnWaste.Visible = true;
                btnMaps.Visible = true;
                btnChat.Visible = false;
            }
            else if (_user.Role == "Masyarakat")
            {
                // Masyarakat sees: Dashboard (summary), Maps, Chat
                btnDashboard.Visible = true;
                btnWaste.Visible = false; // No direct waste management access
                btnMaps.Visible = true;
                btnChat.Visible = true;
            }
            
            // Load Default
            LoadControl(new DashboardControl(), "Dashboard");
        }

        private void LoadControl(UserControl control, string title)
        {
            if (_activeControl != null)
            {
                pnlContent.Controls.Remove(_activeControl);
                _activeControl.Dispose();
            }

            _activeControl = control;
            _activeControl.Dock = DockStyle.Fill;
            pnlContent.Controls.Add(_activeControl);
            lblTitle.Text = title;
        }

        private void SetActiveButton(Button activeButton)
        {
            // Reset all
            btnDashboard.BackColor = Color.SeaGreen;
            btnWaste.BackColor = Color.SeaGreen;
            btnMaps.BackColor = Color.SeaGreen;
            btnChat.BackColor = Color.SeaGreen;

            // Set active
            if (activeButton != null)
            {
                activeButton.BackColor = Color.DarkSeaGreen;
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnDashboard);
            LoadControl(new DashboardControl(), "Dashboard");
        }

        private void btnWaste_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnWaste);
            LoadControl(new WasteManagementControl(_user), "Manajemen Sampah");
        }

        private void btnMaps_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnMaps);
            LoadControl(new MapControl(), "Peta Lokasi");
        }

        private void btnChat_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnChat);
            LoadControl(new ChatControl(), "Chat AI");
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close(); // Will return to LoginForm because ShowDialog() returns
        }
    }
}
