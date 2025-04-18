namespace MessengerUI
{
    public partial class BaseForm : Form
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            connectToolStripMenuItem = new ToolStripMenuItem();
            disconnectToolStripMenuItem = new ToolStripMenuItem();
            joinToolStripMenuItem = new ToolStripMenuItem();
            createRoomToolStripMenuItem = new ToolStripMenuItem();
            leaveRoomToolStripMenuItem = new ToolStripMenuItem();
            setNameToolStripMenuItem = new ToolStripMenuItem();
            splitContainer1 = new SplitContainer();
            onlineUsers = new ListBox();
            tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel1 = new TableLayoutPanel();
            sendButton = new Button();
            textField = new TextBox();
            chat = new TextBox();
            menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            tableLayoutPanel.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { connectToolStripMenuItem, disconnectToolStripMenuItem, joinToolStripMenuItem, createRoomToolStripMenuItem, leaveRoomToolStripMenuItem, setNameToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(800, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // connectToolStripMenuItem
            // 
            connectToolStripMenuItem.Name = "connectToolStripMenuItem";
            connectToolStripMenuItem.Size = new Size(77, 24);
            connectToolStripMenuItem.Text = "Connect";
            connectToolStripMenuItem.Click += connectToolStripMenuItem_Click;
            // 
            // disconnectToolStripMenuItem
            // 
            disconnectToolStripMenuItem.Enabled = false;
            disconnectToolStripMenuItem.Name = "disconnectToolStripMenuItem";
            disconnectToolStripMenuItem.Size = new Size(96, 24);
            disconnectToolStripMenuItem.Text = "Disconnect";
            disconnectToolStripMenuItem.Click += disconnectToolStripMenuItem_Click;
            // 
            // joinToolStripMenuItem
            // 
            joinToolStripMenuItem.Enabled = false;
            joinToolStripMenuItem.Name = "joinToolStripMenuItem";
            joinToolStripMenuItem.Size = new Size(49, 24);
            joinToolStripMenuItem.Text = "Join";
            joinToolStripMenuItem.Click += joinToolStripMenuItem_Click;
            // 
            // createRoomToolStripMenuItem
            // 
            createRoomToolStripMenuItem.Enabled = false;
            createRoomToolStripMenuItem.Name = "createRoomToolStripMenuItem";
            createRoomToolStripMenuItem.Size = new Size(110, 24);
            createRoomToolStripMenuItem.Text = "Create Room";
            createRoomToolStripMenuItem.Click += createRoomToolStripMenuItem_Click;
            // 
            // leaveRoomToolStripMenuItem
            // 
            leaveRoomToolStripMenuItem.Enabled = false;
            leaveRoomToolStripMenuItem.Name = "leaveRoomToolStripMenuItem";
            leaveRoomToolStripMenuItem.Size = new Size(105, 24);
            leaveRoomToolStripMenuItem.Text = "Leave Room";
            leaveRoomToolStripMenuItem.Click += leaveRoomToolStripMenuItem_Click;
            // 
            // setNameToolStripMenuItem
            // 
            setNameToolStripMenuItem.Enabled = false;
            setNameToolStripMenuItem.Name = "setNameToolStripMenuItem";
            setNameToolStripMenuItem.Size = new Size(85, 24);
            setNameToolStripMenuItem.Text = "Set name";
            setNameToolStripMenuItem.Click += setNameToolStripMenuItem_Click;
            // 
            // splitContainer1
            // 
            splitContainer1.Dock = DockStyle.Fill;
            splitContainer1.Location = new Point(0, 28);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(onlineUsers);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(tableLayoutPanel);
            splitContainer1.Size = new Size(800, 422);
            splitContainer1.SplitterDistance = 100;
            splitContainer1.TabIndex = 1;
            // 
            // onlineUsers
            // 
            onlineUsers.BorderStyle = BorderStyle.FixedSingle;
            onlineUsers.Dock = DockStyle.Fill;
            onlineUsers.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            onlineUsers.FormattingEnabled = true;
            onlineUsers.HorizontalScrollbar = true;
            onlineUsers.ItemHeight = 37;
            onlineUsers.Location = new Point(0, 0);
            onlineUsers.Name = "onlineUsers";
            onlineUsers.Size = new Size(100, 422);
            onlineUsers.TabIndex = 0;
            // 
            // tableLayoutPanel
            // 
            tableLayoutPanel.ColumnCount = 1;
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel.Controls.Add(tableLayoutPanel1, 0, 1);
            tableLayoutPanel.Controls.Add(chat, 0, 0);
            tableLayoutPanel.Dock = DockStyle.Fill;
            tableLayoutPanel.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            tableLayoutPanel.Location = new Point(0, 0);
            tableLayoutPanel.Name = "tableLayoutPanel";
            tableLayoutPanel.RowCount = 2;
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 71.80095F));
            tableLayoutPanel.RowStyles.Add(new RowStyle(SizeType.Percent, 28.1990528F));
            tableLayoutPanel.Size = new Size(696, 422);
            tableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 77.8625946F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.1374054F));
            tableLayoutPanel1.Controls.Add(sendButton, 1, 0);
            tableLayoutPanel1.Controls.Add(textField, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(3, 306);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Size = new Size(690, 113);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // sendButton
            // 
            sendButton.Anchor = AnchorStyles.Top;
            sendButton.Enabled = false;
            sendButton.Location = new Point(558, 3);
            sendButton.MaximumSize = new Size(110, 30);
            sendButton.Name = "sendButton";
            sendButton.Size = new Size(110, 30);
            sendButton.TabIndex = 0;
            sendButton.Text = "Send";
            sendButton.UseVisualStyleBackColor = true;
            sendButton.Click += sendButton_Click;
            // 
            // textField
            // 
            textField.Dock = DockStyle.Fill;
            textField.Location = new Point(3, 3);
            textField.Margin = new Padding(3, 3, 3, 10);
            textField.Multiline = true;
            textField.Name = "textField";
            textField.Size = new Size(531, 100);
            textField.TabIndex = 1;
            // 
            // chat
            // 
            chat.Dock = DockStyle.Fill;
            chat.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 204);
            chat.Location = new Point(3, 3);
            chat.Multiline = true;
            chat.Name = "chat";
            chat.ReadOnly = true;
            chat.Size = new Size(690, 297);
            chat.TabIndex = 1;
            // 
            // BaseForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(splitContainer1);
            Controls.Add(menuStrip1);
            Name = "BaseForm";
            Text = "MessengerClient";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            tableLayoutPanel.ResumeLayout(false);
            tableLayoutPanel.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem joinToolStripMenuItem;
        private SplitContainer splitContainer1;
        private ListBox onlineUsers;
        private ToolStripMenuItem connectToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel;
        private TableLayoutPanel tableLayoutPanel1;
        private Button sendButton;
        private TextBox textField;
        private TextBox chat;
        private ToolStripMenuItem createRoomToolStripMenuItem;
        private ToolStripMenuItem leaveRoomToolStripMenuItem;
        private ToolStripMenuItem disconnectToolStripMenuItem;
        private ToolStripMenuItem setNameToolStripMenuItem;
    }
}
