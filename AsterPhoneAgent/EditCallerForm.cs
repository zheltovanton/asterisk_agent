using System;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using MySql.Data.MySqlClient;



namespace AsteriskPhoneAgent
{

public static class StringExtensions
{
    public static bool IsNullOrWhiteSpace(string value)
    {
        if (value != null)
        {
            for (int i = 0; i < value.Length; i++)
            {
                if (!char.IsWhiteSpace(value[i]))
                {
                    return false;
                }
            }
        }
        return true;
    }
}

	public partial class EditCallerForm : Form
    {
        public EditCallerForm()
        {
            InitializeComponent();
        }

        #region Global Variables

        private static string CONNECTION_STRING = AsteriskPhoneAgentForm.CONNECTION_STRING;
        public int ACTION;
        //public string CALLER_NUMBER; //передается при редактировании существующего контакта
        public string CALLER_ID = string.Empty; // передается при добавление нового контакта из формы запроса о добавлении при входящем звонке

        private Color COLOR_ENTER = Color.LightGoldenrodYellow;
        private Color COLOR_LEAVE = Color.White;
        private Color COLOR_ERROR = Color.LightPink;
        
        #endregion

        private void OKbutton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EditCallerForm_Load(object sender, EventArgs e)
        {
            // т.к. borderstyle у нас sizable со скрытыми кнопками maximize и minimize, то делаем невозможность смены размера окна пользователем
            this.MaximumSize = new System.Drawing.Size(this.Width, this.Height);
            this.MinimumSize = new System.Drawing.Size(this.Width, this.Height);

            switch (ACTION)
            {
                case 1: // редактировать
                    Text = "Edit contact";
                    LoadCallerToForm();
                    break;
                case 2: // добавить
                    Text = "Add contact";
                    if (!string.IsNullOrEmpty(CALLER_ID)) MAINPHONEtextBox.Text = CALLER_ID;
                    break;
            }
        }

        private void LoadCallerToForm()
        {
            string Connect = CONNECTION_STRING;
            string CommandText = string.Format("SELECT * FROM callers WHERE deleted=0 AND callerid='{0}';", CALLER_ID);

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

                    FIOtextBox.Text = MyDataReader["fio"].ToString().Trim();
                    ORGtextBox.Text = MyDataReader["organization"].ToString().Trim();
                    DEPtextBox.Text = MyDataReader["department"].ToString().Trim();
                    POStextBox.Text = MyDataReader["position"].ToString().Trim();
                    MAINPHONEtextBox.Text = MyDataReader["mainphone"].ToString().Trim();
                    CELLPHONEtextBox.Text = MyDataReader["cellphone"].ToString().Trim();
                    WORKPHONEtextBox.Text = MyDataReader["workphone"].ToString().Trim();
                    EMAILtextBox.Text = MyDataReader["email"].ToString().Trim();
                    NOTErichTextBox.Text = MyDataReader["note"].ToString();
                    
                    if (MyDataReader["important"].ToString() == "1")
                    {
                        IMPORTANTcheckBox.Checked = true;
                    }
                    else
                    {
                        IMPORTANTcheckBox.Checked = false;
                    }
                    
                    if (MyDataReader["personal"].ToString() != "ALL")
                    {
                        PersonalCheckBox.Checked = true;
                    }
                    else
                    {
                        PersonalCheckBox.Checked = false;
                    }

                    label9.Text = string.Format("Last edit: {0} {1}", MyDataReader["callercreator"].ToString(), MyDataReader["datecreate"].ToString());
                }
                MyDataReader.Close();
            }
            catch (Exception exConnecting)
            {
                MessageBox.Show(exConnecting.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); 
                this.Close();
                return;
            }
            finally
            {
                myConnection.Close();
            }
        }

        private void EditCallerFormTextBox_Enter(object sender, EventArgs e)
        {
            //var tb = sender as TextBox;
            if ((sender as TextBox) != null)
            {
                (sender as TextBox).BackColor = COLOR_ENTER;
                //tb.BorderStyle = BorderStyle.FixedSingle;
            }
        }

        private void EditCallerFormTextBox_Leave(object sender, EventArgs e)
        {
            //var tb = sender as TextBox;
            if ((sender as TextBox) != null)
            {
                (sender as TextBox).BackColor = COLOR_LEAVE;
                (sender as TextBox).BorderStyle = BorderStyle.None;
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(FIOtextBox.Text))
            {
                MessageBox.Show("Enter contact name!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                FIOtextBox.Focus();
                FIOtextBox.BackColor = COLOR_ERROR;
                return;
            }

            if (string.IsNullOrEmpty(MAINPHONEtextBox.Text))
            {
                MessageBox.Show("Enter main phone!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MAINPHONEtextBox.Focus();
                MAINPHONEtextBox.BackColor = COLOR_ERROR;
                return;
            }


            string CommandText = string.Empty;

            switch (ACTION)
            {
                case 1: // редактировать
                    CommandText = string.Format("UPDATE callers SET fio='{0}', organization='{1}', department='{2}', position='{3}', mainphone='{4}', cellphone='{5}', workphone='{6}', email='{7}', note='{8}' ", 
                        FIOtextBox.Text.Trim(), //0
                        ORGtextBox.Text.Trim(), //1
                        DEPtextBox.Text.Trim(), //2
                        POStextBox.Text.Trim(), //3
                        MAINPHONEtextBox.Text.Trim(), //4
                        CELLPHONEtextBox.Text.Trim(), //5
                        WORKPHONEtextBox.Text.Trim(), //6
                        EMAILtextBox.Text.Trim(), //7
                        NOTErichTextBox.Text); //8

                    if (IMPORTANTcheckBox.Checked)
                    {
                        CommandText += ", important=1 ";
                    }
                    else
                    {
                        CommandText += ", important=0 ";
                    }

                    if (PersonalCheckBox.Checked)
                    {
                        CommandText += string.Format(", personal='{0}' ", AsteriskPhoneAgentForm.ASTERISK_PEER_NUMBER);
                    }
                    else
                    {
                        CommandText += ", personal='ALL' ";
                    }

                    CommandText += string.Format(", callercreator='{0}', datecreate='{1}' WHERE callerid='{2}'", 
                        Environment.UserName, //0
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), //1
                        CALLER_ID); //2
                    break;
                case 2: // добавить
                    CommandText = string.Format("INSERT INTO callers (fio, organization, department, position, mainphone, cellphone, workphone, email, note, important, personal, callercreator, datecreate) " +
                                  " VALUES ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}' ",
                                  FIOtextBox.Text.Trim(), //0
                                  ORGtextBox.Text.Trim(), //1
                                  DEPtextBox.Text.Trim(), //2
                                  POStextBox.Text.Trim(), //3
                                  MAINPHONEtextBox.Text.Trim(), //4
                                  CELLPHONEtextBox.Text.Trim(), //5
                                  WORKPHONEtextBox.Text.Trim(), //6
                                  EMAILtextBox.Text.Trim(), //7
                                  NOTErichTextBox.Text); //8

                    if (IMPORTANTcheckBox.Checked)
                    {
                        CommandText += ", 1 ";
                    }
                    else
                    {
                        CommandText += ", 0 ";
                    }

                    if (PersonalCheckBox.Checked)
                    {
                        CommandText += string.Format(", '{0}'", AsteriskPhoneAgentForm.ASTERISK_PEER_NUMBER);
                    }
                    else
                    {
                        CommandText += ", 'ALL' ";
                    }

                    CommandText += string.Format(", '{0}', '{1}');", 
                        Environment.UserName, //0
                        DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")); //1
                    break;
            }

            MySqlConnection myConnection = new MySqlConnection(CONNECTION_STRING);
            MySqlCommand myCommand = new MySqlCommand(CommandText, myConnection);

            try
            {
                myConnection.Open(); //Устанавливаем соединение с базой данных.
                MySqlDataReader MyDataReader;
                MyDataReader = myCommand.ExecuteReader();
                MyDataReader.Close();

                CommandText = string.Format("UPDATE callerschange SET chdatetime='{0}';", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                MySqlCommand myCommand1 = new MySqlCommand(CommandText, myConnection);
                MyDataReader = myCommand1.ExecuteReader();
                MyDataReader.Close();

                this.Close();
            }
            catch (Exception exConnecting)
            {
                MessageBox.Show(exConnecting.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            finally
            {
                myConnection.Close();
            }
            
            AsteriskPhoneAgentForm.ADD_OR_EDIT_RESULT = true;
        }

        public bool IsEmail(string email)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|"
              + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)"
              + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";
            
            Regex regex = new Regex(pattern, RegexOptions.IgnoreCase);
            return regex.IsMatch(email);
        }

        private void PersonalCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (PersonalCheckBox.Checked)
            {
                IMPORTANTcheckBox.Checked = false;
                IMPORTANTcheckBox.Enabled = false;
            }
            else
            {
                IMPORTANTcheckBox.Enabled = true;
            }
        }

        private void IMPORTANTcheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (IMPORTANTcheckBox.Checked)
            {
                PersonalCheckBox.Checked = false;
                PersonalCheckBox.Enabled = false;
            }
            else
            {
                PersonalCheckBox.Enabled = true;
            }
        }
        
        void NOTErichTextBoxEnter(object sender, EventArgs e)
        {
           //  var tb = sender as RichTextBox;
            if ((sender as RichTextBox) != null)
            {
                (sender as RichTextBox).BackColor = COLOR_ENTER;
               // tb.BorderStyle = BorderStyle.FixedSingle;
            }       	
        }
        
        void EMAILtextBoxEnter(object sender, EventArgs e)
        {
            //  var tb = sender as TextBox;
            if ((sender as TextBox) != null)
            {
                (sender as TextBox).BackColor = COLOR_ENTER;
                //tb.BorderStyle = BorderStyle.FixedSingle;
            }        	
        }
        
        void NOTErichTextBoxLeave(object sender, EventArgs e)
        {
            //  var tb = sender as RichTextBox;
            if ((sender as RichTextBox) != null)
            {
                (sender as RichTextBox).BackColor = COLOR_ENTER;
                (sender as RichTextBox).BorderStyle = BorderStyle.None;
            }       	
        }
    }
}
