using System;
using System.Drawing;
using System.Windows.Forms;
using taskt_new.UI.Controls;

namespace taskt_new
{
    public partial class MainForm : Form
    {
        private SplitContainer mainSplitContainer;
        private SplitContainer rightSplitContainer;
        private AIChatControl aiChatControl;
        private TreeView fileExplorer;
        private Panel rpaEditPanel;

        public MainForm()
        {
            InitializeComponent();
            SetupTheme();
        }

        private void InitializeComponent()
        {
            // 主分隔容器（左側與右側）
            mainSplitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 200  // 左側寬度
            };

            // 右側分隔容器（RPA編輯區與AI對話區）
            rightSplitContainer = new SplitContainer
            {
                Dock = DockStyle.Fill,
                Orientation = Orientation.Vertical,
                SplitterDistance = 600  // RPA編輯區寬度
            };

            // 檔案總管
            fileExplorer = new TreeView
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 30, 30),
                ForeColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // 初始化檔案總管節點
            var rootNode = fileExplorer.Nodes.Add("RPA指令");
            rootNode.Nodes.Add("系統指令");
            rootNode.Nodes.Add("任務指令");
            rootNode.Nodes.Add("其他指令");
            rootNode.ExpandAll();

            // RPA編輯區域
            rpaEditPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(30, 30, 30)
            };

            // AI對話控制項
            aiChatControl = new AIChatControl
            {
                Dock = DockStyle.Fill,
                Visible = true
            };

            // 加入控制項到分隔容器
            mainSplitContainer.Panel1.Controls.Add(fileExplorer);
            rightSplitContainer.Panel1.Controls.Add(rpaEditPanel);
            rightSplitContainer.Panel2.Controls.Add(aiChatControl);
            mainSplitContainer.Panel2.Controls.Add(rightSplitContainer);

            // 設定主視窗屬性
            this.Controls.Add(mainSplitContainer);
            this.Size = new Size(1200, 800);
            this.Text = "TF-AI RPA Assistant";
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private void SetupTheme()
        {
            // 設定深色主題
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;
        }

        // 控制 AI 對話區域顯示/隱藏
        private void ToggleAIChatPanel()
        {
            aiChatControl.Visible = !aiChatControl.Visible;
            rightSplitContainer.Panel2Collapsed = !aiChatControl.Visible;
        }
    }
}
