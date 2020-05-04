namespace AsteriskPhoneAgent
{
    partial class AsteriskPhoneAgentForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
        	this.components = new System.ComponentModel.Container();
        	System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AsteriskPhoneAgentForm));
        	this.Tray = new System.Windows.Forms.NotifyIcon(this.components);
        	this.SearchTextBox = new System.Windows.Forms.TextBox();
        	this.ContactsTreeView = new System.Windows.Forms.TreeView();
        	this.ContactsImageList = new System.Windows.Forms.ImageList(this.components);
        	this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.ExitButton = new System.Windows.Forms.Button();
        	this.RingButton = new System.Windows.Forms.Button();
        	this.AddButton = new System.Windows.Forms.Button();
        	this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
        	this.ClearFindButton = new System.Windows.Forms.Button();
        	this.panel1 = new System.Windows.Forms.Panel();
        	this.FindTreeView = new System.Windows.Forms.TreeView();
        	this.ContextMenuImageList = new System.Windows.Forms.ImageList(this.components);
        	this.contextMenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
        	this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.preferencesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
        	this.btSetup = new System.Windows.Forms.Button();
        	this.btHistory = new System.Windows.Forms.Button();
        	this.contextMenuTray.SuspendLayout();
        	this.SuspendLayout();
        	// 
        	// Tray
        	// 
        	this.Tray.Icon = ((System.Drawing.Icon)(resources.GetObject("Tray.Icon")));
        	this.Tray.Text = "AsteriskPhoneAgent";
        	this.Tray.Visible = true;
        	this.Tray.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Tray_MouseClick);
        	this.Tray.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.TrayMouseDoubleClick);
        	// 
        	// SearchTextBox
        	// 
        	this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.SearchTextBox.BackColor = System.Drawing.SystemColors.Window;
        	this.SearchTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.SearchTextBox.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.SearchTextBox.Location = new System.Drawing.Point(15, 11);
        	this.SearchTextBox.Name = "SearchTextBox";
        	this.SearchTextBox.Size = new System.Drawing.Size(256, 16);
        	this.SearchTextBox.TabIndex = 4;
        	this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
        	// 
        	// ContactsTreeView
        	// 
        	this.ContactsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.ContactsTreeView.BackColor = System.Drawing.SystemColors.Window;
        	this.ContactsTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.ContactsTreeView.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.ContactsTreeView.FullRowSelect = true;
        	this.ContactsTreeView.HideSelection = false;
        	this.ContactsTreeView.ImageIndex = 0;
        	this.ContactsTreeView.ImageList = this.ContactsImageList;
        	this.ContactsTreeView.Location = new System.Drawing.Point(12, 35);
        	this.ContactsTreeView.Name = "ContactsTreeView";
        	this.ContactsTreeView.SelectedImageIndex = 0;
        	this.ContactsTreeView.ShowLines = false;
        	this.ContactsTreeView.ShowPlusMinus = false;
        	this.ContactsTreeView.ShowRootLines = false;
        	this.ContactsTreeView.Size = new System.Drawing.Size(284, 435);
        	this.ContactsTreeView.TabIndex = 5;
        	this.ContactsTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FindTreeView_NodeMouseClick);
        	this.ContactsTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FindTreeView_NodeMouseDoubleClick);
        	// 
        	// ContactsImageList
        	// 
        	this.ContactsImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ContactsImageList.ImageStream")));
        	this.ContactsImageList.TransparentColor = System.Drawing.Color.Transparent;
        	this.ContactsImageList.Images.SetKeyName(0, "user-business.png");
        	this.ContactsImageList.Images.SetKeyName(1, "mobile-phone-cast.png");
        	this.ContactsImageList.Images.SetKeyName(2, "mobile-phone.png");
        	this.ContactsImageList.Images.SetKeyName(3, "telephone.png");
        	this.ContactsImageList.Images.SetKeyName(4, "user-red.png");
        	this.ContactsImageList.Images.SetKeyName(5, "user-yellow.png");
        	// 
        	// contextMenuStrip1
        	// 
        	this.contextMenuStrip1.Name = "contextMenuStrip1";
        	this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
        	this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip1Opening);
        	// 
        	// ExitButton
        	// 
        	this.ExitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
        	this.ExitButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
        	this.ExitButton.FlatAppearance.BorderSize = 0;
        	this.ExitButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
        	this.ExitButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
        	this.ExitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.ExitButton.Image = ((System.Drawing.Image)(resources.GetObject("ExitButton.Image")));
        	this.ExitButton.Location = new System.Drawing.Point(264, 475);
        	this.ExitButton.Name = "ExitButton";
        	this.ExitButton.Size = new System.Drawing.Size(36, 36);
        	this.ExitButton.TabIndex = 10;
        	this.ExitButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        	this.ExitButton.UseVisualStyleBackColor = true;
        	this.ExitButton.Click += new System.EventHandler(this.ExitButton_Click);
        	// 
        	// RingButton
        	// 
        	this.RingButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.RingButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
        	this.RingButton.FlatAppearance.BorderSize = 0;
        	this.RingButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
        	this.RingButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
        	this.RingButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.RingButton.Image = ((System.Drawing.Image)(resources.GetObject("RingButton.Image")));
        	this.RingButton.Location = new System.Drawing.Point(12, 475);
        	this.RingButton.Name = "RingButton";
        	this.RingButton.Size = new System.Drawing.Size(36, 36);
        	this.RingButton.TabIndex = 6;
        	this.RingButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        	this.RingButton.UseVisualStyleBackColor = true;
        	this.RingButton.Click += new System.EventHandler(this.RingButton_Click);
        	// 
        	// AddButton
        	// 
        	this.AddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.AddButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
        	this.AddButton.FlatAppearance.BorderSize = 0;
        	this.AddButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
        	this.AddButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
        	this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.AddButton.Image = ((System.Drawing.Image)(resources.GetObject("AddButton.Image")));
        	this.AddButton.Location = new System.Drawing.Point(54, 475);
        	this.AddButton.Name = "AddButton";
        	this.AddButton.Size = new System.Drawing.Size(36, 36);
        	this.AddButton.TabIndex = 7;
        	this.AddButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        	this.AddButton.UseVisualStyleBackColor = true;
        	this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
        	// 
        	// toolTip1
        	// 
        	this.toolTip1.IsBalloon = true;
        	this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.ToolTip1Popup);
        	// 
        	// ClearFindButton
        	// 
        	this.ClearFindButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
        	this.ClearFindButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
        	this.ClearFindButton.FlatAppearance.BorderSize = 0;
        	this.ClearFindButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Window;
        	this.ClearFindButton.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.Window;
        	this.ClearFindButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.ClearFindButton.Image = ((System.Drawing.Image)(resources.GetObject("ClearFindButton.Image")));
        	this.ClearFindButton.Location = new System.Drawing.Point(273, 9);
        	this.ClearFindButton.Name = "ClearFindButton";
        	this.ClearFindButton.Size = new System.Drawing.Size(20, 20);
        	this.ClearFindButton.TabIndex = 12;
        	this.ClearFindButton.UseVisualStyleBackColor = true;
        	this.ClearFindButton.Click += new System.EventHandler(this.ClearFindButton_Click);
        	// 
        	// panel1
        	// 
        	this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
        	this.panel1.Location = new System.Drawing.Point(12, 8);
        	this.panel1.Name = "panel1";
        	this.panel1.Size = new System.Drawing.Size(284, 23);
        	this.panel1.TabIndex = 13;
        	// 
        	// FindTreeView
        	// 
        	this.FindTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        	        	        	| System.Windows.Forms.AnchorStyles.Left) 
        	        	        	| System.Windows.Forms.AnchorStyles.Right)));
        	this.FindTreeView.BackColor = System.Drawing.SystemColors.Window;
        	this.FindTreeView.BorderStyle = System.Windows.Forms.BorderStyle.None;
        	this.FindTreeView.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
        	this.FindTreeView.FullRowSelect = true;
        	this.FindTreeView.HideSelection = false;
        	this.FindTreeView.ImageIndex = 0;
        	this.FindTreeView.ImageList = this.ContactsImageList;
        	this.FindTreeView.Location = new System.Drawing.Point(12, 35);
        	this.FindTreeView.Name = "FindTreeView";
        	this.FindTreeView.SelectedImageIndex = 0;
        	this.FindTreeView.ShowLines = false;
        	this.FindTreeView.ShowPlusMinus = false;
        	this.FindTreeView.ShowRootLines = false;
        	this.FindTreeView.Size = new System.Drawing.Size(284, 435);
        	this.FindTreeView.TabIndex = 14;
        	this.FindTreeView.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FindTreeView_NodeMouseClick);
        	this.FindTreeView.NodeMouseDoubleClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.FindTreeView_NodeMouseDoubleClick);
        	// 
        	// ContextMenuImageList
        	// 
        	this.ContextMenuImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ContextMenuImageList.ImageStream")));
        	this.ContextMenuImageList.TransparentColor = System.Drawing.Color.Transparent;
        	this.ContextMenuImageList.Images.SetKeyName(0, "user-business.png");
        	this.ContextMenuImageList.Images.SetKeyName(1, "telephone.png");
        	this.ContextMenuImageList.Images.SetKeyName(2, "edit.png");
        	this.ContextMenuImageList.Images.SetKeyName(3, "database-delete.png");
        	// 
        	// contextMenuTray
        	// 
        	this.contextMenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
        	        	        	this.aboutToolStripMenuItem,
        	        	        	this.preferencesToolStripMenuItem,
        	        	        	this.openToolStripMenuItem,
        	        	        	this.exitToolStripMenuItem});
        	this.contextMenuTray.Name = "contextMenuStrip1";
        	this.contextMenuTray.Size = new System.Drawing.Size(136, 92);
        	this.contextMenuTray.Opening += new System.ComponentModel.CancelEventHandler(this.ContextMenuStrip2Opening);
        	// 
        	// aboutToolStripMenuItem
        	// 
        	this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
        	this.aboutToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
        	this.aboutToolStripMenuItem.Text = "About";
        	this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
        	// 
        	// preferencesToolStripMenuItem
        	// 
        	this.preferencesToolStripMenuItem.Name = "preferencesToolStripMenuItem";
        	this.preferencesToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
        	this.preferencesToolStripMenuItem.Text = "Preferences";
        	this.preferencesToolStripMenuItem.Click += new System.EventHandler(this.PreferencesToolStripMenuItemClick);
        	// 
        	// openToolStripMenuItem
        	// 
        	this.openToolStripMenuItem.Name = "openToolStripMenuItem";
        	this.openToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
        	this.openToolStripMenuItem.Text = "Open";
        	this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItemClick);
        	// 
        	// exitToolStripMenuItem
        	// 
        	this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
        	this.exitToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
        	this.exitToolStripMenuItem.Text = "Exit";
        	this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
        	// 
        	// btSetup
        	// 
        	this.btSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.btSetup.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
        	this.btSetup.FlatAppearance.BorderSize = 0;
        	this.btSetup.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
        	this.btSetup.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
        	this.btSetup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btSetup.Image = ((System.Drawing.Image)(resources.GetObject("btSetup.Image")));
        	this.btSetup.Location = new System.Drawing.Point(138, 475);
        	this.btSetup.Name = "btSetup";
        	this.btSetup.Size = new System.Drawing.Size(36, 36);
        	this.btSetup.TabIndex = 15;
        	this.btSetup.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        	this.btSetup.UseVisualStyleBackColor = true;
        	this.btSetup.Click += new System.EventHandler(this.BtSetupClick);
        	// 
        	// btHistory
        	// 
        	this.btHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
        	this.btHistory.FlatAppearance.BorderColor = System.Drawing.SystemColors.Window;
        	this.btHistory.FlatAppearance.BorderSize = 0;
        	this.btHistory.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveBorder;
        	this.btHistory.FlatAppearance.MouseOverBackColor = System.Drawing.SystemColors.GradientActiveCaption;
        	this.btHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
        	this.btHistory.Image = ((System.Drawing.Image)(resources.GetObject("btHistory.Image")));
        	this.btHistory.Location = new System.Drawing.Point(96, 476);
        	this.btHistory.Name = "btHistory";
        	this.btHistory.Size = new System.Drawing.Size(36, 36);
        	this.btHistory.TabIndex = 16;
        	this.btHistory.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
        	this.btHistory.UseVisualStyleBackColor = true;
        	this.btHistory.Click += new System.EventHandler(this.BtHistoryClick);
        	// 
        	// AsteriskPhoneAgentForm
        	// 
        	this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
        	this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        	this.BackColor = System.Drawing.SystemColors.Window;
        	this.ClientSize = new System.Drawing.Size(308, 517);
        	this.Controls.Add(this.btHistory);
        	this.Controls.Add(this.btSetup);
        	this.Controls.Add(this.FindTreeView);
        	this.Controls.Add(this.SearchTextBox);
        	this.Controls.Add(this.ClearFindButton);
        	this.Controls.Add(this.AddButton);
        	this.Controls.Add(this.ExitButton);
        	this.Controls.Add(this.RingButton);
        	this.Controls.Add(this.panel1);
        	this.Controls.Add(this.ContactsTreeView);
        	this.DoubleBuffered = true;
        	this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
        	this.MaximizeBox = false;
        	this.Name = "AsteriskPhoneAgentForm";
        	this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        	this.Text = "AsteriskPhoneAgent";
        	this.Activated += new System.EventHandler(this.AsteriskPhoneAgentFormActivated);
        	this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAsterNotify_FormClosing);
        	this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.AsteriskPhoneAgentFormFormClosed);
        	this.Load += new System.EventHandler(this.FormAsterNotify_Load);
        	this.contextMenuTray.ResumeLayout(false);
        	this.ResumeLayout(false);
        	this.PerformLayout();
        }
        private System.Windows.Forms.Button btHistory;
        private System.Windows.Forms.Button btSetup;
        private System.Windows.Forms.ToolStripMenuItem preferencesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip contextMenuTray;

        #endregion

        private System.Windows.Forms.NotifyIcon Tray;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.TreeView ContactsTreeView;
        private System.Windows.Forms.ImageList ContactsImageList;
        private System.Windows.Forms.Button ExitButton;
        private System.Windows.Forms.Button RingButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button ClearFindButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TreeView FindTreeView;
        private System.Windows.Forms.ImageList ContextMenuImageList;
    }
}

