using System;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Configuration;
using System.Security.Cryptography;
using System.Management;
using System.Collections.Specialized;
using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Response;
using Asterisk.NET.Manager.Event;

using MySql.Data.MySqlClient;

//using ini;

namespace AsteriskPhoneAgent
{
    public partial class AsteriskPhoneAgentForm : Form
    {
        public AsteriskPhoneAgentForm()
        {
            InitializeComponent();
        }

        #region Global Variables
        public static string VERSION = "2.1.14";

        // После закрытия формы добавления или удаления контакта мы узнаем что была нажата кнопка сохранить
        public static bool ADD_OR_EDIT_RESULT;

        // Строка подключения к базе
        public static string CONNECTION_STRING;
        
        // Информация об абоненте
        private static string CALLER_FIO;
        private static string CALLER_ORG;
        private static string CALLER_DEP;
        private static string CALLER_POS;
        private static string CALLER_MAINPHONE;
        private static string CALLER_CELLPHONE;
        private static string CALLER_WORKPHONE;
        private static string CALLER_EMAIL;
        private static string CALLER_NOTE;
        private static string CALLER_NAME;
        public static string CHANNEL_MY;
        public static string CHANNEL_REMOTE;
        
        
        // Дата и время внесения изменения в БД для синхронизации локального контакт-листа
        // Инициализируется в функции LoadContacts()
        private static DateTime CALLER_CHANGE;
        
        // Параметры подключения к менеджеру сервера Asterisk
        private static string ASTERISK_HOST;
        private static int ASTERISK_PORT;
        private static string ASTERISK_LOGINNAME;
        private static string ASTERISK_LOGINPWD;
        
        // public для обращения из формы EditCaller (если там выбран чекбокс "личный контакт" то запись в БД помечается полем ASTERISK_PEER_NUMBER
        // и загружается только для этого человека
        public static string ASTERISK_PEER_NUMBER;
        public static string Activation;
        
		// License 0 - no lic, 1 - Free , 2 - standart , 3 - PRO
        public static int LicenseType = 0;
        
        // Параметры необходимые для оригинации вызова
        private static string ORIGINATE_CONTEXT;
        private static int ORIGINATE_PRIORITY;
        private static int ORIGINATE_TIMEOUT;
        private static string EXTERNALCALLPREFIX = string.Empty;
        private static string CONTEXT_DIAL_NUMBER = string.Empty;

        private static bool PHONE_STATUS_TOOLTIP = false;
        private static bool INCOMING_CALL = false;
        public static bool INCOMING_CALL_ANSWER = false;
        private static bool INCOMING_CALL_TOOLTIP = false;
        private static bool	LOAD_MINIMIZED = false;
        
        private static bool CALLCENTERENABLE = false;
        public static bool CALLCENTER_OPENONANSWER = false;
        
        public static bool CALLCENTER_AUTOOPENURL = false;
        
        private static string CALLCENTER_SITE = string.Empty;
      		                
        // Загружать или нет в список контактов только важные
        private static bool IMPORTANT_CALLERS;
        
        // Logging or not
        private static bool LOGGING;
        
        // Show system error notifications
        private static bool ShowSystemNotify;
        
        //If true then close on close, not minimize
        public static bool NOW_CLOSE = false;

        // Переменные инициализируются при обнаружении входящего вызова
        private static string CURRENT_CHANNEL = string.Empty;
        private static string CALLER_ID = string.Empty;
        private static string URL_TEXT = string.Empty;

        public static string logFileName = "AsteriskPhoneAgent.log";

        // Таймер для проверки входящего вызова
        Timer tmr_monitor_incoming_call = null;

        // Таймер для проверки изменения на сервере списка контактов и статуса телефона абонента
        Timer tmr_callerschange = null;
        
        public static bool NEED_READ_CONFIG = false;
        
        private ManagerConnection manager;
        private ResponseHandler pingHandler;

        NewCallerQForm nc;
        #endregion

        #region Tray and Resize
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool SetForegroundWindow(IntPtr hWnd);

        //-------------------------------------------------------------------------------------------------------------

        private void Tray_MouseClick(object sender, MouseEventArgs e)
        {
        	if (e.Button == MouseButtons.Left) {

    	        if (this.WindowState == FormWindowState.Minimized)
    	        {
    	            this.Visible = true;
    	            this.ShowInTaskbar = true;
    	            this.WindowState = FormWindowState.Normal;
    	        }
    	        // Если окно уже развернуто из трея, но !возможно! скрыто под другими окнами показываем его поверх всех окон
    	        else if (this.WindowState == FormWindowState.Normal)
    	        {
	                SetForegroundWindow(this.Handle);
            	}

            	SearchTextBox.Focus();
            	this.Activate();
        	}
        	
	       	if (e.Button == MouseButtons.Right) {
        		contextMenuTray.Show(Cursor.Position);
        	}

        }

        //-------------------------------------------------------------------------------------------------------------

        bool CheckActivation()
        {
            if (Activation == "Empty")
            {
                DialogResult result = MessageBox.Show("Activation", "Please activate before using. Aviable free activation", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                if (result == DialogResult.Cancel)
                {
                    Tray.Dispose();
                    Environment.Exit(0);
                }
                if (result == DialogResult.OK)
                {
                    fmPreference fm = new fmPreference();
                    fm.Owner = this;
                    fm.ShowDialog();
                    fm.Dispose();
                }
                return false;
            }
            else
            {
                return true;
            }

        }

        //-------------------------------------------------------------------------------------------------------------

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate();

            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                this.Visible = false;
            }
        }
        #endregion

        //-------------------------------------------------------------------------------------------------------------

        void CheckUpdate()
        {
            // версия сервера разбитая на 3 части
            int ver1 = -1;
            int ver2 = -1;
            int ver3 = -1;

            // локальная версия разбитая на 3 части
            int l_ver1 = -1;
            int l_ver2 = -1;
            int l_ver3 = -1;

            string responseFromServer = string.Empty;

            try
            {
                WebRequest request = WebRequest.Create("http://xtelekom.ru/astcrm/update_ru.php");
                request.Credentials = CredentialCache.DefaultCredentials;
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                Stream dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                responseFromServer = reader.ReadToEnd().TrimEnd();

                reader.Close();
                dataStream.Close();
                response.Close();
            }
            catch (Exception eresp)
            {
                Log(string.Format("Error updating: {0}", eresp.Message));
                return;
            }

            string[] server_version = responseFromServer.Split(';')[0].Split('.');
            ver1 = Int32.Parse(server_version[0]);
            ver2 = Int32.Parse(server_version[1]);
            ver3 = Int32.Parse(server_version[2]);

            string[] local_version = VERSION.Split('.');
            l_ver1 = Int32.Parse(local_version[0]);
            l_ver2 = Int32.Parse(local_version[1]);
            l_ver3 = Int32.Parse(local_version[2]);


            string updateURL = responseFromServer.Split(';')[1];

            if ( 
                (ver1 > l_ver1) || 
                                (ver2 > l_ver2) || 
                                                ( (ver1 == l_ver1) && (ver2 == l_ver2) && (ver3 > l_ver3) )
                )
            {
                if (MessageBox.Show("Update aviable.\nBegin updating?", "Info", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    System.Diagnostics.Process.Start(updateURL);
                }
               
            }
        }

        //-------------------------------------------------------------------------------------------------------------

        bool ReadParameters()
        {
           // CheckUpdate();

            try
            {
                // Вносим элемент "беспорядка" для кодирования пароля и строки подключения в ProtectedData.Protect и ProtectedData.Unprotect
                byte[] s_aditionalEntropy = Encoding.Unicode.GetBytes(Environment.MachineName);
			
                //var Settings = ConfigurationManager.AppSettings;

				ASTERISK_HOST = ConfigurationManager.AppSettings["ServerIP"];
				ASTERISK_PORT = Int32.Parse(ConfigurationManager.AppSettings["ServerPort"]);
				ASTERISK_LOGINNAME = ConfigurationManager.AppSettings["ManagerLogin"];
				try {
					ASTERISK_LOGINPWD = Encoding.Unicode.GetString(
						ProtectedData.Unprotect(
							Convert.FromBase64String(ConfigurationManager.AppSettings["ManagerPassword"]), s_aditionalEntropy, DataProtectionScope.LocalMachine));
				} catch (Exception read)
				{
					Log("Error read config ASTERISK_LOGINPWD :"+read.Message);
					return false;
				}
				
				ASTERISK_PEER_NUMBER = ConfigurationManager.AppSettings["PeerNumber"];
				ORIGINATE_CONTEXT = ConfigurationManager.AppSettings["OriginateContext"];
				ORIGINATE_PRIORITY = Int32.Parse(ConfigurationManager.AppSettings["OriginatePriority"]);
				ORIGINATE_TIMEOUT = Int32.Parse(ConfigurationManager.AppSettings["OriginateTimeout"])*1000;
				EXTERNALCALLPREFIX = ConfigurationManager.AppSettings["ExternalCallPrefix"];
				
				IMPORTANT_CALLERS = Boolean.Parse(ConfigurationManager.AppSettings["ShowImportant"]);
				LOAD_MINIMIZED = Boolean.Parse(ConfigurationManager.AppSettings["LoadMinimized"]);
				ShowSystemNotify = Boolean.Parse(ConfigurationManager.AppSettings["SystemNotification"]);
				LOGGING = Boolean.Parse(ConfigurationManager.AppSettings["Logging"]);
				
				CONNECTION_STRING = ConfigurationManager.AppSettings["DBString"];
				
				CALLCENTERENABLE = Boolean.Parse(ConfigurationManager.AppSettings["CallCenterEnable"]);
				CALLCENTER_SITE = ConfigurationManager.AppSettings["CallCenterSite"];
				CALLCENTER_AUTOOPENURL = Boolean.Parse(ConfigurationManager.AppSettings["CCAutoOpenUrl"]);
				CALLCENTER_OPENONANSWER = Boolean.Parse(ConfigurationManager.AppSettings["CCAutoOpenOnAnswer"]);
				
				if (ConfigurationManager.AppSettings["System"] == string.Empty) 
				{
					Activation = "Empty";
                    CheckActivation();

                } else {
			
					try {
						Activation = Encoding.Unicode.GetString(
							ProtectedData.Unprotect(
								Convert.FromBase64String(ConfigurationManager.AppSettings["System"]), s_aditionalEntropy, DataProtectionScope.LocalMachine));
						if (Activation == "Activated FREE license"){
							LicenseType = 1;
							CALLCENTERENABLE = false;
						}
						if (Activation == "Activated Standart license"){
							LicenseType = 2;
							CALLCENTERENABLE = false;
						}
						if (Activation == "Activated PRO license"){
							LicenseType = 3;
						}
					} catch (Exception read)
					{
						Log("Error read activation parameter :"+read.Message);
    					MessageBox.Show("Activation", "Please activate before using. Aviable free activation", MessageBoxButtons.OK, MessageBoxIcon.Error);
				     	fmPreference fm = new fmPreference();
        	    	    fm.Owner = this;
        	    	    fm.ShowDialog();
        	    	    fm.Dispose();
						return false;
					}
				}
				

				
                return true;
            }
            catch (Exception eread)
            {
                MessageBox.Show(eread.Message, "Error read config", MessageBoxButtons.OK, MessageBoxIcon.Error);
	
                return false;
                
            }
        }
	
        //-------------------------------------------------------------------------------------------------------------

        private void LoadContacts()
        {
            if (!CheckActivation()) return;


            ContactsTreeView.Nodes.Clear();

            string CommandText = "SELECT * FROM callers WHERE deleted=0 AND personal='ALL' OR personal='" + ASTERISK_PEER_NUMBER + "' ";
            if (IMPORTANT_CALLERS) CommandText += " AND important=1 ";
            CommandText += " ORDER BY important DESC, personal DESC, fio;";

            MySqlConnection myConnection = new MySqlConnection(CONNECTION_STRING);
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);

            ContactsTreeView.BeginUpdate();

            try
            {
                myConnection.Open();

                MySqlDataReader MyDataReader;
                MyDataReader = myCommand.ExecuteReader();

                if (MyDataReader.HasRows)
                {
                    while (MyDataReader.Read())
                    {
                        TreeNode node0 = ContactsTreeView.Nodes.Add(MyDataReader["fio"].ToString().Trim());
                        node0.Tag = MyDataReader["callerid"].ToString().Trim();
                        node0.ContextMenuStrip = contextMenuStrip1;
                        node0.ImageIndex = 0;
                        node0.SelectedImageIndex = 0;

                        if (MyDataReader["important"].ToString() == "1")
                        {
                            node0.ImageIndex = 4;
                            node0.SelectedImageIndex = 4;
                        }

                        if (MyDataReader["personal"].ToString() != "ALL")
                        {
                            node0.ImageIndex = 5;
                            node0.SelectedImageIndex = 5;
                        }

                        TreeNode node1 = node0.Nodes.Add(MyDataReader["mainphone"].ToString().Trim());
                        node1.ImageIndex = 1;
                        node1.SelectedImageIndex = 1;
                        
                        if (!String.IsNullOrEmpty(MyDataReader["cellphone"].ToString().Trim()))
                        {
                            TreeNode node2 = node0.Nodes.Add(MyDataReader["cellphone"].ToString().Trim());
                            node2.ImageIndex = 2;
                            node2.SelectedImageIndex = 2;
                        }

                        if (!String.IsNullOrEmpty(MyDataReader["workphone"].ToString().Trim()))
                        {
                            TreeNode node3 = node0.Nodes.Add(MyDataReader["workphone"].ToString().Trim());
                            node3.ImageIndex = 3;
                            node3.SelectedImageIndex = 3;
                        }
                    }
                }
                MyDataReader.Close();

                // Инициализируем переменную CALLER_CHANGE по которой впоследствии будем отслеживать изменения вносимые в БД пользователями
                CommandText = "SELECT * FROM callerschange;";
                MySqlCommand myCommand1 = new MySqlCommand(CommandText, myConnection);

                MyDataReader = myCommand1.ExecuteReader();

                if (MyDataReader.HasRows)
                {
                    MyDataReader.Read();
                    CALLER_CHANGE = DateTime.Parse(MyDataReader["chdatetime"].ToString().Trim());
                }
                else
                {
                    CALLER_CHANGE = DateTime.Now;
                    Log("Error: Can`t find table 'callerschange'. No sync contacts!");
                }
            }
            catch (Exception exConnecting)
            {
                Log ("Error: Mainform: Manager connection NOT aviable."+exConnecting.Message);
                this.Close();
                return;
            }
            finally
            {
                myConnection.Close();
            }

            ContactsTreeView.EndUpdate();
            ContactsTreeView.Focus();
        }
       
 		//-------------------------------------------------------------------------------------------------------------
 
 		static void Log(String s)
        {
        	 if (LOGGING) {
				
 				string logFileName_full = Application.StartupPath + "\\"+ logFileName;  
 				//MessageBox.Show(logFileName_full,"log",MessageBoxButtons.OK, MessageBoxIcon.Error);
 			   
 				if (!File.Exists( logFileName))
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
        }
        
 		//-------------------------------------------------------------------------------------------------------------
  
        #region Asterisk
        static void dam_Dial(object sender, DialEvent e)
        {
        	Log("Call: Callerid " + e.CallerId + " CallerIdName " + e.CallerIdName);
        	Log("Call:  Channel " + e.Channel + " Destination " + e.Destination);
        	Log("Call: " + e.UniqueId + " " + e.DateReceived + " " + e.DialStatus + " "  + e.DialString);
        	CHANNEL_MY = e.Destination;
        	CHANNEL_REMOTE = e.Channel;
        	if (INCOMING_CALL_TOOLTIP == false)
            {
                if ((e != null) && (e.Destination != null) && (e.Destination.StartsWith(ASTERISK_PEER_NUMBER)))
                {
                    INCOMING_CALL = true;
                    CALLER_ID = e.CallerIdNum;
                    CALLER_NAME = e.CallerIdName;
                    //URL_TEXT = e.Channel;
                    CURRENT_CHANNEL = e.Channel;
                }
            }
        }

		//-------------------------------------------------------------------------------------------------------------

        static void dam_Exten(object sender, ExtensionStatusEvent e)
        {
            Log("state: " + e.Status + ":" + e.Exten);
        	
        	if (INCOMING_CALL_TOOLTIP == true)
            {
        		if ((e != null) && ((e.Status==2)||(e.Status==1)))
                {
                    INCOMING_CALL_ANSWER = true;
                }
            }                     	
        }

        //-------------------------------------------------------------------------------------------------------------

		static void dam_Hangup(object sender, HangupEvent e)
        {
            if ((e.Channel == CURRENT_CHANNEL) && (e.CallerIdNum == CALLER_ID))
            {
                INCOMING_CALL = false;
            }
        }

		//-------------------------------------------------------------------------------------------------------------

        bool CallerPhoneWork()
        {
            try
            {
                pingHandler = new ResponseHandler(new PingAction(), null);
                ManagerResponse mr = manager.SendAction(pingHandler.Action, 0);
                string responsePong = mr.ToString();
                if (!responsePong.Contains("Pong"))
                {
                    manager.Logoff();
                    Manager_Login();
                }
            }
            catch (Exception err)
            {
                Log ("Error: CallerPhoneWork:  " + err.Message);
                return false;
            }

            CommandAction command = new CommandAction();
            CommandResponse response = new CommandResponse();

            command.Command = string.Format("sip show peer {0}", ASTERISK_PEER_NUMBER.Split('/')[1]);

            try
            {
                response = (CommandResponse)manager.SendAction(command);
                
                foreach (string str in response.Result)
                {
                    if (str.Contains("Status") && str.Contains("OK")) return true;
                }
                
                return false;
            }
            catch (Exception err)
            {
                Log ("Error:  sipshowpeer: " + err.Message);
                return false;
            }
        }

		//-------------------------------------------------------------------------------------------------------------

        void CheckPhoneStatus()
        {
            if (!CheckActivation()) return;

            if (CallerPhoneWork() == false)
            {
                if (PHONE_STATUS_TOOLTIP == false)
                {
                    Log ("Error: Peer '"+ASTERISK_PEER_NUMBER+"' not registered. Originate calls not aviable!");
                    //RingButton.ImageIndex = 5;
                    RingButton.Enabled = false;
                    Tray.ShowBalloonTip(500,
                                        "Error",
                                        string.Format("{0}\r\nPeer {1} not registered. Originate calls not aviable!", DateTime.Now.ToLongTimeString(), ASTERISK_PEER_NUMBER),
                                        ToolTipIcon.Error);
                    
                    PHONE_STATUS_TOOLTIP = true;
                }
            }
            else
            {
                if (PHONE_STATUS_TOOLTIP == false)
                {
                    return;
                }

                Tray.ShowBalloonTip(500,
                                    "Информация",
                                    string.Format("{0}\r\nPeer {1} not registered. Originate calls aviable!", DateTime.Now.ToLongTimeString(), ASTERISK_PEER_NUMBER),
                                    ToolTipIcon.Info);

                Log ("Peer '"+ASTERISK_PEER_NUMBER+"' registered. Originate calls aviable!");
                //RingButton.ImageIndex = 0;
                RingButton.Enabled = true;
                
                PHONE_STATUS_TOOLTIP = false;
            }
        }

		//-------------------------------------------------------------------------------------------------------------

        private void Manager_Login()
        {
            if (Activation != "Empty")
            {
                try
                {
                    if (manager.Password != string.Empty)
                    {
                        manager.Login();
                    }
                    Log("Manager connection aviable. Peer '" + ASTERISK_PEER_NUMBER);
                    //lbConnectionBroken.Visible = false;
                }
                catch (Exception err)
                {
                    Log("Error: Manager connection NOT aviable." + err.Message);
                    //lbConnectionBroken.Visible = true;
                    this.Close();
                    return;
                }
            }
        }
        #endregion

        //-------------------------------------------------------------------------------------------------------------

        #region ticks-timer

        private void Tick_tmr_monitor_incoming_call(Object myObject, EventArgs myEventArgs)
        {
            // Если поступил входящий звонок на наш номер =========================
            if (INCOMING_CALL == true)
            {
                // и если мы еще не показывали форму с информацией о звонке
                if (INCOMING_CALL_TOOLTIP == false)
                {
                    // говорим что показывали и собственно показываем :)
                    INCOMING_CALL_TOOLTIP = true;

                    CALLER_FIO = string.Empty;
                    CALLER_ORG = string.Empty;
                    CALLER_DEP = string.Empty;
                    CALLER_POS = string.Empty;
                    CALLER_MAINPHONE = string.Empty;
                    CALLER_CELLPHONE = string.Empty;
                    CALLER_WORKPHONE = string.Empty;
                    CALLER_EMAIL = string.Empty;
                    CALLER_NOTE = string.Empty;
                    URL_TEXT = string.Empty;

                    // призгак важного контакта, чтобы показать красный заголовок формы звонка
                    bool important_contact = false;

                    string Connect = CONNECTION_STRING;
                    string CommandText = string.Format("SELECT * FROM callers WHERE deleted=0 AND (personal='ALL' OR personal='{0}') AND (mainphone='{1}' OR cellphone='{1}' OR workphone='{1}');", ASTERISK_PEER_NUMBER, CALLER_ID);

                    MySqlConnection myConnection = new MySqlConnection(Connect);
                    MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);
                    try
                    {
                        myConnection.Open();

                        MySqlDataReader MyDataReader;
                        MyDataReader = myCommand.ExecuteReader();

                        if (MyDataReader.HasRows)
                        {
                            MyDataReader.Read();
                            CALLER_FIO = MyDataReader["fio"].ToString().Trim();
                            CALLER_ORG = MyDataReader["organization"].ToString().Trim();
                            CALLER_DEP = MyDataReader["department"].ToString().Trim();
                            CALLER_POS = MyDataReader["position"].ToString().Trim();
                            CALLER_MAINPHONE = MyDataReader["mainphone"].ToString().Trim();
                            CALLER_CELLPHONE = MyDataReader["cellphone"].ToString().Trim();
                            CALLER_WORKPHONE = MyDataReader["workphone"].ToString().Trim();
                            CALLER_EMAIL = MyDataReader["email"].ToString().Trim();
                            CALLER_NOTE = MyDataReader["note"].ToString().Trim();

                            if (MyDataReader["important"].ToString() == "1")
                            {
                                important_contact = true;
                            }
                        }
                        
                        MyDataReader.Close();
                    }
                    catch (Exception exConnecting)
                    {
                        Log ("Error:  " + exConnecting.Message);
                        this.Close();
                        return;
                    }
                    finally
                    {
                        myConnection.Close();
                        myConnection.Dispose();
                    }
                    
					// Запросим URL для страницы

    		        string responseFromServer = string.Empty;


						            
		            
		            // If need url - get it from server
		            if (CALLCENTERENABLE == true) {
    			        try
    			        {
    			            WebRequest request = WebRequest.Create(CALLCENTER_SITE + "geturl.php?name="+CALLER_NAME+"&src="+CALLER_ID+"&ext="+ASTERISK_PEER_NUMBER.Split('/')[1]);
    			            request.Credentials = CredentialCache.DefaultCredentials;
    			            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
    			            Stream dataStream = response.GetResponseStream();
    			            StreamReader reader = new StreamReader(dataStream);
    			            responseFromServer = reader.ReadToEnd().TrimEnd();
							URL_TEXT = responseFromServer;	
    			            reader.Close();
	  		                dataStream.Close();
  		                	response.Close();
                			//MessageBox.Show(responseFromServer,"asdasd",MessageBoxButtons.OK,MessageBoxIcon.Asterisk);
 		           		}
		            	catch (Exception eresp)
 		           		{
		            		Log ("Error:  " + eresp.Message);
		            	
 		              	// return;
 		           		}		            	
		            	URL_TEXT = responseFromServer;	
		            	
		            }
		            else
		            {
		            	URL_TEXT = "";
		            }
					
		            //Open call center site page if need
                	if (!CALLCENTER_OPENONANSWER)
                	{
                		if (URL_TEXT.Contains("http")) {
                			System.Diagnostics.Process.Start(URL_TEXT);
                		}
                	}		            
                    
                	//Show notification card
                    	nc = new NewCallerQForm();
                    	nc.Owner = this;
	                nc.CALLER_ID = CALLER_ID;
        	        nc.CALLER_NAME = CALLER_NAME;
                	nc.CALLER_FIO = CALLER_FIO;
	                if (!string.IsNullOrEmpty(CALLER_FIO)) nc.AddCallerButton.Visible = false;
        	        nc.CALLER_ORG = CALLER_ORG;
                	nc.CALLER_DEP = CALLER_DEP;
	                nc.CALLER_POS = CALLER_POS;
        	        nc.CALLER_MAINPHONE = CALLER_MAINPHONE;
                	nc.CALLER_CELLPHONE = CALLER_CELLPHONE;
	                nc.CALLER_WORKPHONE = CALLER_WORKPHONE;
        	        nc.CALLER_EMAIL = CALLER_EMAIL;
                	nc.CALLER_NOTE = CALLER_NOTE;
	                nc.CALLER_URL = URL_TEXT;
          			nc.USER_ID = ASTERISK_PEER_NUMBER.Split('/')[1];
            		nc.ASTERISK_PEER_NUMBER = ASTERISK_PEER_NUMBER;
		        	nc.ORIGINATE_CONTEXT = ORIGINATE_CONTEXT;
        			nc.ORIGINATE_PRIORITY = ORIGINATE_PRIORITY;
		        	nc.ORIGINATE_TIMEOUT = ORIGINATE_TIMEOUT;
	        		nc.RINGENABLED = RingButton.Enabled;
	        		nc.EXTPREFIX = EXTERNALCALLPREFIX;
		        	nc.ASTERISK_HOST = ASTERISK_HOST;
	        		nc.ASTERISK_PORT = ASTERISK_PORT;
	        		nc.ASTERISK_LOGINNAME = ASTERISK_LOGINNAME;
	            	nc.ASTERISK_LOGINPWD = ASTERISK_LOGINPWD;                    
                   	nc.important = important_contact;
                   	nc.Show(this);
                }
                
                if (INCOMING_CALL_ANSWER == true)
                {
                	nc.CALLER_MAINPHONE = "...";
                }                
                
            }
            // Если повесили трубку или разговор закончен ========================
            else
            {
                if (INCOMING_CALL_TOOLTIP == false) return;

                INCOMING_CALL_TOOLTIP = false;

                if (nc != null)
                {
                    nc.Close();
                    nc.Dispose();
                }
            }
        }

        //-------------------------------------------------------------------------------------------------------------

        private void Tick_tmr_callerschange(Object myObject, EventArgs myEventArgs)
        {
            if (!CheckActivation()) return;

            string Connect = CONNECTION_STRING;
            string CommandText = "SELECT * FROM callerschange;";

            CheckPhoneStatus();
            
            MySqlConnection myConnection = new MySqlConnection(Connect);
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);

            try
            {
                myConnection.Open();

                MySqlDataReader MyDataReader;
                MyDataReader = myCommand.ExecuteReader();

                if (MyDataReader.HasRows)
                {
                    MyDataReader.Read();
                    if (CALLER_CHANGE < DateTime.Parse(MyDataReader["chdatetime"].ToString().Trim()))
                    {
                        LoadContacts();
                    }
                }
            }
            catch (Exception exConnecting)
            {
                Log ("Error:  " + exConnecting.Message);
                return;
            }
            finally
            {
                myConnection.Close();
                myConnection.Dispose();
            }

            
        }

        #endregion

        // -------------------------------------------------------------------

        public void ReloadSettings()
        {
        	if (ReadParameters())
            {

                if (!CheckActivation()) return;


                byte[] s_aditionalEntropy = Encoding.Unicode.GetBytes(Environment.MachineName);

                // Устанавливаем высоту формы по высоте экрана
                this.Height = Screen.PrimaryScreen.WorkingArea.Height;
                // Размещаем форму в правом нижнем углу экрана
                this.Top = Screen.PrimaryScreen.WorkingArea.Height - this.Height;
                this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;

                this.MaximumSize = new System.Drawing.Size(455, Screen.PrimaryScreen.WorkingArea.Height);
                this.MinimumSize = new System.Drawing.Size(255, Screen.PrimaryScreen.WorkingArea.Height/2);

                string act = "Free";
                if (LicenseType==2) {act="Standart";}
                if (LicenseType==3) {act="PRO";}
                this.Text = string.Format("{2} {0} - {1}", this.Text, VERSION, act);

                ClearFindButton.Visible = false;
                FindTreeView.Visible = false;

                manager = new ManagerConnection(ASTERISK_HOST, ASTERISK_PORT, ASTERISK_LOGINNAME, ASTERISK_LOGINPWD);
                manager.DefaultResponseTimeout = 5;
                manager.Dial += new DialEventHandler(dam_Dial);
                manager.ExtensionStatus += new ExtensionStatusEventHandler(dam_Exten);
                //manager.LogChannel += new LogChannelEventHandler( dam_Log);
                manager.Hangup += new HangupEventHandler(dam_Hangup);
                manager.DefaultResponseTimeout=3000;
                manager.DefaultEventTimeout=2000;
                
                Manager_Login();

                toolTip1.SetToolTip(RingButton, "Make call");
                toolTip1.SetToolTip(AddButton, "Add contact");
                toolTip1.SetToolTip(btHistory, "Call history");
                //toolTip1.SetToolTip(EditButton, "Редактировать абонента");
                toolTip1.SetToolTip(btSetup, "Setup");
                toolTip1.SetToolTip(ExitButton, "Exit");

                LoadContacts();

                tmr_monitor_incoming_call = new System.Windows.Forms.Timer();
                tmr_monitor_incoming_call.Tick += new EventHandler(Tick_tmr_monitor_incoming_call);
                tmr_monitor_incoming_call.Interval = 500;
                tmr_monitor_incoming_call.Start();

                tmr_callerschange = new System.Windows.Forms.Timer();
                tmr_callerschange.Tick += new EventHandler(Tick_tmr_callerschange);
                tmr_callerschange.Interval = 30000;
                tmr_callerschange.Start();

                CheckPhoneStatus();
                
                //panel2.Visible = false;
                //lbConnectionBroken.Visible = false;
                
                // Set form state minimized if need
                if (LOAD_MINIMIZED) {
                	this.WindowState = FormWindowState.Minimized;
                } else
                {
                	this.WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                MessageBox.Show("Error reading config!\nCheck file "+ logFileName, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            	fmPreference fm = new fmPreference();
            	fm.Owner = this;
            	fm.ShowDialog();
            	fm.Dispose();
                Log("Error reading config!\nCheck file "+ logFileName);
                this.Close();
                return;
            }
        }
        
		//-------------------------------------------------------------------------------------------------------------

		private void FormAsterNotify_Load(object sender, EventArgs e)
        {
			ReloadSettings();
        }

		//-------------------------------------------------------------------------------------------------------------

		private void FormAsterNotify_FormClosing(object sender, FormClosingEventArgs e)
        {
			
			if (!NOW_CLOSE) {
				e.Cancel = true;
	    		this.WindowState = FormWindowState.Minimized;
			} else
			{
				Tray.Dispose();
				Environment.Exit(0);
			}
			
        }

		//-------------------------------------------------------------------------------------------------------------

		private void ExitForm ()
		{
			if (tmr_monitor_incoming_call != null)
            {
                tmr_monitor_incoming_call.Stop();
                tmr_monitor_incoming_call.Dispose();
            }
            if (tmr_callerschange != null)
            {
                tmr_callerschange.Stop();
                tmr_callerschange.Dispose();
            }
            if ((manager != null) && (manager.IsConnected() == true))
            {
                manager.Logoff();
            }
            
			
			NOW_CLOSE = true;
			//
			//System.Diagnostics.Process.GetCurrentProcess().Kill();	
            this.Close();
		}
		
		//-------------------------------------------------------------------------------------------------------------

		private void ExitButton_Click(object sender, EventArgs e)
        {
			ExitForm();
        }

		//-------------------------------------------------------------------------------------------------------------

		 
		private void RingButton_Click(object sender, EventArgs e)
        {
            if (!CheckActivation()) return;

            try
            {
                string exten_number = string.Empty;

                TreeView tv;
                if (FindTreeView.Visible)
                {
                    tv = (TreeView)FindTreeView;
                }
                else
                {
                    tv = (TreeView)ContactsTreeView;
                }

                tv.Focus();
                if (tv.SelectedNode.Level == 0)
                {
                    // Если в дереве выбран верхний уровень, т.е. ФИО то звоним на основной номер, который записывается в свойство Tag при LoadContacts();
                    exten_number = tv.SelectedNode.Tag.ToString();
                }
                else
                {
                    // Если выбран какой либо телефон внутри контакта то звоним именно на этот телефон
                    exten_number = tv.SelectedNode.Text;
                }

                if (!string.IsNullOrEmpty(CONTEXT_DIAL_NUMBER))
                {
                    exten_number = CONTEXT_DIAL_NUMBER;
                }
                CONTEXT_DIAL_NUMBER = string.Empty;

                OriginateAction oa = new OriginateAction();
                // Context: Название контекста для совершения исходящего вызова (используется только совместно с параметрами Exten и Priority)
                oa.Context = ORIGINATE_CONTEXT; // from-internal

                // Priority: Priority to use on connect (используется только совместно с параметрами Context и Exten)
                oa.Priority = ORIGINATE_PRIORITY; // 1

                // Exten: Extension to use on connect (используется только совместно с параметрами Context и Priority)
                oa.Exten = exten_number;

                //CallerID: Значение CallerID, используемое для совершения исходящего вызова.
                oa.CallerId = ASTERISK_PEER_NUMBER.Split('/')[1];

                // Channel: Название канала, с которого совершается исходящий вызов (В том же формате, как если бы Вы совершали вызов этому абоненту командой Dial.)
                oa.Channel = ASTERISK_PEER_NUMBER; // SIP/1001

                // Timeout: Таймаут (в миллисекундах) для соединения с инициатором исходящего вызова (значение по умолчанию: 30000 миллисекунд).
                oa.Timeout = ORIGINATE_TIMEOUT;

                // Async: Если указано “true” исходящий вызов будет производиться асинхронно. 
                // Результат ее выполнения будет возвращен позже, в пакете типа “Event” 
                // (позволяет осуществлять несколько вызовов без ожидания результата предыдущей команды, совершающей исходящий вызов)
                oa.Async = true;

                ManagerResponse originateResponse = manager.SendAction(oa, oa.Timeout);

                if (originateResponse.Response.Contains("Success"))
                {
                   		Log ("Call to " + exten_number + " initialized");
                   		//Tray.ShowBalloonTip(500, "Call", "Call to " + exten_number + " initialized", ToolTipIcon.Info);
                }
                else
                {
                		Log ("Error: Call to " + exten_number + " not success");
                }
            }
            catch (Exception err)
            {
                Log ("Error:  " + err.Message);
            }
        }

		//-------------------------------------------------------------------------------------------------------------

		private void EditButton_Click(object sender, EventArgs e)
        {
            ADD_OR_EDIT_RESULT = false;

            TreeView tv;
            if (FindTreeView.Visible)
            {
                tv = (TreeView)FindTreeView;
            }
            else
            {
                tv = (TreeView)ContactsTreeView;
            }

            EditCallerForm ec = new EditCallerForm();
            ec.Owner = this;
            ec.ACTION = 1; // редактировать

            tv.Focus();
            if (tv.SelectedNode.Level == 0)
            {
                ec.CALLER_ID = tv.SelectedNode.Tag.ToString();
            }
            else
            {
                TreeNode currNode = tv.SelectedNode;
                currNode = currNode.Parent;
                ec.CALLER_ID = currNode.Tag.ToString();
            }
            
            ec.ShowDialog();
            ec.Dispose();

            if (ADD_OR_EDIT_RESULT == true)
            {
                // Перезагружаем основной контакт лист после изменений
                LoadContacts();
                // Если мы в режиме поиска, то после изменений перезагружаем и дерево поиска
                if (FindTreeView.Visible == true) SearchTextBox_TextChanged(this, null);
            }

            SearchTextBox.Focus();
        }

		//-------------------------------------------------------------------------------------------------------------

		private void AddButton_Click(object sender, EventArgs e)
        {
            if (!CheckActivation()) return;

            ADD_OR_EDIT_RESULT = false;

            EditCallerForm ec = new EditCallerForm();
            ec.Owner = this;
            ec.ACTION = 2; // добавить
            ec.ShowDialog();
            ec.Dispose();

            if (ADD_OR_EDIT_RESULT == true)
            {
                LoadContacts();
                // Если мы в режиме поиска, то после изменений перезагружаем и дерево поиска
                if (FindTreeView.Visible == true) SearchTextBox_TextChanged(this, null);
            }

            SearchTextBox.Focus();
        }

		//-------------------------------------------------------------------------------------------------------------

		private void CollapseButton_Click(object sender, EventArgs e)
        {
            FindTreeView.CollapseAll();
            ContactsTreeView.CollapseAll();

            if (FindTreeView.Visible == true)
            {
                FindTreeView.Focus();
            }
            else
            {
                ContactsTreeView.Focus();
            }
        }

		//-------------------------------------------------------------------------------------------------------------

		#region Search
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if (SearchTextBox.Text.Length == 0)
            {
                FindTreeView.Visible = false;
                ClearFindButton.Visible = false;
                return;
            }

            if (SearchTextBox.Text.Length > 1)
            {
                FindTreeView.Nodes.Clear();
                FindTreeView.Visible = true;
                FindTreeView.Refresh();
                ClearFindButton.Visible = true;
                ClearFindButton.Refresh();

                FindTreeView.BeginUpdate();
                FindNodesInTreeView(ContactsTreeView.Nodes, SearchTextBox.Text.Trim().ToUpper());
                FindTreeView.EndUpdate();
            }
        }

		//-------------------------------------------------------------------------------------------------------------

		private void FindNodesInTreeView(TreeNodeCollection nodes, string SearchValue)
        {
            foreach (TreeNode tn in nodes)
            {
                if (tn.Text.ToUpper().Contains(SearchValue))
                {
                    TreeNode resultNode = tn;
                    if (resultNode.Level != 0)
                    {
                        resultNode = resultNode.Parent;
                    }

                    // проверяем что найденного человека уже нет в списке найденных, т.к. могут совпадать цифры у нескольких номеров 2[270] и 578[270]
                    // чтобы не добавлять одного и того же несколько раз
                    bool nodeExist = false;
                    foreach (TreeNode tnexist in FindTreeView.Nodes)
                    {
                        if (resultNode.Text == tnexist.Text)
                        {
                            nodeExist = true;
                            break;
                        }
                    }
                    
                    if (nodeExist == false)
                    {
                        FindTreeView.Nodes.Add((TreeNode)resultNode.Clone());
                    }
                }
                
                // рекурсия
                FindNodesInTreeView(tn.Nodes, SearchValue);
            }
        }
        #endregion

        /// <summary>
        /// По клику !правой! кнопки мыши на ноде дерева выделяем ноду для дальнейшего взятия ее аттрибутов из контекстного меню
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
		//-------------------------------------------------------------------------------------------------------------

		private void FindTreeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Right) return;

            if (sender is TreeView)
            {
                TreeView tv = (TreeView)sender;
                tv.SelectedNode = e.Node;

                if (tv.SelectedNode.Level == 0)
                {
                    contextMenuStrip1.ItemClicked -= new ToolStripItemClickedEventHandler(ToolStripMenuItem_Click_Event);
                    //contextMenuStrip1.ImageList = ContextMenuImageList;

                    contextMenuStrip1.Items.Clear();
                    contextMenuStrip1.Items.Add(tv.SelectedNode.Text);
                    contextMenuStrip1.Items[0].ImageIndex = 0;
                    contextMenuStrip1.Items.Add("-");

                    int ItemIndex = 2;
                    foreach (TreeNode child in tv.SelectedNode.Nodes)
                    {
                        contextMenuStrip1.Items.Add("Call - " + child.Text);
                        contextMenuStrip1.Items[ItemIndex].ImageIndex = 1;
                        ItemIndex++;
                    }
                    
                    contextMenuStrip1.Items.Add("-");
                    ItemIndex++;
                    contextMenuStrip1.Items.Add("Edit");
                    contextMenuStrip1.Items[ItemIndex].ImageIndex = 2;
                    ItemIndex++;
                    contextMenuStrip1.Items.Add("Delete");
                    contextMenuStrip1.Items[ItemIndex].ImageIndex = 3;

                    contextMenuStrip1.Items[0].Font = new Font(contextMenuStrip1.Items[0].Font, FontStyle.Bold);
                    contextMenuStrip1.Items[0].Enabled = false;
                    
                    contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(ToolStripMenuItem_Click_Event);
                }
            }
        }

		//-------------------------------------------------------------------------------------------------------------

		private void ToolStripMenuItem_Click_Event(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            
            if (item.Text == "Delete")
            {
                string caller_fio = string.Empty;
                string caller_id = string.Empty;

                TreeView tv;
                if (FindTreeView.Visible)
                {
                    tv = (TreeView)FindTreeView;
                }
                else
                {
                    tv = (TreeView)ContactsTreeView;
                }
                tv.Focus();
                caller_fio = tv.SelectedNode.Text;
                caller_id = tv.SelectedNode.Tag.ToString();

                if (MessageBox.Show(string.Format("Delete contact {0} ?", caller_fio), @"Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    //string CommandText = string.Format("UPDATE callers SET deleted=1, callercreator='{0}', datecreate='{1}' WHERE mainphone='{2}';", Environment.UserName, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), caller_mainphone);
                    string CommandText = string.Format("DELETE FROM callers WHERE callerid='{0}';", caller_id);
                    MySqlConnection myConnection = new MySqlConnection(CONNECTION_STRING);
                    MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);

                    try
                    {
                        myConnection.Open();
                        MySqlDataReader MyDataReader;
                        MyDataReader = myCommand.ExecuteReader();
                        MyDataReader.Close();

                        CommandText = string.Format("UPDATE callerschange SET chdatetime='{0}';", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        MySqlCommand myCommand1 = new MySqlCommand(CommandText, myConnection);
                        MyDataReader = myCommand1.ExecuteReader();
                        MyDataReader.Close();

                        LoadContacts();
                    }
                    catch (Exception exConnecting)
                    {
                        Log ("Error:  " + exConnecting.Message);
                        return;
                    }
                    finally
                    {
                        myConnection.Close();
                    }
                }

                LoadContacts();
                // Если мы в режиме поиска, то после изменений перезагружаем и дерево поиска
                if (FindTreeView.Visible == true) SearchTextBox_TextChanged(this, null);
            }

            if (item.Text == "Edit")
            {
                EditButton_Click(this, null);
            }

            if (item.Text.Contains("Call"))
            {
                if (RingButton.Enabled != false)
                {
                    CONTEXT_DIAL_NUMBER = item.Text.Replace("Call - ", string.Empty);
                    RingButton_Click(ContactsTreeView, null);
                }
            }
        }

        /// <summary>
        /// При двойном щелчке !левой! кнопкой мыши на ноде дерева второго уровня (т.е. телефоне абонента) осуществляем оригинацию на этот номер
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        //-------------------------------------------------------------------------------------------------------------

		private void FindTreeView_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button != MouseButtons.Left) return;

            if (sender is TreeView)
            {
                TreeView tv = (TreeView)sender;
                if (tv.SelectedNode.Level > 0)
                {
                    if (RingButton.Enabled == true)
                    {
                        RingButton_Click(tv, null);
                    }
                    else
                    {
						Log ("Error: Peer not registered");                    
                    }
                }
            }
        }

		//-------------------------------------------------------------------------------------------------------------

		private void ClearFindButton_Click(object sender, EventArgs e)
        {
            SearchTextBox.Text = string.Empty;
            SearchTextBox.Focus();
        }

        /// <summary>
        /// Return MD5 of processorId from first CPU in machine
        /// </summary>
        /// <returns>[string] ProcessorId</returns>

        //-------------------------------------------------------------------------------------------------------------

		public string GetCPUId()
        {
            string cpuInfo = String.Empty;
            string temp = String.Empty;
            ManagementClass mc = new ManagementClass("Win32_Processor");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if (cpuInfo == String.Empty)
                {// only return cpuInfo from first CPU
                    cpuInfo = mo.Properties["ProcessorId"].Value.ToString();
                }
            }
            return GetMD5(cpuInfo);
        }

		//-------------------------------------------------------------------------------------------------------------

		private string GetMD5(string inputData)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(inputData));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                return sBuilder.ToString();
            }
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void ToolTip1Popup(object sender, PopupEventArgs e)
        {
        	
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void AsteriskPhoneAgentFormFormClosed(object sender, FormClosedEventArgs e)
        {
        	
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void TrayMouseDoubleClick(object sender, MouseEventArgs e)
        {
        	
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void ContextMenuStrip1Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        	
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void ContextMenuStrip2Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
        	
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void ExitToolStripMenuItemClick(object sender, EventArgs e)
        {
        	ExitForm();
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void OpenToolStripMenuItemClick(object sender, EventArgs e)
        {
    	        if (this.WindowState == FormWindowState.Minimized)
    	        {
    	            this.Visible = true;
    	            this.ShowInTaskbar = true;
    	            this.WindowState = FormWindowState.Normal;
    	        }
    	        // Если окно уже развернуто из трея, но !возможно! скрыто под другими окнами показываем его поверх всех окон
    	        else if (this.WindowState == FormWindowState.Normal)
    	        {
	                SetForegroundWindow(this.Handle);
            	}

            	SearchTextBox.Focus();
            	this.Activate();        	
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void AboutToolStripMenuItemClick(object sender, EventArgs e)
        {
            fmAbout fm = new fmAbout();
            fm.Owner = this;
            fm.ShowDialog();
            fm.Dispose();	
        }
        
		//-------------------------------------------------------------------------------------------------------------

        void PreferencesToolStripMenuItemClick(object sender, EventArgs e)
        {
            fmPreference fm = new fmPreference();
            fm.Owner = this;
            fm.ShowDialog();
            fm.Dispose();	       	
        }
        
         //-------------------------------------------------------------------------------------------------------------

       public void AsteriskPhoneAgentFormActivated(object sender, EventArgs e)
        {
        	if (NEED_READ_CONFIG)
        	{
        		NEED_READ_CONFIG = false;
        		ReloadSettings();
        	}
        }
        
        void BtSetupClick(object sender, EventArgs e)
        {

        	fmPreference fm = new fmPreference();
            fm.Owner = this;
            fm.ShowDialog();
            fm.Dispose();
        }
        
        void BtHistoryClick(object sender, EventArgs e)
        {
            if (!CheckActivation()) return;

            if (LicenseType>1) {
	        	fmHistory fm = new fmHistory();
	            fm.Owner = this;
	            fm.USER_ID = ASTERISK_PEER_NUMBER.Split('/')[1];
	            fm.ASTERISK_PEER_NUMBER = ASTERISK_PEER_NUMBER;
	            fm.ORIGINATE_CONTEXT = ORIGINATE_CONTEXT;
	            fm.ORIGINATE_PRIORITY = ORIGINATE_PRIORITY;
	            fm.ORIGINATE_TIMEOUT = ORIGINATE_TIMEOUT;
	            fm.RINGENABLED = RingButton.Enabled;
	            fm.EXTPREFIX = EXTERNALCALLPREFIX;
	            fm.ASTERISK_HOST = ASTERISK_HOST;
	            fm.ASTERISK_PORT = ASTERISK_PORT;
	            fm.ASTERISK_LOGINNAME = ASTERISK_LOGINNAME;
	            fm.ASTERISK_LOGINPWD = ASTERISK_LOGINPWD;
	            //Log(fm.USER_ID);
	            fm.ShowDialog();
	            fm.Dispose();        	
        		
        	} else {MessageBox.Show("Activation", "You need Standart or PRO version", MessageBoxButtons.OK, MessageBoxIcon.Error);}
        }
    }
}
