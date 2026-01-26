using System;
using System.Windows.Forms;
using WasteManagementSystem.Services;

namespace WasteManagementSystem.Forms
{
    public partial class LoginForm : Form
    {
        private readonly AuthService _authService;

        public LoginForm()
        {
            InitializeComponent();
            _authService = new AuthService();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            var user = _authService.Login(txtUsername.Text, txtPassword.Text);
            if (user != null)
            {
                MessageBox.Show($"Selamat datang, {user.FullName} ({user.Role})!", "Login Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                // Open MainForm
                MainForm mainForm = new MainForm(user);
                this.Hide();
                mainForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Username atau Password salah.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lnkRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm regForm = new RegisterForm();
            this.Hide();
            regForm.ShowDialog();
            this.Show();
        }
    }
}
