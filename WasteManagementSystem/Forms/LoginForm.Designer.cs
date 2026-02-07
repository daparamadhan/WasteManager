namespace WasteManagementSystem.Forms
{
    partial class LoginForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.picBackground = new System.Windows.Forms.PictureBox();
            this.pnlGlass = new System.Windows.Forms.Panel();
            this.lnkRegister = new System.Windows.Forms.LinkLabel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordIcon = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsernameIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.pnlGlass.SuspendLayout();
            this.pnlPassword.SuspendLayout();
            this.pnlUsername.SuspendLayout();
            this.SuspendLayout();
            // 
            // picBackground
            // 
            this.picBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picBackground.Location = new System.Drawing.Point(0, 0);
            this.picBackground.Name = "picBackground";
            this.picBackground.Size = new System.Drawing.Size(1000, 600);
            this.picBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picBackground.TabIndex = 0;
            this.picBackground.TabStop = false;
            try
            {
                string imagePath = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Resources", "login_background.png");
                if (System.IO.File.Exists(imagePath))
                {
                    this.picBackground.Image = System.Drawing.Image.FromFile(imagePath);
                }
                else
                {
                    this.picBackground.BackColor = System.Drawing.Color.FromArgb(176, 224, 230);
                }
            }
            catch
            {
                this.picBackground.BackColor = System.Drawing.Color.FromArgb(176, 224, 230);
            }
            // 
            // pnlGlass
            // 
            this.pnlGlass.BackColor = System.Drawing.Color.FromArgb(220, 255, 255, 255);
            this.pnlGlass.Controls.Add(this.lnkRegister);
            this.pnlGlass.Controls.Add(this.btnLogin);
            this.pnlGlass.Controls.Add(this.pnlPassword);
            this.pnlGlass.Controls.Add(this.pnlUsername);
            this.pnlGlass.Controls.Add(this.lblTitle);
            this.pnlGlass.Location = new System.Drawing.Point(325, 150);
            this.pnlGlass.Name = "pnlGlass";
            this.pnlGlass.Size = new System.Drawing.Size(350, 300);
            this.pnlGlass.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.lblTitle.Location = new System.Drawing.Point(0, 30);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "LOGIN";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.Transparent;
            this.pnlUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsername.Controls.Add(this.lblUsernameIcon);
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Location = new System.Drawing.Point(40, 100);
            this.pnlUsername.Name = "pnlUsername";
            this.pnlUsername.Size = new System.Drawing.Size(270, 40);
            this.pnlUsername.TabIndex = 1;
            // 
            // lblUsernameIcon
            // 
            this.lblUsernameIcon.AutoSize = false;
            this.lblUsernameIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUsernameIcon.ForeColor = System.Drawing.Color.Gray;
            this.lblUsernameIcon.Location = new System.Drawing.Point(8, 8);
            this.lblUsernameIcon.Name = "lblUsernameIcon";
            this.lblUsernameIcon.Size = new System.Drawing.Size(30, 24);
            this.lblUsernameIcon.TabIndex = 0;
            this.lblUsernameIcon.Text = "👤";
            this.lblUsernameIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtUsername
            // 
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.ForeColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.txtUsername.Location = new System.Drawing.Point(45, 10);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.PlaceholderText = "Username";
            this.txtUsername.Size = new System.Drawing.Size(215, 20);
            this.txtUsername.TabIndex = 0;
            // 
            // pnlPassword
            // 
            this.pnlPassword.BackColor = System.Drawing.Color.Transparent;
            this.pnlPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPassword.Controls.Add(this.lblPasswordIcon);
            this.pnlPassword.Controls.Add(this.txtPassword);
            this.pnlPassword.Location = new System.Drawing.Point(40, 155);
            this.pnlPassword.Name = "pnlPassword";
            this.pnlPassword.Size = new System.Drawing.Size(270, 40);
            this.pnlPassword.TabIndex = 2;
            // 
            // lblPasswordIcon
            // 
            this.lblPasswordIcon.AutoSize = false;
            this.lblPasswordIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblPasswordIcon.ForeColor = System.Drawing.Color.Gray;
            this.lblPasswordIcon.Location = new System.Drawing.Point(8, 8);
            this.lblPasswordIcon.Name = "lblPasswordIcon";
            this.lblPasswordIcon.Size = new System.Drawing.Size(30, 24);
            this.lblPasswordIcon.TabIndex = 0;
            this.lblPasswordIcon.Text = "🔒";
            this.lblPasswordIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPassword
            // 
            this.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPassword.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPassword.ForeColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.txtPassword.Location = new System.Drawing.Point(45, 10);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '●';
            this.txtPassword.PlaceholderText = "Password";
            this.txtPassword.Size = new System.Drawing.Size(215, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.btnLogin.FlatAppearance.BorderSize = 0;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(40, 210);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(270, 40);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "LOGIN";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            this.btnLogin.MouseEnter += new System.EventHandler(this.btnLogin_MouseEnter);
            this.btnLogin.MouseLeave += new System.EventHandler(this.btnLogin_MouseLeave);
            // 
            // lnkRegister
            // 
            this.lnkRegister.AutoSize = false;
            this.lnkRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnkRegister.LinkColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.lnkRegister.Location = new System.Drawing.Point(40, 260);
            this.lnkRegister.Name = "lnkRegister";
            this.lnkRegister.Size = new System.Drawing.Size(270, 20);
            this.lnkRegister.TabIndex = 4;
            this.lnkRegister.TabStop = true;
            this.lnkRegister.Text = "Belum punya akun? Daftar";
            this.lnkRegister.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkRegister.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkRegister_LinkClicked);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlGlass);
            this.Controls.Add(this.picBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "LoginForm";
            this.Text = "Login - Waste Management System";
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.pnlGlass.ResumeLayout(false);
            this.pnlPassword.ResumeLayout(false);
            this.pnlPassword.PerformLayout();
            this.pnlUsername.ResumeLayout(false);
            this.pnlUsername.PerformLayout();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox picBackground;
        private System.Windows.Forms.Panel pnlGlass;
        private System.Windows.Forms.Panel pnlUsername;
        private System.Windows.Forms.Panel pnlPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblUsernameIcon;
        private System.Windows.Forms.Label lblPasswordIcon;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.LinkLabel lnkRegister;
        private System.Windows.Forms.Label lblTitle;
    }
}
