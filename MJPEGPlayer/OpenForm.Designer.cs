namespace unvell.MotionClient
{
	partial class OpenForm
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtStreamURL = new System.Windows.Forms.TextBox();
			this.btnOpen = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.chkRemember = new System.Windows.Forms.CheckBox();
			this.txtProxyPort = new System.Windows.Forms.TextBox();
			this.txtProxyPwd = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtProxyHost = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtProxyUser = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.rdoUseProxy = new System.Windows.Forms.RadioButton();
			this.rdoDirectConnect = new System.Windows.Forms.RadioButton();
			this.lnkAdvance = new System.Windows.Forms.LinkLabel();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(22, 17);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(69, 12);
			this.label1.TabIndex = 0;
			this.label1.Text = "Stream URL:";
			// 
			// txtStreamURL
			// 
			this.txtStreamURL.Location = new System.Drawing.Point(24, 38);
			this.txtStreamURL.Name = "txtStreamURL";
			this.txtStreamURL.Size = new System.Drawing.Size(254, 19);
			this.txtStreamURL.TabIndex = 1;
			// 
			// btnOpen
			// 
			this.btnOpen.Location = new System.Drawing.Point(284, 36);
			this.btnOpen.Name = "btnOpen";
			this.btnOpen.Size = new System.Drawing.Size(65, 22);
			this.btnOpen.TabIndex = 2;
			this.btnOpen.Text = "Open";
			this.btnOpen.UseVisualStyleBackColor = true;
			this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.chkRemember);
			this.groupBox1.Controls.Add(this.txtProxyPort);
			this.groupBox1.Controls.Add(this.txtProxyPwd);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.txtProxyHost);
			this.groupBox1.Controls.Add(this.label5);
			this.groupBox1.Controls.Add(this.label3);
			this.groupBox1.Controls.Add(this.txtProxyUser);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.rdoUseProxy);
			this.groupBox1.Controls.Add(this.rdoDirectConnect);
			this.groupBox1.Location = new System.Drawing.Point(24, 73);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(273, 169);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Proxy";
			this.groupBox1.Visible = false;
			// 
			// chkRemember
			// 
			this.chkRemember.AutoSize = true;
			this.chkRemember.Location = new System.Drawing.Point(92, 142);
			this.chkRemember.Name = "chkRemember";
			this.chkRemember.Size = new System.Drawing.Size(171, 16);
			this.chkRemember.TabIndex = 10;
			this.chkRemember.Text = "Remember proxy information";
			this.chkRemember.UseVisualStyleBackColor = true;
			// 
			// txtProxyPort
			// 
			this.txtProxyPort.Location = new System.Drawing.Point(215, 68);
			this.txtProxyPort.Name = "txtProxyPort";
			this.txtProxyPort.Size = new System.Drawing.Size(40, 19);
			this.txtProxyPort.TabIndex = 5;
			this.txtProxyPort.Text = "8080";
			// 
			// txtProxyPwd
			// 
			this.txtProxyPwd.Location = new System.Drawing.Point(92, 117);
			this.txtProxyPwd.Name = "txtProxyPwd";
			this.txtProxyPwd.PasswordChar = '*';
			this.txtProxyPwd.Size = new System.Drawing.Size(115, 19);
			this.txtProxyPwd.TabIndex = 9;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(28, 120);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 12);
			this.label4.TabIndex = 8;
			this.label4.Text = "Password:";
			// 
			// txtProxyHost
			// 
			this.txtProxyHost.Location = new System.Drawing.Point(92, 68);
			this.txtProxyHost.Name = "txtProxyHost";
			this.txtProxyHost.Size = new System.Drawing.Size(115, 19);
			this.txtProxyHost.TabIndex = 3;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(208, 71);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(7, 12);
			this.label5.TabIndex = 4;
			this.label5.Text = ":";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(53, 71);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 12);
			this.label3.TabIndex = 2;
			this.label3.Text = "Host:";
			// 
			// txtProxyUser
			// 
			this.txtProxyUser.Location = new System.Drawing.Point(92, 93);
			this.txtProxyUser.Name = "txtProxyUser";
			this.txtProxyUser.Size = new System.Drawing.Size(115, 19);
			this.txtProxyUser.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(28, 96);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(58, 12);
			this.label2.TabIndex = 6;
			this.label2.Text = "Username:";
			// 
			// rdoUseProxy
			// 
			this.rdoUseProxy.AutoSize = true;
			this.rdoUseProxy.Location = new System.Drawing.Point(14, 42);
			this.rdoUseProxy.Name = "rdoUseProxy";
			this.rdoUseProxy.Size = new System.Drawing.Size(85, 16);
			this.rdoUseProxy.TabIndex = 1;
			this.rdoUseProxy.Text = "HTTP Proxy";
			this.rdoUseProxy.UseVisualStyleBackColor = true;
			// 
			// rdoDirectConnect
			// 
			this.rdoDirectConnect.AutoSize = true;
			this.rdoDirectConnect.Checked = true;
			this.rdoDirectConnect.Location = new System.Drawing.Point(14, 20);
			this.rdoDirectConnect.Name = "rdoDirectConnect";
			this.rdoDirectConnect.Size = new System.Drawing.Size(109, 16);
			this.rdoDirectConnect.TabIndex = 0;
			this.rdoDirectConnect.TabStop = true;
			this.rdoDirectConnect.Text = "Directly Connect";
			this.rdoDirectConnect.UseVisualStyleBackColor = true;
			// 
			// lnkAdvance
			// 
			this.lnkAdvance.AutoSize = true;
			this.lnkAdvance.Location = new System.Drawing.Point(22, 65);
			this.lnkAdvance.Name = "lnkAdvance";
			this.lnkAdvance.Size = new System.Drawing.Size(49, 12);
			this.lnkAdvance.TabIndex = 3;
			this.lnkAdvance.TabStop = true;
			this.lnkAdvance.Text = "Advance";
			this.lnkAdvance.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAdvance_LinkClicked);
			// 
			// OpenForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(379, 86);
			this.Controls.Add(this.lnkAdvance);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.btnOpen);
			this.Controls.Add(this.txtStreamURL);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Open Stream";
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtStreamURL;
		private System.Windows.Forms.Button btnOpen;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox txtProxyPwd;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtProxyHost;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtProxyUser;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton rdoUseProxy;
		private System.Windows.Forms.RadioButton rdoDirectConnect;
		private System.Windows.Forms.TextBox txtProxyPort;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.LinkLabel lnkAdvance;
		private System.Windows.Forms.CheckBox chkRemember;
	}
}