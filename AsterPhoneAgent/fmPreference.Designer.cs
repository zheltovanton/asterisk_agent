
namespace AsteriskPhoneAgent
{
	partial class fmPreference
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
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
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tbSerial = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cbLogging = new System.Windows.Forms.CheckBox();
            this.cbSystemNotification = new System.Windows.Forms.CheckBox();
            this.cbLoadMinimized = new System.Windows.Forms.CheckBox();
            this.cbLoadonWindows = new System.Windows.Forms.CheckBox();
            this.cbShowImportant = new System.Windows.Forms.CheckBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label19 = new System.Windows.Forms.Label();
            this.tbExternalCallPrefix = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbManagerPassword = new System.Windows.Forms.MaskedTextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tbPeerNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tbOriginatePriority = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tbOriginateTimeout = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tbOriginateContext = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tbManagerLogin = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbServerPort = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbServerIP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCCAutoOpenOnAnswer = new System.Windows.Forms.CheckBox();
            this.cbCCAutoOpenUrl = new System.Windows.Forms.CheckBox();
            this.cbCallCenterEnable = new System.Windows.Forms.CheckBox();
            this.tbCallCenterSite = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tbDBstring = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbDBPassword = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tbDBUser = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tbDBIP = new System.Windows.Forms.TextBox();
            this.tbDBIP1 = new System.Windows.Forms.Label();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.tbDBName1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btSave = new System.Windows.Forms.Button();
            this.btClose = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(701, 550);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tbSerial);
            this.tabPage1.Controls.Add(this.label25);
            this.tabPage1.Controls.Add(this.label24);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label23);
            this.tabPage1.Controls.Add(this.label22);
            this.tabPage1.Controls.Add(this.label21);
            this.tabPage1.Controls.Add(this.label20);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Controls.Add(this.cbLogging);
            this.tabPage1.Controls.Add(this.cbSystemNotification);
            this.tabPage1.Controls.Add(this.cbLoadMinimized);
            this.tabPage1.Controls.Add(this.cbLoadonWindows);
            this.tabPage1.Controls.Add(this.cbShowImportant);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Size = new System.Drawing.Size(693, 521);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tbSerial
            // 
            this.tbSerial.Location = new System.Drawing.Point(85, 273);
            this.tbSerial.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbSerial.Name = "tbSerial";
            this.tbSerial.Size = new System.Drawing.Size(405, 22);
            this.tbSerial.TabIndex = 40;
            // 
            // label25
            // 
            this.label25.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label25.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.label25.Location = new System.Drawing.Point(184, 354);
            this.label25.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(232, 23);
            this.label25.TabIndex = 39;
            this.label25.Text = "http://AsteriskPhoneAgent.com";
            this.label25.Click += new System.EventHandler(this.Label25Click);
            this.label25.MouseLeave += new System.EventHandler(this.Label25MouseLeave);
            this.label25.MouseHover += new System.EventHandler(this.Label25MouseHover);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(37, 354);
            this.label24.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(144, 23);
            this.label24.TabIndex = 38;
            this.label24.Text = "visit site for serial key";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(500, 272);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 28);
            this.button1.TabIndex = 37;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1Click);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(36, 329);
            this.label23.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(564, 22);
            this.label23.TabIndex = 36;
            this.label23.Text = "license key not found";
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(37, 278);
            this.label22.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(41, 22);
            this.label22.TabIndex = 35;
            this.label22.Text = "key";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label21.Location = new System.Drawing.Point(85, 302);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(263, 17);
            this.label21.TabIndex = 34;
            this.label21.Text = "ex. BD58F-3D1E0-23D94-0C8DB-2798A";
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(36, 239);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(133, 18);
            this.label20.TabIndex = 7;
            this.label20.Text = "Activation";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Teal;
            this.panel2.Location = new System.Drawing.Point(20, 219);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(653, 5);
            this.panel2.TabIndex = 6;
            // 
            // cbLogging
            // 
            this.cbLogging.Location = new System.Drawing.Point(31, 169);
            this.cbLogging.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLogging.Name = "cbLogging";
            this.cbLogging.Size = new System.Drawing.Size(404, 30);
            this.cbLogging.TabIndex = 5;
            this.cbLogging.Text = "Logging";
            this.cbLogging.UseVisualStyleBackColor = true;
            this.cbLogging.CheckedChanged += new System.EventHandler(this.CbLoggingCheckedChanged);
            this.cbLogging.Click += new System.EventHandler(this.CbShowImportantClick);
            // 
            // cbSystemNotification
            // 
            this.cbSystemNotification.Location = new System.Drawing.Point(31, 132);
            this.cbSystemNotification.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbSystemNotification.Name = "cbSystemNotification";
            this.cbSystemNotification.Size = new System.Drawing.Size(404, 30);
            this.cbSystemNotification.TabIndex = 4;
            this.cbSystemNotification.Text = "Show system notifications";
            this.cbSystemNotification.UseVisualStyleBackColor = true;
            this.cbSystemNotification.Click += new System.EventHandler(this.CbShowImportantClick);
            // 
            // cbLoadMinimized
            // 
            this.cbLoadMinimized.Location = new System.Drawing.Point(31, 95);
            this.cbLoadMinimized.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLoadMinimized.Name = "cbLoadMinimized";
            this.cbLoadMinimized.Size = new System.Drawing.Size(404, 30);
            this.cbLoadMinimized.TabIndex = 3;
            this.cbLoadMinimized.Text = "Load minimized";
            this.cbLoadMinimized.UseVisualStyleBackColor = true;
            this.cbLoadMinimized.Click += new System.EventHandler(this.CbShowImportantClick);
            // 
            // cbLoadonWindows
            // 
            this.cbLoadonWindows.Location = new System.Drawing.Point(31, 58);
            this.cbLoadonWindows.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbLoadonWindows.Name = "cbLoadonWindows";
            this.cbLoadonWindows.Size = new System.Drawing.Size(404, 30);
            this.cbLoadonWindows.TabIndex = 2;
            this.cbLoadonWindows.Text = "Load on Windows startup";
            this.cbLoadonWindows.UseVisualStyleBackColor = true;
            this.cbLoadonWindows.Click += new System.EventHandler(this.CbShowImportantClick);
            // 
            // cbShowImportant
            // 
            this.cbShowImportant.Location = new System.Drawing.Point(31, 21);
            this.cbShowImportant.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbShowImportant.Name = "cbShowImportant";
            this.cbShowImportant.Size = new System.Drawing.Size(404, 30);
            this.cbShowImportant.TabIndex = 1;
            this.cbShowImportant.Text = "Show important callers";
            this.cbShowImportant.UseVisualStyleBackColor = true;
            this.cbShowImportant.Click += new System.EventHandler(this.CbShowImportantClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label19);
            this.tabPage2.Controls.Add(this.tbExternalCallPrefix);
            this.tabPage2.Controls.Add(this.label15);
            this.tabPage2.Controls.Add(this.tbManagerPassword);
            this.tabPage2.Controls.Add(this.label13);
            this.tabPage2.Controls.Add(this.label12);
            this.tabPage2.Controls.Add(this.label11);
            this.tabPage2.Controls.Add(this.label10);
            this.tabPage2.Controls.Add(this.tbPeerNumber);
            this.tabPage2.Controls.Add(this.label9);
            this.tabPage2.Controls.Add(this.tbOriginatePriority);
            this.tabPage2.Controls.Add(this.label8);
            this.tabPage2.Controls.Add(this.tbOriginateTimeout);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.tbOriginateContext);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label5);
            this.tabPage2.Controls.Add(this.tbManagerLogin);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.tbServerPort);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.tbServerIP);
            this.tabPage2.Controls.Add(this.label2);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Size = new System.Drawing.Size(693, 521);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Asterisk";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label19.Location = new System.Drawing.Point(533, 204);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(38, 17);
            this.label19.TabIndex = 36;
            this.label19.Text = "ex. 9";
            // 
            // tbExternalCallPrefix
            // 
            this.tbExternalCallPrefix.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbExternalCallPrefix.Location = new System.Drawing.Point(181, 199);
            this.tbExternalCallPrefix.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbExternalCallPrefix.Name = "tbExternalCallPrefix";
            this.tbExternalCallPrefix.Size = new System.Drawing.Size(343, 27);
            this.tbExternalCallPrefix.TabIndex = 34;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(24, 204);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(122, 17);
            this.label15.TabIndex = 35;
            this.label15.Text = "External call prefix";
            // 
            // tbManagerPassword
            // 
            this.tbManagerPassword.Location = new System.Drawing.Point(181, 129);
            this.tbManagerPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbManagerPassword.Name = "tbManagerPassword";
            this.tbManagerPassword.PasswordChar = '*';
            this.tbManagerPassword.Size = new System.Drawing.Size(343, 22);
            this.tbManagerPassword.TabIndex = 9;
            this.tbManagerPassword.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label13.Location = new System.Drawing.Point(533, 254);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(110, 17);
            this.label13.TabIndex = 33;
            this.label13.Text = "ex. from-internal";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label12.Location = new System.Drawing.Point(533, 97);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(87, 17);
            this.label12.TabIndex = 32;
            this.label12.Text = "def. adm111";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label11.Location = new System.Drawing.Point(533, 69);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 17);
            this.label11.TabIndex = 31;
            this.label11.Text = "def. 5038";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label10.Location = new System.Drawing.Point(533, 169);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(87, 17);
            this.label10.TabIndex = 30;
            this.label10.Text = "ex. SIP/1000";
            // 
            // tbPeerNumber
            // 
            this.tbPeerNumber.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbPeerNumber.Location = new System.Drawing.Point(181, 164);
            this.tbPeerNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbPeerNumber.Name = "tbPeerNumber";
            this.tbPeerNumber.Size = new System.Drawing.Size(343, 27);
            this.tbPeerNumber.TabIndex = 10;
            this.tbPeerNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 169);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 17);
            this.label9.TabIndex = 29;
            this.label9.Text = "Peer number";
            // 
            // tbOriginatePriority
            // 
            this.tbOriginatePriority.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOriginatePriority.Location = new System.Drawing.Point(181, 320);
            this.tbOriginatePriority.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOriginatePriority.Name = "tbOriginatePriority";
            this.tbOriginatePriority.Size = new System.Drawing.Size(343, 27);
            this.tbOriginatePriority.TabIndex = 13;
            this.tbOriginatePriority.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 325);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(117, 17);
            this.label8.TabIndex = 27;
            this.label8.Text = "Originate priority ";
            // 
            // tbOriginateTimeout
            // 
            this.tbOriginateTimeout.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOriginateTimeout.Location = new System.Drawing.Point(181, 284);
            this.tbOriginateTimeout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOriginateTimeout.Name = "tbOriginateTimeout";
            this.tbOriginateTimeout.Size = new System.Drawing.Size(343, 27);
            this.tbOriginateTimeout.TabIndex = 12;
            this.tbOriginateTimeout.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 289);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(116, 17);
            this.label7.TabIndex = 25;
            this.label7.Text = "Originate timeout";
            // 
            // tbOriginateContext
            // 
            this.tbOriginateContext.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbOriginateContext.Location = new System.Drawing.Point(181, 249);
            this.tbOriginateContext.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbOriginateContext.Name = "tbOriginateContext";
            this.tbOriginateContext.Size = new System.Drawing.Size(343, 27);
            this.tbOriginateContext.TabIndex = 11;
            this.tbOriginateContext.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 254);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(115, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Originate context";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 133);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(128, 17);
            this.label5.TabIndex = 21;
            this.label5.Text = "Manager password";
            // 
            // tbManagerLogin
            // 
            this.tbManagerLogin.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbManagerLogin.Location = new System.Drawing.Point(181, 92);
            this.tbManagerLogin.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbManagerLogin.Name = "tbManagerLogin";
            this.tbManagerLogin.Size = new System.Drawing.Size(343, 27);
            this.tbManagerLogin.TabIndex = 8;
            this.tbManagerLogin.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 97);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Manager login";
            // 
            // tbServerPort
            // 
            this.tbServerPort.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbServerPort.Location = new System.Drawing.Point(181, 57);
            this.tbServerPort.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbServerPort.Name = "tbServerPort";
            this.tbServerPort.Size = new System.Drawing.Size(343, 27);
            this.tbServerPort.TabIndex = 7;
            this.tbServerPort.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 62);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 17);
            this.label3.TabIndex = 17;
            this.label3.Text = "Port";
            // 
            // tbServerIP
            // 
            this.tbServerIP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbServerIP.Location = new System.Drawing.Point(181, 21);
            this.tbServerIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbServerIP.Name = "tbServerIP";
            this.tbServerIP.Size = new System.Drawing.Size(343, 27);
            this.tbServerIP.TabIndex = 6;
            this.tbServerIP.TextChanged += new System.EventHandler(this.TbServerIPTextChanged);
            this.tbServerIP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbServerIPKeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 26);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 17);
            this.label2.TabIndex = 15;
            this.label2.Text = "Server IP";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.label1);
            this.tabPage3.Controls.Add(this.cbCCAutoOpenOnAnswer);
            this.tabPage3.Controls.Add(this.cbCCAutoOpenUrl);
            this.tabPage3.Controls.Add(this.cbCallCenterEnable);
            this.tabPage3.Controls.Add(this.tbCallCenterSite);
            this.tabPage3.Controls.Add(this.label16);
            this.tabPage3.Location = new System.Drawing.Point(4, 25);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Size = new System.Drawing.Size(693, 521);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Call Center";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.AppWorkspace;
            this.label1.Location = new System.Drawing.Point(135, 165);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(158, 17);
            this.label1.TabIndex = 33;
            this.label1.Text = "full URL get from server";
            // 
            // cbCCAutoOpenOnAnswer
            // 
            this.cbCCAutoOpenOnAnswer.Location = new System.Drawing.Point(25, 96);
            this.cbCCAutoOpenOnAnswer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCCAutoOpenOnAnswer.Name = "cbCCAutoOpenOnAnswer";
            this.cbCCAutoOpenOnAnswer.Size = new System.Drawing.Size(404, 30);
            this.cbCCAutoOpenOnAnswer.TabIndex = 16;
            this.cbCCAutoOpenOnAnswer.Text = "Open on answer (disabled - open on income call)";
            this.cbCCAutoOpenOnAnswer.UseVisualStyleBackColor = true;
            this.cbCCAutoOpenOnAnswer.Click += new System.EventHandler(this.CbShowImportantClick);
            // 
            // cbCCAutoOpenUrl
            // 
            this.cbCCAutoOpenUrl.Location = new System.Drawing.Point(25, 63);
            this.cbCCAutoOpenUrl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCCAutoOpenUrl.Name = "cbCCAutoOpenUrl";
            this.cbCCAutoOpenUrl.Size = new System.Drawing.Size(404, 30);
            this.cbCCAutoOpenUrl.TabIndex = 15;
            this.cbCCAutoOpenUrl.Text = "Auto open URL";
            this.cbCCAutoOpenUrl.UseVisualStyleBackColor = true;
            this.cbCCAutoOpenUrl.Click += new System.EventHandler(this.CbShowImportantClick);
            // 
            // cbCallCenterEnable
            // 
            this.cbCallCenterEnable.Location = new System.Drawing.Point(25, 31);
            this.cbCallCenterEnable.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbCallCenterEnable.Name = "cbCallCenterEnable";
            this.cbCallCenterEnable.Size = new System.Drawing.Size(404, 30);
            this.cbCallCenterEnable.TabIndex = 14;
            this.cbCallCenterEnable.Text = "Enable Call Center features (need PRO license)";
            this.cbCallCenterEnable.UseVisualStyleBackColor = true;
            this.cbCallCenterEnable.Click += new System.EventHandler(this.CbShowImportantClick);
            // 
            // tbCallCenterSite
            // 
            this.tbCallCenterSite.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbCallCenterSite.Location = new System.Drawing.Point(135, 133);
            this.tbCallCenterSite.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbCallCenterSite.Name = "tbCallCenterSite";
            this.tbCallCenterSite.Size = new System.Drawing.Size(343, 27);
            this.tbCallCenterSite.TabIndex = 17;
            this.tbCallCenterSite.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(24, 139);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(103, 17);
            this.label16.TabIndex = 23;
            this.label16.Text = "Call Center site";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tbDBstring);
            this.tabPage4.Controls.Add(this.label14);
            this.tabPage4.Controls.Add(this.tbDBPassword);
            this.tabPage4.Controls.Add(this.label17);
            this.tabPage4.Controls.Add(this.tbDBUser);
            this.tabPage4.Controls.Add(this.label18);
            this.tabPage4.Controls.Add(this.tbDBIP);
            this.tabPage4.Controls.Add(this.tbDBIP1);
            this.tabPage4.Controls.Add(this.tbDBName);
            this.tabPage4.Controls.Add(this.tbDBName1);
            this.tabPage4.Location = new System.Drawing.Point(4, 25);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Size = new System.Drawing.Size(693, 521);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "MySQL";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tbDBstring
            // 
            this.tbDBstring.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDBstring.Location = new System.Drawing.Point(169, 183);
            this.tbDBstring.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDBstring.Name = "tbDBstring";
            this.tbDBstring.Size = new System.Drawing.Size(512, 27);
            this.tbDBstring.TabIndex = 22;
            this.tbDBstring.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbServerPortKeyPress);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(12, 188);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 17);
            this.label14.TabIndex = 31;
            this.label14.Text = "Custom db string";
            // 
            // tbDBPassword
            // 
            this.tbDBPassword.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDBPassword.Location = new System.Drawing.Point(169, 127);
            this.tbDBPassword.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDBPassword.Name = "tbDBPassword";
            this.tbDBPassword.Size = new System.Drawing.Size(343, 27);
            this.tbDBPassword.TabIndex = 21;
            this.tbDBPassword.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbDBNameKeyUp);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(12, 132);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(92, 17);
            this.label17.TabIndex = 29;
            this.label17.Text = "DB Password";
            // 
            // tbDBUser
            // 
            this.tbDBUser.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDBUser.Location = new System.Drawing.Point(169, 91);
            this.tbDBUser.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDBUser.Name = "tbDBUser";
            this.tbDBUser.Size = new System.Drawing.Size(343, 27);
            this.tbDBUser.TabIndex = 20;
            this.tbDBUser.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbDBNameKeyUp);
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(12, 96);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(61, 17);
            this.label18.TabIndex = 27;
            this.label18.Text = "DB User";
            // 
            // tbDBIP
            // 
            this.tbDBIP.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDBIP.Location = new System.Drawing.Point(169, 55);
            this.tbDBIP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDBIP.Name = "tbDBIP";
            this.tbDBIP.Size = new System.Drawing.Size(343, 27);
            this.tbDBIP.TabIndex = 19;
            this.tbDBIP.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbDBIPKeyUp);
            // 
            // tbDBIP1
            // 
            this.tbDBIP1.AutoSize = true;
            this.tbDBIP1.Location = new System.Drawing.Point(12, 60);
            this.tbDBIP1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbDBIP1.Name = "tbDBIP1";
            this.tbDBIP1.Size = new System.Drawing.Size(43, 17);
            this.tbDBIP1.TabIndex = 25;
            this.tbDBIP1.Text = "DB IP";
            // 
            // tbDBName
            // 
            this.tbDBName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tbDBName.Location = new System.Drawing.Point(169, 20);
            this.tbDBName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(343, 27);
            this.tbDBName.TabIndex = 18;
            this.tbDBName.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TbDBNameKeyUp);
            // 
            // tbDBName1
            // 
            this.tbDBName1.AutoSize = true;
            this.tbDBName1.Location = new System.Drawing.Point(12, 25);
            this.tbDBName1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.tbDBName1.Name = "tbDBName1";
            this.tbDBName1.Size = new System.Drawing.Size(66, 17);
            this.tbDBName1.TabIndex = 23;
            this.tbDBName1.Text = "DB name";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btSave);
            this.panel1.Controls.Add(this.btClose);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 495);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(701, 55);
            this.panel1.TabIndex = 1;
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(16, 15);
            this.btSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(100, 28);
            this.btSave.TabIndex = 13;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.SaveButtonClick);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(124, 15);
            this.btClose.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(100, 28);
            this.btClose.TabIndex = 14;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.ClosebuttonClick);
            // 
            // fmPreference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(701, 550);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControl1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "fmPreference";
            this.Text = "Preferences";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.fmPreference_FormClosed);
            this.Load += new System.EventHandler(this.fmPreferenceLoad);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		private System.Windows.Forms.TextBox tbSerial;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tbExternalCallPrefix;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tbDBstring;
		private System.Windows.Forms.CheckBox cbCCAutoOpenUrl;
		private System.Windows.Forms.CheckBox cbCCAutoOpenOnAnswer;
		private System.Windows.Forms.Label tbDBName1;
		private System.Windows.Forms.TextBox tbDBName;
		private System.Windows.Forms.Label tbDBIP1;
		private System.Windows.Forms.TextBox tbDBIP;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.TextBox tbDBUser;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.TextBox tbDBPassword;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox tbCallCenterSite;
		private System.Windows.Forms.CheckBox cbCallCenterEnable;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox tbServerPort;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox tbManagerLogin;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.MaskedTextBox tbManagerPassword;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox tbOriginateContext;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tbOriginateTimeout;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox tbOriginatePriority;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tbPeerNumber;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox tbServerIP;
		private System.Windows.Forms.Button btClose;
		private System.Windows.Forms.Button btSave;
		private System.Windows.Forms.CheckBox cbSystemNotification;
		private System.Windows.Forms.CheckBox cbLoadMinimized;
		private System.Windows.Forms.CheckBox cbLoadonWindows;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.CheckBox cbShowImportant;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.CheckBox cbLogging;
	}
}
