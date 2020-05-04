using System;
using System.Configuration;
using System.Drawing;
using System.Collections;
using System.Data;
using System.Net;
using System.Security.Cryptography;
using System.Collections.Specialized;
using System.Windows.Forms;
using System.Text;
using System.Management;
using System.IO;
using Microsoft.Win32;



namespace AsteriskPhoneAgent
{
	/// <summary>
	/// </summary>
	/// 
	
	public partial class fmPreference		: Form
	{
		
 		//-------------------------------------------------------------------------------------------------------------
 
 		static void  Log(String s)
        {
				
 				string logFileName_full = Application.StartupPath + "\\"+ AsteriskPhoneAgentForm.logFileName;  
 				//MessageBox.Show(logFileName_full,"log",MessageBoxButtons.OK, MessageBoxIcon.Error);
 			   
 				if (!File.Exists( AsteriskPhoneAgentForm.logFileName))
 				{
 					// Create the file.
            		using (FileStream fs = File.Create( logFileName_full))
            		{
                		Byte[] info = new UTF8Encoding(true).GetBytes(" ");
                		// Add some information to the file.
                		fs.Write(info, 0, info.Length);
            		}
 				}
	            StringBuilder sb = new StringBuilder();

	            sb.Append(DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt")+": " +s);
	            sb.AppendLine();

	            using (StreamWriter outfile = new StreamWriter(logFileName_full, true))
	            {
            	    outfile.Write(sb.ToString());
            	}
        }
 		
		public fmPreference()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
		}
		
		private bool NEEDRELOAD = false;
		
		void ReadPreferences ()
		{
			//var Settings = ConfigurationManager.AppSettings;
			byte[] s_aditionalEntropy = Encoding.Unicode.GetBytes(Environment.MachineName);

			
			try {
					tbSerial.Text = Encoding.Unicode.GetString(
						ProtectedData.Unprotect(
							Convert.FromBase64String(ConfigurationManager.AppSettings["System"]), s_aditionalEntropy, DataProtectionScope.LocalMachine));
					label23.Text = "OK";
				} catch (Exception read)
				{
					label23.Text = "Error: "+read.Message;
				}				
			
			// Asterisk settings
			tbServerIP.Text = ConfigurationManager.AppSettings["ServerIP"];
			tbServerPort.Text = ConfigurationManager.AppSettings["ServerPort"];
			tbManagerLogin.Text = ConfigurationManager.AppSettings["ManagerLogin"];
			
			try {
				tbManagerPassword.Text = Encoding.Unicode.GetString(
						ProtectedData.Unprotect(
							Convert.FromBase64String(ConfigurationManager.AppSettings["ManagerPassword"]), s_aditionalEntropy, DataProtectionScope.LocalMachine));
				} catch (Exception err)
				{
					Log ("Error: Prefs: Manager password trouble."+err.Message);
				}
			
			tbPeerNumber.Text = ConfigurationManager.AppSettings["PeerNumber"];
			tbOriginateContext.Text = ConfigurationManager.AppSettings["OriginateContext"];
			tbOriginatePriority.Text = ConfigurationManager.AppSettings["OriginatePriority"];
			tbOriginateTimeout.Text = ConfigurationManager.AppSettings["OriginateTimeout"];
			tbExternalCallPrefix.Text = ConfigurationManager.AppSettings["ExternalCallPrefix"];
			
			// 	General settings
			Boolean parsedValue = false;
			Boolean.TryParse(ConfigurationManager.AppSettings["ShowImportant"], out parsedValue);
			cbShowImportant.Checked = parsedValue;

			parsedValue = false;
			Boolean.TryParse(ConfigurationManager.AppSettings["LoadonWindows"], out parsedValue);
			cbLoadonWindows.Checked = parsedValue;

			parsedValue = false;
			Boolean.TryParse(ConfigurationManager.AppSettings["LoadMinimized"], out parsedValue);
			cbLoadMinimized.Checked = parsedValue;
			
			parsedValue = false;
			Boolean.TryParse(ConfigurationManager.AppSettings["SystemNotification"], out parsedValue);
			cbSystemNotification.Checked = parsedValue;
			
			parsedValue = false;
			Boolean.TryParse(ConfigurationManager.AppSettings["Logging"], out parsedValue);
			cbLogging.Checked = parsedValue;
			
			// CallCenter settings
			parsedValue = false;
			Boolean.TryParse(ConfigurationManager.AppSettings["CallCenterEnable"], out parsedValue);
			cbCallCenterEnable.Checked = parsedValue;

			parsedValue = false;
			//disabled - open on income call
			Boolean.TryParse(ConfigurationManager.AppSettings["CCAutoOpenOnAnswer"], out parsedValue);
			cbCCAutoOpenOnAnswer.Checked = parsedValue;

			parsedValue = false;
			Boolean.TryParse(ConfigurationManager.AppSettings["CCAutoOpenUrl"], out parsedValue);
			cbCCAutoOpenUrl.Checked = parsedValue;
			
			tbCallCenterSite.Text = ConfigurationManager.AppSettings["CallCenterSite"];
			
			//MySQL
			
			tbDBName.Text =  ConfigurationManager.AppSettings["DBName"];
			tbDBIP.Text =  ConfigurationManager.AppSettings["DBIP"];
			tbDBUser.Text =  ConfigurationManager.AppSettings["DBUser"];
			tbDBPassword.Text =  ConfigurationManager.AppSettings["DBPassword"];
			tbDBstring.Text =  ConfigurationManager.AppSettings["DBString"];
			
			//.Text = ConfigurationManager.AppSettings[""];	
		}
	
		void SavePreferences ()
		{
			
			NEEDRELOAD = true;
			
			Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

			byte[] s_aditionalEntropy = Encoding.Unicode.GetBytes(Environment.MachineName);
			// Asterisk settings
			config.AppSettings.Settings["ServerIP"].Value = tbServerIP.Text;
			config.AppSettings.Settings["ServerPort"].Value = tbServerPort.Text;
			config.AppSettings.Settings["ManagerLogin"].Value = tbManagerLogin.Text;
			
			config.AppSettings.Settings["ManagerPassword"].Value = Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(tbManagerPassword.Text), s_aditionalEntropy, DataProtectionScope.LocalMachine));
			config.AppSettings.Settings["PeerNumber"].Value = tbPeerNumber.Text;
			config.AppSettings.Settings["OriginateContext"].Value = tbOriginateContext.Text;
			config.AppSettings.Settings["OriginatePriority"].Value = tbOriginatePriority.Text;
			config.AppSettings.Settings["OriginateTimeout"].Value = tbOriginateTimeout.Text;	
			config.AppSettings.Settings["ExternalCallPrefix"].Value = tbExternalCallPrefix.Text;	
			
			config.AppSettings.Settings["ShowImportant"].Value = Convert.ToString(cbShowImportant.Checked);
			config.AppSettings.Settings["LoadonWindows"].Value = Convert.ToString(cbLoadonWindows.Checked);
			config.AppSettings.Settings["LoadMinimized"].Value = Convert.ToString(cbLoadMinimized.Checked);
			config.AppSettings.Settings["SystemNotification"].Value = Convert.ToString(cbSystemNotification.Checked);
			config.AppSettings.Settings["Logging"].Value = Convert.ToString(cbLogging.Checked);
					                                                                                                                                                                                                    
			config.AppSettings.Settings["CallCenterEnable"].Value = Convert.ToString(cbCallCenterEnable.Checked);
			config.AppSettings.Settings["CCAutoOpenOnAnswer"].Value = Convert.ToString(cbCCAutoOpenOnAnswer.Checked);
			config.AppSettings.Settings["CCAutoOpenUrl"].Value = Convert.ToString(cbCCAutoOpenUrl.Checked);
			config.AppSettings.Settings["CallCenterSite"].Value = tbCallCenterSite.Text;	
			
			config.AppSettings.Settings["DBName"].Value = tbDBName.Text;
			config.AppSettings.Settings["DBIP"].Value = tbDBIP.Text;	
			config.AppSettings.Settings["DBUser"].Value = tbDBUser.Text;	
			config.AppSettings.Settings["DBPassword"].Value = tbDBPassword.Text;	
			config.AppSettings.Settings["DBstring"].Value = tbDBstring.Text;	
			//save to apply changes
			config.Save(ConfigurationSaveMode.Modified);
			ConfigurationManager.RefreshSection("appSettings");
			
			// Make autorun
			
			RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
            if (cbLoadonWindows.Checked)
            {
            	//MessageBox.Show("add");
                // Add the value in the registry so that the application runs at startup
                try
                {
              		rkApp.SetValue("AsteriskPhoneAgent", Application.ExecutablePath.ToString());
              		
                }
                catch (UnauthorizedAccessException ex)
			    {
      				MessageBox.Show(ex.Message);
         			return;
     			}
            }
            else
            {
            	//MessageBox.Show("del");
                // Remove the value from the registry so that the application doesn't start
                rkApp.DeleteValue("AsteriskPhoneAgent", false);
            }
			
		}
		void fmPreferenceLoad(object sender, EventArgs e)
		{
			ReadPreferences();
		}
		
		void ClosebuttonClick(object sender, EventArgs e)
		{
			if (NEEDRELOAD){
			AsteriskPhoneAgentForm asterfm;
			asterfm = this.Owner as AsteriskPhoneAgentForm;
			
			System.Diagnostics.Process.Start( Application.ExecutablePath); // to start new instance of application
			System.Diagnostics.Process.GetCurrentProcess().Kill();
			

			}
			this.Close();
		}
		
		void SaveButtonClick(object sender, EventArgs e)
		{
			SavePreferences();
			btSave.ForeColor = Color.Black;
						
		}
		void TbServerIPTextChanged(object sender, EventArgs e)
		{
	
		}
		void TbDBNameKeyUp(object sender, KeyEventArgs e)
		{
			tbDBstring.Text = 
				"Database="+tbDBName.Text+
				";Data Source="+tbDBIP.Text+
				";User Id="+tbDBUser.Text+
				";Password="+tbDBPassword.Text;
			btSave.ForeColor = Color.Red;
		}
		void TbServerIPKeyUp(object sender, KeyEventArgs e)
		{
			IPAddress address;
			if (IPAddress.TryParse((sender as TextBox).Text, out address)) {
       			//Valid IP, with address containing the IP
       			(sender as TextBox).ForeColor = Color.Black;
			} else {
       			//Invalid IP
       			(sender as TextBox).ForeColor = Color.Red;
			}
			
			btSave.ForeColor = Color.Red;
		}
		void TbDBIPKeyUp(object sender, KeyEventArgs e)
		{
			
			tbDBstring.Text = 
				"Database="+tbDBName.Text+
				";Data Source="+tbDBIP.Text+
				";User Id="+tbDBUser.Text+
				";Password="+tbDBPassword.Text;
							
			IPAddress address;
			if (IPAddress.TryParse((sender as TextBox).Text, out address)) {
       			//Valid IP, with address containing the IP
       			(sender as TextBox).ForeColor = Color.Black;
			} else {
       			//Invalid IP
       			(sender as TextBox).ForeColor = Color.Red;
			}	
			
			btSave.ForeColor = Color.Red;
		}
		void CbShowImportantClick(object sender, EventArgs e)
		{
			btSave.ForeColor = Color.Red;
		}
		void TbServerPortKeyPress(object sender, KeyPressEventArgs e)
		{
 			btSave.ForeColor = Color.Red;

		}
		
		void CbLoggingCheckedChanged(object sender, EventArgs e)
		{
			
		}
		
		public bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
		{
    		return true;
		}		
		
		// Check serial key
		void Button1Click(object sender, EventArgs e)
		{

            string responseFromServer = string.Empty;
			ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);

            try
            {
                WebRequest request = WebRequest.Create("https://asteriskphoneagent.com/activate/activate_en.php?passkey="+tbSerial.Text);
				if (request == null)
					return;
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd().TrimEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
                
                label23.Text = responseFromServer;
                
                if (responseFromServer == "Activated FREE license") {
                		NEEDRELOAD = true;
						Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
						byte[] s_aditionalEntropy = Encoding.Unicode.GetBytes(Environment.MachineName);
						config.AppSettings.Settings["System"].Value = Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(responseFromServer), s_aditionalEntropy, DataProtectionScope.LocalMachine));
						config.Save(ConfigurationSaveMode.Modified);
						MessageBox.Show("Activated FREE license","Info",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }
                if (responseFromServer == "Activated Standart license") {
                		NEEDRELOAD = true;
						Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
						byte[] s_aditionalEntropy = Encoding.Unicode.GetBytes(Environment.MachineName);
						config.AppSettings.Settings["System"].Value = Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(responseFromServer), s_aditionalEntropy, DataProtectionScope.LocalMachine));
						config.Save(ConfigurationSaveMode.Modified);
						MessageBox.Show("Activated Standart license","Info",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }

                if (responseFromServer == "Activated PRO license") {
                		NEEDRELOAD = true;
						Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
						byte[] s_aditionalEntropy = Encoding.Unicode.GetBytes(Environment.MachineName);
						config.AppSettings.Settings["System"].Value = Convert.ToBase64String(ProtectedData.Protect(Encoding.Unicode.GetBytes(responseFromServer), s_aditionalEntropy, DataProtectionScope.LocalMachine));
						config.Save(ConfigurationSaveMode.Modified);
						MessageBox.Show("Activated PRO license","Info",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
                }                
            }
            catch (Exception eresp)
            {
                label23.Text = "Error: "+eresp.Message;
                return;
            }		
		}
		
		void Label25Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(label25.Text);			
		}
		
		void Label25MouseHover(object sender, EventArgs e)
		{
			 label25.Font = new Font(label25.Font.Name, label25.Font.SizeInPoints, FontStyle.Underline);
		}
		
		void Label25MouseLeave(object sender, EventArgs e)
		{
			label25.Font = new Font(label25.Font.Name, label25.Font.SizeInPoints, FontStyle.Regular);
		}

        private void fmPreference_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (NEEDRELOAD)
            {
                AsteriskPhoneAgentForm asterfm;
                asterfm = this.Owner as AsteriskPhoneAgentForm;

                System.Diagnostics.Process.Start(Application.ExecutablePath); // to start new instance of application
                System.Diagnostics.Process.GetCurrentProcess().Kill();


            }
            this.Close();
        }
    }
}
