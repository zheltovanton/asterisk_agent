/*
 * Created by SharpDevelop.
 * User: test
 * Date: 1/22/2016
 * Time: 1:16 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;
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
using Asterisk.NET.Manager;
using Asterisk.NET.Manager.Action;
using Asterisk.NET.Manager.Response;
using Asterisk.NET.Manager.Event;

namespace AsteriskPhoneAgent
{
	/// <summary>
	/// Description of fmHistory.
	/// </summary>
	public partial class fmHistory : Form
	{
        #region Global Variables

        private static string CONNECTION_STRING = AsteriskPhoneAgentForm.CONNECTION_STRING;
        public string USER_ID = string.Empty; // передается при добавление нового контакта из формы запроса о добавлении при входящем звонке
        public string CALLTO = string.Empty;
        public string EXTPREFIX = string.Empty;
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
        private ManagerConnection manager; 
        #endregion			
    

        public fmHistory()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();

			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
	            	
		}
		
 		//-------------------------------------------------------------------------------------------------------------

 		void OKbuttonClick(object sender, EventArgs e)
		{
 			if ((manager != null) && (manager.IsConnected() == true))
            {
                manager.Logoff();
            }
			this.Close();			
		}
		
 		//-------------------------------------------------------------------------------------------------------------

 		void Panel1Paint(object sender, PaintEventArgs e)
		{
			
		}

 		//-------------------------------------------------------------------------------------------------------------

 		void FmHistoryShown(object sender, EventArgs e)
		{
			            	
			datetimeFrom.Value = DateTime.Now.AddDays(-7);
			datetimeTO.Value = DateTime.Now;
			ReloadData();
			
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

 		void ReloadData()
		{
			//var isoDateTimeFormat = CultureInfo.InvariantCulture.DateTimeFormat;
	        MySqlConnection mysqlCon = new MySqlConnection(CONNECTION_STRING);
	        mysqlCon.Open();
	        var command = mysqlCon.CreateCommand();
			command.CommandTimeout = 500;
	        
	
	        MySqlDataAdapter MyDA = new MySqlDataAdapter();
	        
	        string sqlSelectAll = string.Format(
	        	"SELECT calldate, clid, src,dst,dcontext,duration, billsec, disposition, uniqueid " +
	        	"FROM cdr " +
	        	"WHERE ((src='{0}') or (dst='{0}')) and " +
	        	"(calldate BETWEEN date('{1}') AND date('{2}')) " +
	        	"ORDER by calldate desc " +
	        	"LIMIT 0 , 200;", 
	        	USER_ID,
	        	datetimeFrom.Value.AddDays(-1).ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern),
	        	datetimeTO.Value.AddDays(1).ToString(CultureInfo.InvariantCulture.DateTimeFormat.SortableDateTimePattern));
	        MyDA.SelectCommand = new MySqlCommand(sqlSelectAll, mysqlCon);

	        DataTable table = new DataTable();
	        MyDA.Fill(table);
	
	        BindingSource bSource = new BindingSource();
	        bSource.DataSource = table;
	
	        dataGridView1.DataSource = bSource; 
			dataGridView1.Sort(dataGridView1.Columns[0], ListSortDirection.Descending);
			Log(sqlSelectAll);
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

 		void Button1Click(object sender, EventArgs e)
		{
			ReloadData();
		}
		
 		//-------------------------------------------------------------------------------------------------------------

 		void DataGridView1CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
		{
			
    		if (this.dataGridView1.Columns[e.ColumnIndex].Name == "disposition")
    		{			
				if (e.Value != null)
	        	{
	            	// Check for the string "pink" in the cell.
	            	string stringValue = (string)e.Value;
	            	stringValue = stringValue.ToLower();
	            	if ((stringValue.IndexOf("no answer") > -1))
	            	{
	            		e.CellStyle.BackColor = Color.FromArgb(200,50,50);
	            	}
	            	
	            	if ((stringValue.IndexOf("answered") > -1))
	            	{
	            	    e.CellStyle.BackColor = Color.FromArgb(50,200,50);
	            	}

	            	if ((stringValue.IndexOf("busy") > -1))
	            	{
	            	    e.CellStyle.BackColor = Color.FromArgb(250,250,150);
	            	}
				}

        	}
		}
		
		void DataGridView1MouseClick(object sender, MouseEventArgs e)
		{
			Log(e.Button.ToString());
			if (e.Button == MouseButtons.Right) 
			{
				Log("History: Datagrid right mouse click");
				string dst = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
				string src = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
				Log (dst + " " + src);
				contextMenuStrip1.ItemClicked -= new ToolStripItemClickedEventHandler(ToolStripMenuItem_Click_Event);
				contextMenuStrip1.Items.Clear();
				if (dst != USER_ID) 
				{
					contextMenuStrip1.Items.Add("Call - " + dst);
					if (RINGENABLED == false) {contextMenuStrip1.Items[0].Enabled=false;}
					if (EXTPREFIX != string.Empty) 
					{
						contextMenuStrip1.Items.Add("Call - " + EXTPREFIX + dst);
						if (RINGENABLED == false) {contextMenuStrip1.Items[1].Enabled=false;}
					}
				}
				if (src != USER_ID) 
				{
					contextMenuStrip1.Items.Add("Call - " + src);
					if (RINGENABLED == false) {contextMenuStrip1.Items[0].Enabled=false;}
					if (EXTPREFIX != string.Empty) 
					{
						contextMenuStrip1.Items.Add("Call - " + EXTPREFIX + src);
						if (RINGENABLED == false) {contextMenuStrip1.Items[1].Enabled=false;}
					}
				}
				contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(ToolStripMenuItem_Click_Event);
				int currentMouseOverRow = dataGridView1.HitTest(e.X,e.Y).RowIndex;
        		contextMenuStrip1.Show(dataGridView1, new Point(e.X, e.Y));			
			}
			if (e.Button == MouseButtons.Left)
			{
				Log("History: Datagrid left mouse click");
				string dst = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
				string src = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
				Log (dst + " " + src);
				contextMenuStrip1.ItemClicked -= new ToolStripItemClickedEventHandler(ToolStripMenuItem_Click_Event);
				contextMenuStrip1.Items.Clear();
				if (dst != USER_ID) 
				{
					contextMenuStrip1.Items.Add("Call - " + dst);
					if (RINGENABLED == false) {contextMenuStrip1.Items[0].Enabled=false;}
					if (EXTPREFIX != string.Empty) 
					{
						contextMenuStrip1.Items.Add("Call - " + EXTPREFIX + dst);
						if (RINGENABLED == false) {contextMenuStrip1.Items[1].Enabled=false;}
					}
				}
				if (src != USER_ID) 
				{
					contextMenuStrip1.Items.Add("Call - " + src);
					if (RINGENABLED == false) {contextMenuStrip1.Items[0].Enabled=false;}
					if (EXTPREFIX != string.Empty) 
					{
						contextMenuStrip1.Items.Add("Call - " + EXTPREFIX + src);
						if (RINGENABLED == false) {contextMenuStrip1.Items[1].Enabled=false;}
					}
				}
				contextMenuStrip1.ItemClicked += new ToolStripItemClickedEventHandler(ToolStripMenuItem_Click_Event);
				
			}
		}
		
	private void ToolStripMenuItem_Click_Event(object sender, ToolStripItemClickedEventArgs e)
        {
            ToolStripItem item = e.ClickedItem;
            Log("History: ToolStripMenuItem_Click_Event");
           	AsteriskPhoneAgentForm asterfm;
			asterfm = this.Owner as AsteriskPhoneAgentForm;
            if (item.Text.Contains("Call"))
            {
            	if (RINGENABLED != false)
                {
                    CALLTO = item.Text.Replace("Call - ", string.Empty);
                    
                   	OriginateAction oa = new OriginateAction();
                	// Context: Название контекста для совершения исходящего вызова (используется только совместно с параметрами Exten и Priority)
                	oa.Context = ORIGINATE_CONTEXT; // from-internal

                	// Priority: Priority to use on connect (используется только совместно с параметрами Context и Exten)
                	oa.Priority = ORIGINATE_PRIORITY; // 1

                	// Exten: Extension to use on connect (используется только совместно с параметрами Context и Priority)
                	oa.Exten = CALLTO;

                	//CallerID: Значение CallerID, используемое для совершения исходящего вызова.
                	oa.CallerId = USER_ID;

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
                   		Log ("Call to " + CALLTO + " initialized");
                   		//Tray.ShowBalloonTip(500, "Call", "Call to " + CALLTO + " initialized", ToolTipIcon.Info);
                	}
                	else
                	{
                		Log ("Error: Call to " + CALLTO + " not success");
                	}

                }
            }

        }
		
		
		void Button2Click(object sender, EventArgs e)
		{
			this.Close();
		}
		
	}
}
