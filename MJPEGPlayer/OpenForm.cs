using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace unvell.MotionClient
{
	public partial class OpenForm : Form
	{
		public OpenForm()
		{
			InitializeComponent();

			txtStreamURL.KeyDown += (s, e) =>
			{
				if (e.KeyCode == Keys.Enter)
				{
					btnOpen.PerformClick();
				}
				else if (e.KeyCode == Keys.F10)
				{
					lnkAdvance_LinkClicked(this, null);
				}
			};

			txtProxyHost.KeyDown += txtProxyPwd_KeyDown;
			txtProxyPwd.KeyDown += txtProxyPwd_KeyDown;
		}

		void txtProxyPwd_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
			{
				btnOpen.PerformClick();
			}
		}
		
		void txtProxyHost_TextChanged(object sender, EventArgs e)
		{
			rdoUseProxy.Checked = true;
		}

		public string Url { get; set; }

		private void btnOpen_Click(object sender, EventArgs e)
		{
			Url = txtStreamURL.Text;

			if (rdoUseProxy.Checked)
			{
				if (HttpProxyInfo.Current == null)
				{
					HttpProxyInfo.Current = new HttpProxyInfo();
				}

				HttpProxyInfo.Current.UseProxy = true;

				string domain = null;
				string usr = txtProxyUser.Text;
				if (!string.IsNullOrEmpty(usr))
				{
					int i = usr.LastIndexOf('\\');
					if (i >= 0)
					{
						domain = usr.Substring(0, i);
						usr = usr.Substring(i + 1);
					}
				}

				HttpProxyInfo.Current.Host = txtProxyHost.Text.Trim();
				HttpProxyInfo.Current.Port = int.Parse(txtProxyPort.Text);
				HttpProxyInfo.Current.User = usr;
				HttpProxyInfo.Current.Domain = domain;
				HttpProxyInfo.Current.Password = txtProxyPwd.Text.Trim();
			}
			else if (HttpProxyInfo.Current != null)
			{
				HttpProxyInfo.Current.UseProxy = false;
			}

			if (chkRemember.Checked && HttpProxyInfo.Current != null)
			{
				try
				{
					Application.UserAppDataRegistry.SetValue("StreamURL", txtStreamURL.Text);

					Application.UserAppDataRegistry.SetValue("ProxyHost",
						string.Format("{0}:{1}", HttpProxyInfo.Current.Host, HttpProxyInfo.Current.Port));
					Application.UserAppDataRegistry.SetValue("ProxyUser",
						!string.IsNullOrEmpty(HttpProxyInfo.Current.Domain)
						? string.Format("{0}\\{1}", HttpProxyInfo.Current.Domain, HttpProxyInfo.Current.User)
						: HttpProxyInfo.Current.User);
					Application.UserAppDataRegistry.SetValue("ProxyPassword", CodecToolkit.AlphaEncode(HttpProxyInfo.Current.Password));
					Application.UserAppDataRegistry.SetValue("UserProxy", rdoUseProxy.Checked ? "yes" : "no");
				}
				catch { }
			}

			DialogResult = DialogResult.OK;
			Close();
		}

		protected override void OnLoad(EventArgs e)
		{
			base.OnLoad(e);

			txtStreamURL.Text = Url;
			txtStreamURL.SelectAll();
			txtStreamURL.Focus();

			if (HttpProxyInfo.Current == null)
			{

				try
				{
					bool loadSuccess = false;

					string streamUrl = Application.UserAppDataRegistry.GetValue("StreamURL") as string;
					if (!string.IsNullOrEmpty(streamUrl))
					{
						txtStreamURL.Text = streamUrl;
						loadSuccess = true;
					}

					string hostAddr = Application.UserAppDataRegistry.GetValue("ProxyHost") as string;
					if (!string.IsNullOrEmpty(hostAddr))
					{
						int colon = hostAddr.IndexOf(':');
						if (colon > 0)
						{
							txtProxyHost.Text = hostAddr.Substring(0, colon);
							txtProxyPort.Text = hostAddr.Substring(colon + 1);
							loadSuccess = true;
						}
					}

					string username = Application.UserAppDataRegistry.GetValue("ProxyUser") as string;
					if (!string.IsNullOrEmpty(username))
					{
						txtProxyUser.Text = username;
						loadSuccess = true;
					}

					string password = Application.UserAppDataRegistry.GetValue("ProxyPassword") as string;
					if (!string.IsNullOrEmpty(password))
					{
						txtProxyPwd.Text = CodecToolkit.AlphaDecode(password);
						loadSuccess = true;
					}

					int? useProxyValue = Application.UserAppDataRegistry.GetValue("UseProxy") as int?;
					if ((useProxyValue ?? 0) == 1)
					{
						lnkAdvance.PerformLayout();
						rdoUseProxy.Checked = true;
						loadSuccess = true;
					}

					if (loadSuccess)
					{
						chkRemember.Checked = true;
					}
				}
				catch { }

			}
			else
			{
				txtProxyHost.Text = HttpProxyInfo.Current.Host;
				txtProxyPort.Text = HttpProxyInfo.Current.Port.ToString();
				txtProxyUser.Text = !string.IsNullOrEmpty(HttpProxyInfo.Current.Domain)? 
					string.Format("{0}\\{1}", HttpProxyInfo.Current.Domain, HttpProxyInfo.Current.User) 
					: HttpProxyInfo.Current.User;
				txtProxyPwd.Text = HttpProxyInfo.Current.Password;
			}

			if (HttpProxyInfo.Current != null && HttpProxyInfo.Current.UseProxy)
			{
				lnkAdvance_LinkClicked(this, null);

				rdoUseProxy.Checked = true;
			}

			txtProxyHost.TextChanged += txtProxyHost_TextChanged;
			txtProxyPort.TextChanged += txtProxyHost_TextChanged;
			txtProxyUser.TextChanged += txtProxyHost_TextChanged;
			txtProxyPwd.TextChanged += txtProxyHost_TextChanged;
		}

		private void lnkAdvance_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			groupBox1.Visible = true;
			lnkAdvance.Visible = false;
			Height = 290;
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				DialogResult = System.Windows.Forms.DialogResult.Cancel;
				Close();
				return true;
			}
			else
			{
				return base.ProcessDialogKey(keyData);
			}
		}
	}
}
