namespace WasteManagementSystem.Forms
{
    partial class RegisterForm
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
            this.lnkLogin = new System.Windows.Forms.LinkLabel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.pnlRole = new System.Windows.Forms.Panel();
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.lblRoleIcon = new System.Windows.Forms.Label();
            this.pnlFullName = new System.Windows.Forms.Panel();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFullNameIcon = new System.Windows.Forms.Label();
            this.pnlPassword = new System.Windows.Forms.Panel();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPasswordIcon = new System.Windows.Forms.Label();
            this.pnlUsername = new System.Windows.Forms.Panel();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblUsernameIcon = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).BeginInit();
            this.pnlGlass.SuspendLayout();
            this.pnlRole.SuspendLayout();
            this.pnlFullName.SuspendLayout();
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
            this.pnlGlass.Controls.Add(this.lnkLogin);
            this.pnlGlass.Controls.Add(this.btnRegister);
            this.pnlGlass.Controls.Add(this.pnlRole);
            this.pnlGlass.Controls.Add(this.pnlFullName);
            this.pnlGlass.Controls.Add(this.pnlPassword);
            this.pnlGlass.Controls.Add(this.pnlUsername);
            this.pnlGlass.Controls.Add(this.lblTitle);
            this.pnlGlass.Location = new System.Drawing.Point(325, 100);
            this.pnlGlass.Name = "pnlGlass";
            this.pnlGlass.Size = new System.Drawing.Size(350, 400);
            this.pnlGlass.TabIndex = 1;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = false;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.lblTitle.Location = new System.Drawing.Point(0, 20);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(350, 50);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "DAFTAR";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlUsername
            // 
            this.pnlUsername.BackColor = System.Drawing.Color.Transparent;
            this.pnlUsername.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlUsername.Controls.Add(this.lblUsernameIcon);
            this.pnlUsername.Controls.Add(this.txtUsername);
            this.pnlUsername.Location = new System.Drawing.Point(40, 85);
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
            this.pnlPassword.Location = new System.Drawing.Point(40, 135);
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
            // pnlFullName
            // 
            this.pnlFullName.BackColor = System.Drawing.Color.Transparent;
            this.pnlFullName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFullName.Controls.Add(this.lblFullNameIcon);
            this.pnlFullName.Controls.Add(this.txtFullName);
            this.pnlFullName.Location = new System.Drawing.Point(40, 185);
            this.pnlFullName.Name = "pnlFullName";
            this.pnlFullName.Size = new System.Drawing.Size(270, 40);
            this.pnlFullName.TabIndex = 3;
            // 
            // lblFullNameIcon
            // 
            this.lblFullNameIcon.AutoSize = false;
            this.lblFullNameIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblFullNameIcon.ForeColor = System.Drawing.Color.Gray;
            this.lblFullNameIcon.Location = new System.Drawing.Point(8, 8);
            this.lblFullNameIcon.Name = "lblFullNameIcon";
            this.lblFullNameIcon.Size = new System.Drawing.Size(30, 24);
            this.lblFullNameIcon.TabIndex = 0;
            this.lblFullNameIcon.Text = "✏️";
            this.lblFullNameIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFullName
            // 
            this.txtFullName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtFullName.ForeColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.txtFullName.Location = new System.Drawing.Point(45, 10);
            this.txtFullName.Name = "txtFullName";
            this.txtFullName.PlaceholderText = "Nama Lengkap";
            this.txtFullName.Size = new System.Drawing.Size(215, 20);
            this.txtFullName.TabIndex = 2;
            // 
            // pnlRole
            // 
            this.pnlRole.BackColor = System.Drawing.Color.Transparent;
            this.pnlRole.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlRole.Controls.Add(this.lblRoleIcon);
            this.pnlRole.Controls.Add(this.cmbRole);
            this.pnlRole.Location = new System.Drawing.Point(40, 235);
            this.pnlRole.Name = "pnlRole";
            this.pnlRole.Size = new System.Drawing.Size(270, 40);
            this.pnlRole.TabIndex = 4;
            // 
            // lblRoleIcon
            // 
            this.lblRoleIcon.AutoSize = false;
            this.lblRoleIcon.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblRoleIcon.ForeColor = System.Drawing.Color.Gray;
            this.lblRoleIcon.Location = new System.Drawing.Point(8, 8);
            this.lblRoleIcon.Name = "lblRoleIcon";
            this.lblRoleIcon.Size = new System.Drawing.Size(30, 24);
            this.lblRoleIcon.TabIndex = 0;
            this.lblRoleIcon.Text = "👥";
            this.lblRoleIcon.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cmbRole
            // 
            this.cmbRole.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbRole.ForeColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Masyarakat",
            "Petugas"});
            this.cmbRole.Location = new System.Drawing.Point(45, 7);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(215, 28);
            this.cmbRole.TabIndex = 3;
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(40, 290);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(270, 40);
            this.btnRegister.TabIndex = 5;
            this.btnRegister.Text = "DAFTAR";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            this.btnRegister.MouseEnter += new System.EventHandler(this.btnRegister_MouseEnter);
            this.btnRegister.MouseLeave += new System.EventHandler(this.btnRegister_MouseLeave);
            // 
            // lnkLogin
            // 
            this.lnkLogin.AutoSize = false;
            this.lnkLogin.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lnkLogin.LinkColor = System.Drawing.Color.FromArgb(47, 79, 79);
            this.lnkLogin.Location = new System.Drawing.Point(40, 345);
            this.lnkLogin.Name = "lnkLogin";
            this.lnkLogin.Size = new System.Drawing.Size(270, 20);
            this.lnkLogin.TabIndex = 6;
            this.lnkLogin.TabStop = true;
            this.lnkLogin.Text = "Sudah punya akun? Login";
            this.lnkLogin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkLogin.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkLogin_LinkClicked);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.pnlGlass);
            this.Controls.Add(this.picBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Name = "RegisterForm";
            this.Text = "Register - Waste Management System";
            ((System.ComponentModel.ISupportInitialize)(this.picBackground)).EndInit();
            this.pnlGlass.ResumeLayout(false);
            this.pnlRole.ResumeLayout(false);
            this.pnlFullName.ResumeLayout(false);
            this.pnlFullName.PerformLayout();
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
        private System.Windows.Forms.Panel pnlFullName;
        private System.Windows.Forms.Panel pnlRole;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.Label lblUsernameIcon;
        private System.Windows.Forms.Label lblPasswordIcon;
        private System.Windows.Forms.Label lblFullNameIcon;
        private System.Windows.Forms.Label lblRoleIcon;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.LinkLabel lnkLogin;
        private System.Windows.Forms.Label lblTitle;
    }
}
