using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
//using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AsteriskPhoneAgent
{
    public partial class NoteForm : Form
    {
        public NoteForm()
        {
            InitializeComponent();
        }

        public string CALLER_NOTE = string.Empty;

        private void NoteForm_Load(object sender, EventArgs e)
        {
            // размещаем форму с примечанием рядом с формой информации о звонке
            this.Top = Owner.Top;
            this.Left = Owner.Left - this.Width;

            label1.Text = CALLER_NOTE;
        }
    }
}
