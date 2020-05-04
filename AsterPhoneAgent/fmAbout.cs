using System;
using System.Drawing;
using System.Windows.Forms;

namespace AsteriskPhoneAgent
{
	/// <summary>
	/// </summary>
	public partial class fmAbout		: Form
	{
		public fmAbout()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		void FmAboutLoad(object sender, EventArgs e)
		{
			lbVersion.Text = "Version " + AsteriskPhoneAgentForm.VERSION;
		}
		
		void Label2Click(object sender, EventArgs e)
		{
			
		}
		
		void Label5Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start(label5.Text);
		}
	}
}
