using System;
using System.Drawing;
using System.Windows.Forms;

namespace taskt_new.UI.Controls
{
    public class AIChatControl : UserControl
    {
        private RichTextBox chatHistory;
        private TextBox chatInput;
        private Button sendButton;
        private Button newChatButton;
        private Label modelLabel;
        private Button copyCodeButton;
        private Button regenerateButton;
        private Button exportButton;

        public AIChatControl()
        {
            InitializeComponent();
            SetupEventHandlers();
        }

        private void InitializeComponent()
        {
            // 聊天歷史記錄
            chatHistory = new RichTextBox
            {
                Dock = DockStyle.Fill,
                ReadOnly = true,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None,
                Margin = new Padding(10)
            };

            // 功能按鈕面板
            var buttonPanel = new FlowLayoutPanel
            {
                Dock = DockStyle.Bottom,
                Height = 40,
                FlowDirection = FlowDirection.RightToLeft,
                BackColor = Color.FromArgb(45, 45, 45),
                Padding = new Padding(5)
            };

            // 複製程式碼按鈕
            copyCodeButton = new Button
            {
                Text = "複製程式碼",
                Width = 100,
                Height = 30,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // 重新生成按鈕
            regenerateButton = new Button
            {
                Text = "重新生成",
                Width = 100,
                Height = 30,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // 匯出按鈕
            exportButton = new Button
            {
                Text = "匯出對話",
                Width = 100,
                Height = 30,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // 輸入區域
            chatInput = new TextBox
            {
                Dock = DockStyle.Bottom,
                Height = 60,
                Multiline = true,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                PlaceholderText = "Plan, search, build anything..."
            };

            // 發送按鈕
            sendButton = new Button
            {
                Text = "Send ▶",
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // 新對話按鈕
            newChatButton = new Button
            {
                Text = "New Chat",
                Dock = DockStyle.Bottom,
                Height = 30,
                BackColor = Color.FromArgb(60, 60, 60),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            // 模型資訊標籤
            modelLabel = new Label
            {
                Text = "Agent claude-3.5-sonnet",
                Dock = DockStyle.Bottom,
                Height = 20,
                BackColor = Color.FromArgb(45, 45, 45),
                ForeColor = Color.FromArgb(86, 156, 214),
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(5, 0, 0, 0)
            };

            // 加入按鈕到按鈕面板
            buttonPanel.Controls.Add(copyCodeButton);
            buttonPanel.Controls.Add(regenerateButton);
            buttonPanel.Controls.Add(exportButton);

            // 加入所有控制項
            this.Controls.Add(chatHistory);
            this.Controls.Add(buttonPanel);
            this.Controls.Add(chatInput);
            this.Controls.Add(sendButton);
            this.Controls.Add(modelLabel);
            this.Controls.Add(newChatButton);

            // 設定控制項大小
            this.Size = new Size(400, 800);
        }

        private void SetupEventHandlers()
        {
            // 發送訊息
            sendButton.Click += (s, e) => SendMessage();
            chatInput.KeyDown += (s, e) =>
            {
                if (e.Control && e.Shift && e.KeyCode == Keys.Enter)
                {
                    SendMessage();
                    e.SuppressKeyPress = true;
                }
            };

            // 新對話
            newChatButton.Click += (s, e) => NewChat();

            // 功能按鈕
            copyCodeButton.Click += (s, e) => CopyCodeToClipboard();
            regenerateButton.Click += (s, e) => RegenerateResponse();
            exportButton.Click += (s, e) => ExportChatHistory();
        }

        private void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(chatInput.Text)) return;

            // 添加使用者訊息
            AppendMessage("User", chatInput.Text, Color.White);

            // TODO: 發送到AI並獲取回應
            // 這裡先模擬AI回應
            AppendMessage("AI", "這是一個測試回應。", Color.FromArgb(0, 255, 180));

            // 清空輸入
            chatInput.Text = string.Empty;
        }

        private void AppendMessage(string sender, string message, Color color)
        {
            chatHistory.SelectionStart = chatHistory.TextLength;
            chatHistory.SelectionLength = 0;
            chatHistory.SelectionColor = color;
            chatHistory.AppendText($"[{sender}] {DateTime.Now:HH:mm:ss}\n{message}\n\n");
            chatHistory.ScrollToCaret();
        }

        private void NewChat()
        {
            chatHistory.Clear();
            chatInput.Clear();
        }

        private void CopyCodeToClipboard()
        {
            // TODO: 實作複製程式碼功能
        }

        private void RegenerateResponse()
        {
            // TODO: 實作重新生成回應功能
        }

        private void ExportChatHistory()
        {
            // TODO: 實作匯出對話功能
        }
    }
}
