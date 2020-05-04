using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.ComponentModel;
using System.Text;
using System.Net;
using System.Configuration;
using System.Security.Cryptography;
using System.Management;
using System.Collections.Specialized;
using System.Globalization;
//using System.Windows.Forms.Keys;
using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Response;
using Asterisk.NET.Manager.Event;



namespace AsteriskPhoneAgent
{
	 		


    public partial class NewCallerQForm : Form
    {
        public NewCallerQForm()
        {
            InitializeComponent();
            toolTip1.SetToolTip(btGO, "Transfer call");
            toolTip1.SetToolTip(btTansfercall, "Transfer call");
			btTansfercall.Enabled = false;
			pnTransferCallForm.Width = 0;
			

        }

        public string CALLER_ID = string.Empty;
        public string CALLER_NAME = string.Empty;
        public string CALLER_FIO = string.Empty;
        public string CALLER_ORG = string.Empty;
        public string CALLER_DEP = string.Empty;
        public string CALLER_POS = string.Empty;
        public string CALLER_MAINPHONE = string.Empty;
        public string CALLER_CELLPHONE = string.Empty;
        public string CALLER_WORKPHONE = string.Empty;
        public string CALLER_EMAIL = string.Empty;
        public string CALLER_NOTE = string.Empty;
        public string CALLER_URL = string.Empty;
        public bool RINGENABLED = true;
        public string ORIGINATE_CONTEXT = string.Empty;
        public int ORIGINATE_PRIORITY = 1;
        public string ASTERISK_PEER_NUMBER = string.Empty;
        public int ORIGINATE_TIMEOUT = 3000;
                // Параметры подключения к менеджеру сервера Asterisk
        public string ASTERISK_HOST;
        public int ASTERISK_PORT;
        public string ASTERISK_LOGINNAME;
        public string ASTERISK_LOGINPWD;
        public string USER_ID = string.Empty; // передается при добавление нового контакта из формы запроса о добавлении при входящем звонке
        public string EXTPREFIX = string.Empty;
        public bool important = false;
         private ManagerConnection manager; 

        Timer tmr_call_time = null;
        DateTime BEGIN_CALL_TIME;

        NoteForm nf;

		//-------------------------------------------------------------------------------------------------------------

		private void AddCallerthread()
        {
            EditCallerForm ec;
            using (ec = new EditCallerForm())
            {
                ec.ACTION = 2; // добавить
                ec.CALLER_ID = CALLER_ID;
                Application.Run(ec);
            }
            ec.Dispose();
        }

		//-------------------------------------------------------------------------------------------------------------

		private void button2_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(AddCallerthread));
            t.Start();
        }

		//-------------------------------------------------------------------------------------------------------------

		private void NewCallerQForm_Load(object sender, EventArgs e)
        {
            // Размещаем форму в правом нижнем углу экрана
            this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
            this.Left = 0;//Screen.PrimaryScreen.WorkingArea.Width - this.Width;
			//pnTransferCallForm.Width = 0;
            if (!String.IsNullOrEmpty(CALLER_FIO))
            {
                CaptionPanel.BackColor = Color.Green;
                TITLElabel.BackColor = Color.Green;
                //this.BackColor = Color.FromArgb(255, 255, 185);
            }
            else
            {
                CaptionPanel.BackColor = SystemColors.HotTrack;
                TITLElabel.BackColor = SystemColors.HotTrack;
                //this.BackColor = Color.FromArgb(255, 225, 195);
            }

            if (important == true)
            {
                CaptionPanel.BackColor = Color.Red;
                TITLElabel.BackColor = Color.Red;
            }
            
            

            TITLElabel.Text = string.Format("Incoming {0} ({1})", CALLER_NAME, CALLER_ID);

            FIOlabel.Text = CALLER_FIO;
            ORGlabel.Text = CALLER_ORG;
            DEPlabel.Text = CALLER_DEP;
            POSlabel.Text = CALLER_POS;
            MAINPHONElabel.Text = CALLER_MAINPHONE;
            CELLPHONElabel.Text = CALLER_CELLPHONE;
            WORKPHONElabel.Text = CALLER_WORKPHONE;
            EMAILlabel.Text = CALLER_EMAIL;
            URL_label.Text = CALLER_URL;

            BEGIN_CALL_TIME = DateTime.Parse(DateTime.Now.ToLongTimeString());
            tmr_call_time = new System.Windows.Forms.Timer();
            tmr_call_time.Tick += new EventHandler(Tick_tmr_call_time);
            tmr_call_time.Interval = 1000;
            tmr_call_time.Start();

            if (!string.IsNullOrEmpty(CALLER_NOTE))
            {
                nf = new NoteForm();
                nf.Owner = this;
                nf.CALLER_NOTE = CALLER_NOTE;
                nf.Show(this);
            }
            
			manager = new ManagerConnection(ASTERISK_HOST, ASTERISK_PORT, ASTERISK_LOGINNAME, ASTERISK_LOGINPWD);
              
            try
            {
                manager.Login();
                Log ("History: Manager connection aviable. Peer '"+ASTERISK_PEER_NUMBER);
                //lbConnectionBroken.Visible = false;
                RINGENABLED = true;
            }
            catch (Exception err)
            {
                Log ("Error: History: Manager connection NOT aviable."+err.Message);
                RINGENABLED = false;
                //this.Close();
                return;
            }            
        }

        //-------------------------------------------------------------------------------------------------------------

        private void Tick_tmr_call_time(Object myObject, EventArgs myEventArgs)
        {
            DateTime TickTime = DateTime.Parse(DateTime.Now.ToLongTimeString());
            TimeSpan diff = TickTime - BEGIN_CALL_TIME;
            TimeLabel.Text = diff.ToString();
            TimeLabel.Refresh();
            
            //if call answered
            if (AsteriskPhoneAgentForm.INCOMING_CALL_ANSWER == true)
            {
                CaptionPanel.BackColor = Color.Blue;
                TITLElabel.BackColor = Color.Blue;
                AsteriskPhoneAgentForm.INCOMING_CALL_ANSWER = false;
                if (AsteriskPhoneAgentForm.CALLCENTER_OPENONANSWER)
                {
                	if (URL_label.Text.Contains("http")) {
                		System.Diagnostics.Process.Start(URL_label.Text);
                	}
                }
               
                if (RINGENABLED==true)
                {
                	//activate tranfer call button 
                	btTansfercall.Enabled = true;
                
                	//Enable keypress feature
                	this.KeyPreview = true;
                }
                
            }            
        }

 		//-------------------------------------------------------------------------------------------------------------

 		private void label17_MouseClick(object sender, MouseEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:" + EMAILlabel.Text);
        }

		//-------------------------------------------------------------------------------------------------------------

		private void NewCallerQForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (tmr_call_time != null)
            {
                tmr_call_time.Stop();
                tmr_call_time.Dispose();
            }

            if (nf != null)
            {	
  	            if ((manager != null) && (manager.IsConnected() == true))
	            {
                	manager.Logoff();
            	}
            	            
                nf.Close();
                nf.Dispose();
            }
        }
        
		//-------------------------------------------------------------------------------------------------------------

		void Label1Click(object sender, EventArgs e)
        {
        	
        }
        
		//-------------------------------------------------------------------------------------------------------------

		void URL_labelClick(object sender, EventArgs e)
        {
        	if (URL_label.Text.Contains("http")) {
        		System.Diagnostics.Process.Start(URL_label.Text);	
        	}
        	
        }
        
		//-------------------------------------------------------------------------------------------------------------
        
		void TransferCall(string DialedNumber)
		{
           	if (RINGENABLED != false)
               {
	
					// Now send Redirect action
					RedirectAction ra = new RedirectAction();
					ra.Channel = AsteriskPhoneAgentForm.CHANNEL_REMOTE;
					//ra.ExtraChannel = AsteriskPhoneAgentForm.;
					ra.Context = ORIGINATE_CONTEXT;
					ra.Exten = DialedNumber;
					ra.Priority = 1;
					try
					{
						ManagerResponse mr = manager.SendAction(ra, 10000);
						Log("Transfer Call"
							+ "\n\tResponse:" + mr.Response
							+ "\n\tMessage:" + mr.Message
							);
					}
					catch (Exception ex)
					{
						Log(ex.Message);
					}
                }			
		}
		
		//-------------------------------------------------------------------------------------------------------------

		void BtGOClick(object sender, EventArgs e)
        {
			if (AsteriskPhoneAgentForm.LicenseType>1) {
				TransferCall(tbDialedNumber.Text);
			}else{
				MessageBox.Show("Not aviable in FREE version");
			}
	
        	
        }
        
 		//-------------------------------------------------------------------------------------------------------------

 		void BtTansfercallClick(object sender, EventArgs e)
        {
			if (AsteriskPhoneAgentForm.LicenseType>1) {
	 			if (pnTransferCallForm.Width == 0)
	        	{
	        		pnTransferCallForm.Width = 200;
	        		tbDialedNumber.Focus();
	        		return;
	        	}
	        	if (pnTransferCallForm.Width == 200)
	        	{
	        		pnTransferCallForm.Width = 0;
	        		return;
	        	}
			}else{
				MessageBox.Show("Not aviable in FREE version");
			}

        }
 		
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

		//-------------------------------------------------------------------------------------------------------------

        void NewCallerQFormKeyUp(object sender, KeyEventArgs e)
        {
        	Log("Keypressed");
        	Keys key = e.KeyCode;
        	
		    if(((key >= Keys.NumPad0) && (key <= Keys.NumPad9))||
		    	((key >= Keys.D0) && (key <= Keys.D9)))
		    {
		    	 //disable keypress on form
		        this.KeyPreview = false;
	               
		        //open transfer form
    	    	if (pnTransferCallForm.Width == 0)
    	    	{
    	    		pnTransferCallForm.Width = 200;
    	    		tbDialedNumber.Focus();
    	    		string key_pressed = string.Empty;
    	    		switch (key)
    	    		{
    	    			case Keys.D0: key_pressed = "0"; break;
    	    			case Keys.NumPad0: key_pressed = "0";break;
    	    			case Keys.D1: key_pressed = "1"; break;
    	    			case Keys.NumPad1: key_pressed = "1";break;
    	    			case Keys.D2: key_pressed = "2"; break;
    	    			case Keys.NumPad2: key_pressed = "2";break;
    	    			case Keys.D3: key_pressed = "3"; break;
    	    			case Keys.NumPad3: key_pressed = "3";break;
    	    			case Keys.D4: key_pressed = "4"; break;
    	    			case Keys.NumPad4: key_pressed = "4";break;
    	    			case Keys.D5: key_pressed = "5"; break;
    	    			case Keys.NumPad5: key_pressed = "5";break;
    	    			case Keys.D6: key_pressed = "6"; break;
    	    			case Keys.NumPad6: key_pressed = "6";break;
    	    			case Keys.D7: key_pressed = "7"; break;
    	    			case Keys.NumPad7: key_pressed = "7";break;
    	    			case Keys.D8: key_pressed = "8"; break;
    	    			case Keys.NumPad8: key_pressed = "8";break;
    	    			case Keys.D9: key_pressed = "9"; break;
    	    			case Keys.NumPad9: key_pressed = "9";break;
    	    			default: key_pressed = "";break;
    	    		}
    	    		tbDialedNumber.Text = key_pressed;
    	    		return;
    	    	}
    	    	
		    }

        }
        
 		//-------------------------------------------------------------------------------------------------------------

 		void NewCallerQFormKeyPress(object sender, KeyPressEventArgs e)
        {

        }
        
		//-------------------------------------------------------------------------------------------------------------

		void TbDialedNumberKeyPress(object sender, KeyPressEventArgs e)
        {
        	
        }
        
		//-------------------------------------------------------------------------------------------------------------

		void TbDialedNumberKeyUp(object sender, KeyEventArgs e)
        {
        	if (e.KeyCode == Keys.Return)
        	{
        		TransferCall(tbDialedNumber.Text);
        	}
        }
    }
}
