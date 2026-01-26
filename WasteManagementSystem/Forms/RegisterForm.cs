using System;
using System.Windows.Forms;
using WasteManagementSystem.Models;
using WasteManagementSystem.Services;

namespace WasteManagementSystem.Forms
{
    public partial class RegisterForm : Form
    {
        private readonly AuthService _authService;

        public RegisterForm()
        {
            InitializeComponent();
            _authService = new AuthService();
            cmbRole.SelectedIndex = 0; // Default Masyarat
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageBox.Show("Username dan Password harus diisi!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var user = new User
            {
                Username = txtUsername.Text,
                FullName = txtFullName.Text,
                Role = cmbRole.SelectedItem.ToString(),
                Address = "", // Optional for now
                PhoneNumber = ""
            };

            if (_authService.Register(user, txtPassword.Text))
            {
                MessageBox.Show("Registrasi Berhasil! Silakan Login.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Username sudah digunakan.", "Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkLogin_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }
    }
}
