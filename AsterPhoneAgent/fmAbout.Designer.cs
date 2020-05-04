
namespace AsteriskPhoneAgent
{
	partial class fmAbout
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
			this.label1 = new System.Windows.Forms.Label();
			this.lbVersion = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(2, 58);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(297, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "AsteriskPhoneAgent";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// lbVersion
			// 
			this.lbVersion.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.lbVersion.Location = new System.Drawing.Point(2, 93);
			this.lbVersion.Name = "lbVersion";
			this.lbVersion.Size = new System.Drawing.Size(297, 23);
			this.lbVersion.TabIndex = 2;
			this.lbVersion.Text = "Version";
			this.lbVersion.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label2.Location = new System.Drawing.Point(2, 116);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(297, 23);
			this.label2.TabIndex = 3;
			this.label2.Text = "Copyright 2011-2016 ";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label2.Click += new System.EventHandler(this.Label2Click);
			// 
			// label4
			// 
			this.label4.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label4.Location = new System.Drawing.Point(2, 139);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(297, 23);
			this.label4.TabIndex = 4;
			this.label4.Text = "All rights reserved.";
			this.label4.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// label5
			// 
			this.label5.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.label5.ForeColor = System.Drawing.SystemColors.HotTrack;
			this.label5.Location = new System.Drawing.Point(2, 175);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(297, 23);
			this.label5.TabIndex = 5;
			this.label5.Text = "https://AsteriskPhoneAgent.com";
			this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.label5.Click += new System.EventHandler(this.Label5Click);
			// 
			// fmAbout
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(299, 282);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.lbVersion);
			this.Controls.Add(this.label1);
			this.Name = "fmAbout";
			this.Text = "AsteriskPhoneAgent";
			this.Load += new System.EventHandler(this.FmAboutLoad);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lbVersion;
		private System.Windows.Forms.Label label1;
	}
}
