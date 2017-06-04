namespace unvell.MotionClient
{
	partial class MainForm
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showScreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.openStreamToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
			this.autoSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.resetToDefaultSizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
			this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text = "unvell MJPEG Player";
			this.notifyIcon1.Visible = true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showScreenToolStripMenuItem,
            this.openStreamToolStripMenuItem,
            this.toolStripMenuItem1,
            this.autoSizeToolStripMenuItem,
            this.resetToDefaultSizeToolStripMenuItem,
            this.toolStripMenuItem2,
            this.exitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(200, 126);
			// 
			// showScreenToolStripMenuItem
			// 
			this.showScreenToolStripMenuItem.Name = "showScreenToolStripMenuItem";
			this.showScreenToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.showScreenToolStripMenuItem.Text = "Show Screen";
			this.showScreenToolStripMenuItem.Click += new System.EventHandler(this.showScreenToolStripMenuItem_Click);
			// 
			// openStreamToolStripMenuItem
			// 
			this.openStreamToolStripMenuItem.Name = "openStreamToolStripMenuItem";
			this.openStreamToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.openStreamToolStripMenuItem.Text = "Open Stream...";
			this.openStreamToolStripMenuItem.Click += new System.EventHandler(this.openStreamToolStripMenuItem_Click);
			// 
			// toolStripMenuItem1
			// 
			this.toolStripMenuItem1.Name = "toolStripMenuItem1";
			this.toolStripMenuItem1.Size = new System.Drawing.Size(196, 6);
			// 
			// autoSizeToolStripMenuItem
			// 
			this.autoSizeToolStripMenuItem.Checked = true;
			this.autoSizeToolStripMenuItem.CheckOnClick = true;
			this.autoSizeToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoSizeToolStripMenuItem.Name = "autoSizeToolStripMenuItem";
			this.autoSizeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.autoSizeToolStripMenuItem.Text = "Auto Size";
			this.autoSizeToolStripMenuItem.CheckedChanged += new System.EventHandler(this.autoSizeToolStripMenuItem_CheckedChanged);
			// 
			// resetToDefaultSizeToolStripMenuItem
			// 
			this.resetToDefaultSizeToolStripMenuItem.Name = "resetToDefaultSizeToolStripMenuItem";
			this.resetToDefaultSizeToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.resetToDefaultSizeToolStripMenuItem.Text = "Reset to Default Size";
			this.resetToDefaultSizeToolStripMenuItem.Click += new System.EventHandler(this.resetToDefaultSizeToolStripMenuItem_Click);
			// 
			// toolStripMenuItem2
			// 
			this.toolStripMenuItem2.Name = "toolStripMenuItem2";
			this.toolStripMenuItem2.Size = new System.Drawing.Size(196, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
			this.ClientSize = new System.Drawing.Size(352, 288);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Name = "MainForm";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.Text = "MJPEG Client";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon notifyIcon1;
		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem openStreamToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem showScreenToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
		private System.Windows.Forms.ToolStripMenuItem autoSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem resetToDefaultSizeToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
	}
}

