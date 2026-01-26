using System;
using System.Drawing;
using System.Windows.Forms;
using WasteManagementSystem.Services;

namespace WasteManagementSystem.Controls
{
    public partial class ChatControl : UserControl
    {
        private ChatService _chatService;

        public ChatControl()
        {
            InitializeComponent();
            _chatService = new ChatService();
            AppendMessage("Bot", "Halo! Mau tanya apa tentang sampah?");
        }

        private async void btnSend_Click(object sender, EventArgs e)
        {
            await SendMessageAsync();
        }

        private async void txtInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                await SendMessageAsync();
            }
        }

        private async Task SendMessageAsync()
        {
            string msg = txtInput.Text.Trim();
            if (string.IsNullOrEmpty(msg)) return;

            AppendMessage("You", msg);
            txtInput.Text = "";

            // Disable input while waiting
            txtInput.Enabled = false;
            btnSend.Enabled = false;

            string response = await _chatService.GetResponseAsync(msg);
            
            AppendMessage("Bot", response);

            txtInput.Enabled = true;
            btnSend.Enabled = true;
            txtInput.Focus();
        }

        private void AppendMessage(string sender, string message)
        {
            rtbChat.SelectionColor = sender == "Bot" ? Color.SeaGreen : Color.Black;
            rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Bold);
            rtbChat.AppendText(sender + ": ");
            
            rtbChat.SelectionColor = Color.Black;
            rtbChat.SelectionFont = new Font(rtbChat.Font, FontStyle.Regular);
            rtbChat.AppendText(message + Environment.NewLine + Environment.NewLine);
            
            rtbChat.ScrollToCaret();
        }
    }
}
