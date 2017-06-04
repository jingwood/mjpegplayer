using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

using unvell.MJPEGPlayer.Properties;

namespace unvell.MotionClient
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();

			DoubleBuffered = true;

			m1.FrameUpdated += (s, e) =>
			{
				Image image = m1.CurrentFrame;

				if (image != null)
				{
					this.ImageSize = image.Size;

					if (this.IsAutoSize)
					{
						ResizeScreenToImage(1f);
					}
				}

				Invalidate();
			};

			this.IsAutoSize = true;
		}

		public bool IsAutoSize { get; set; }
		public Size ImageSize { get; set; }

		MJPEGClient m1 = new MJPEGClient();

		private void Form1_Load(object sender, EventArgs e)
		{
			m1.Start();
		}

		protected override void OnClosing(CancelEventArgs e)
		{
			base.OnClosed(e);

			m1.Stop();
		}

		#region Mouse

		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);

			hover = true;
			Invalidate();
		}

		protected override void OnMouseLeave(EventArgs e)
		{
			base.OnMouseLeave(e);

			hover = false;
			Invalidate();
		}

		private bool resizing = false;
		private bool moving = false;

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);

			if (closeRect.Contains(e.Location))
			{
				Hide();
			}
			else if (openRect.Contains(e.Location))
			{
				openStreamToolStripMenuItem.PerformClick();
			}
			else if (sizeRect.Contains(e.Location))
			{
				Capture = true;
				resizing = true;
				this.IsAutoSize = false;
				this.autoSizeToolStripMenuItem.Checked = false;
				Invalidate();
			}
			else if (pinRect.Contains(e.Location))
			{
				TopMost = !TopMost;
				Invalidate();
			}
			else
			{
				moving = true;
				offset = e.Location;
			}
		}

		protected override void OnMouseUp(MouseEventArgs e)
		{
			base.OnMouseUp(e);

			resizing = false;
			moving = false;

			Invalidate();
		}

		private Point offset;

		protected override void OnMouseMove(MouseEventArgs e)
		{
			base.OnMouseMove(e);

			if (closeRect.Contains(e.Location)
				|| pinRect.Contains(e.Location)
				|| openRect.Contains(e.Location))
			{
				Cursor = Cursors.Hand;
			}
			else if (sizeRect.Contains(e.Location))
			{
				Cursor = Cursors.SizeNWSE;
			}
			else
			{
				Cursor = Cursors.Default;
			}

			if (moving)
			{
				Point p = PointToScreen(e.Location);
				Left = p.X - offset.X;
				Top = p.Y - offset.Y;
			}
			else if (resizing)
			{
				Width = e.X + 10;
			}
		}

		#endregion

		Rectangle bounds;
		Rectangle openRect;
		Rectangle closeRect;
		Rectangle pinRect;
		Rectangle sizeRect;

		protected override void OnResize(EventArgs e)
		{
			base.OnResize(e);

			//float s = (float)Width / 320f;
			//0.81818181818181818181818181818182
			//Height = (int)(Width * 0.75f);
			Height = (int)(Width * 0.82f);

			bounds = new Rectangle(ClientRectangle.Left + 3, ClientRectangle.Top + 3,
				ClientRectangle.Width - 4, ClientRectangle.Height - 4);

			closeRect = new Rectangle(bounds.Width - 16, bounds.Top, 16, 16);
			pinRect = new Rectangle(bounds.Left, bounds.Top, 16, 16);
			openRect = new Rectangle(bounds.Left + 20, bounds.Top, 16, 16);
			sizeRect = new Rectangle(bounds.Width - 16, bounds.Height - 16, 16, 16);

			Invalidate();
		}

		#region Draw
		private bool hover = false;

		public bool ShowBPS = false;

		protected override void OnPaint(PaintEventArgs e)
		{
			Graphics g = e.Graphics;

			if (m1.CurrentFrame != null)
			{
				lock (m1.CurrentFrame)
				{
					g.DrawImage(m1.CurrentFrame, ClientRectangle);
				}
			}

			Rectangle bounds = ClientRectangle;

			if (hover)
			{
				Rectangle border = new Rectangle(ClientRectangle.Left, ClientRectangle.Top,
					ClientRectangle.Width - 1, ClientRectangle.Height - 1);
				g.DrawRectangle(Pens.Silver, border);
				border.Inflate(-1, -1);
				g.DrawRectangle(Pens.Silver, border);
				border.Inflate(-1, -1);
				g.DrawRectangle(Pens.Silver, border);

				g.DrawImage(TopMost ? Resources.push_pin_on : Resources.push_pin_off, pinRect);
				g.DrawImage(Resources.openHS, openRect);
				g.DrawImage(Resources.close_button, closeRect);
				g.DrawImage(Resources.size_corner, sizeRect);
			}
			//else if (TopMost)
			//{
			//  g.DrawImage(Resources.push_pin_on, pinRect);
			//}

			if (this.ShowBPS)
			{
				g.DrawString(string.Format("{0} Bps", this.m1.BytesPerSecond.ToString("###,###,###")), Font, Brushes.Gray, bounds.Width - 80, bounds.Y + 10);
			}

			if (resizing)
			{
				g.DrawString(string.Format("{0} x {1}", Width, Height), Font, Brushes.SkyBlue, bounds.Width - 80, bounds.Height - 30);
			}

			if (m1.Retrying)
			{
				g.DrawString("No data received, retrying...", Font, Brushes.Red, 10, 25);
			}
		}
		#endregion

		#region Keyboard

		protected override void OnKeyDown(KeyEventArgs e)
		{
			base.OnKeyDown(e);

			switch (e.KeyData)
			{
				case Keys.T:
					TopMost = !TopMost;
					Invalidate();
					break;

				case Keys.O:
					openStreamToolStripMenuItem.PerformClick();
					break;

				case Keys.D1:
				case Keys.Shift| Keys.D1:
					resetToDefaultSizeToolStripMenuItem.PerformClick();
					break;

				case Keys.D2:
					this.IsAutoSize = false;
					this.ResizeScreenToImage(0.75f);
					break;

				case Keys.D3:
					this.IsAutoSize = false;
					this.ResizeScreenToImage(0.5f);
					break;

				case Keys.D4:
					this.IsAutoSize = false;
					this.ResizeScreenToImage(0.25f);
					break;

				case Keys.Shift | Keys.D2:
					this.IsAutoSize = false;
					this.ResizeScreenToImage(1.25f);
					break;

				case Keys.Shift | Keys.D3:
					this.IsAutoSize = false;
					this.ResizeScreenToImage(1.5f);
					break;

				case Keys.Shift | Keys.D4:
					this.IsAutoSize = false;
					this.ResizeScreenToImage(2f);
					break;

				case Keys.S:
					this.ShowBPS = !this.ShowBPS;
					Invalidate();
					break;

				case Keys.Oemtilde:
					Hide();
					break;

				case Keys.Escape:
					Hide();
					break;
			}
		}

		private void DoResizeScreenToImage(float scale)
		{
			this.Size = new Size((int)Math.Round(this.ImageSize.Width * scale),
				(int)Math.Round(this.ImageSize.Height * scale));
		}

		private delegate void ResizeScreenToImageMethod(float scale);

		private void ResizeScreenToImage(float scale)
		{
			if (!this.ImageSize.IsEmpty)
			{
				if (this.InvokeRequired)
				{
					var method = new ResizeScreenToImageMethod(DoResizeScreenToImage);
					this.Invoke(method, scale);
				}
				else
				{
					DoResizeScreenToImage(scale);
				}
			}
		}

		#endregion

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void openStreamToolStripMenuItem_Click(object sender, EventArgs e)
		{
			var topmostBackup = this.TopMost;
			this.TopMost = false;

			using (OpenForm of = new OpenForm())
			{
				of.Url = m1.Url;
				if (of.ShowDialog() == DialogResult.OK)
				{
					m1.Url = of.Url;
					if (!m1.Retrying) m1.Restart();
				}
			}

			this.TopMost = topmostBackup;
		}

		private void showScreenToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Visible = true;
	
			if (!TopMost)
			{
				TopMost = true;
				TopMost = false;
			}

			Focus();
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			showScreenToolStripMenuItem.PerformClick();
		}

		private void autoSizeToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
		{
			this.IsAutoSize = autoSizeToolStripMenuItem.Checked;
		}

		private void resetToDefaultSizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (!this.ImageSize.IsEmpty)
			{
				this.Size = this.ImageSize;
			}
		}
	}

	
}
