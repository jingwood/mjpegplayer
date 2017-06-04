using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace unvell.MotionClient
{
	class MJPEGClient
	{
		public string Url { get; set; }

		public MJPEGClient()
			: this(string.Empty)
		{
		}

		public MJPEGClient(string url)
		{
			this.Url = url;
		}

		Thread thread;

		public void Start()
		{
			running = true;

			thread = new Thread(Running);
			thread.Start();
		}

		public void Stop()
		{
			running = false;
		}

		public void Restart()
		{
			requestRestart = true;
		}

		private bool requestRestart = false;
		private bool running = false;

		public bool Retrying { get; set; }

		private Image lastFrame;

		public void Running()
		{
			while (running)
			{
				using (WebClient wc = new WebClient())
				{
					if (HttpProxyInfo.Current != null && HttpProxyInfo.Current.UseProxy)
					{
						//wc.Proxy = new WebProxy("jp-gateway05", 8080);
						wc.Proxy = new WebProxy(HttpProxyInfo.Current.Host, HttpProxyInfo.Current.Port);

						if (!string.IsNullOrEmpty(HttpProxyInfo.Current.User)
							&& !string.IsNullOrEmpty(HttpProxyInfo.Current.Password))
						{
							wc.Proxy.Credentials = new NetworkCredential(
								HttpProxyInfo.Current.User, HttpProxyInfo.Current.Password,
								HttpProxyInfo.Current.Domain);
						}
					}

					try
					{
						using (Stream s = (wc.OpenRead(Url)))
						{
							Retrying = false;

							string line = wc.ResponseHeaders["Content-Type"];
							int i = line.LastIndexOf("boundary=");
							string splitter = i >= 0 ? line.Substring(i + 9) : "--BoundaryString";

							while (running)
							{
								line = ReadLine(s);
								if (line != splitter) break;

								line = ReadLine(s);	// content-type
								line = ReadLine(s); // content-size
								i = line.LastIndexOf(':');
								line = line.Substring(i + 1);
								int len = int.Parse(line);

								ReadLine(s);

								lastFrame = CurrentFrame;
								CurrentFrame = ReadFrame(s, len);

								if (FrameUpdated != null) FrameUpdated(this, new FrameUpdatedEventArgs(CurrentFrame));

								if (lastFrame != null)
								{
									lastFrame.Dispose();
									lastFrame = null;
								}

								Debug.WriteLine("image received: " + len + " bytes.");

								line = ReadLine(s);

								if (requestRestart)
								{
									break;
								}
							}
						}
					}
					catch (Exception ex)
					{
						Console.WriteLine(ex.ToString());
					}
				}

				if (requestRestart)
				{
					requestRestart = false;
				}
				else
				{
					if (CurrentFrame != null)
					{
						CurrentFrame.Dispose();
						CurrentFrame = null;
					}

					Retrying = true;
					FrameUpdated(this, null);

					Thread.Sleep(5000);
				}
			}

		}

		public Image CurrentFrame { get; set; }

		public DateTime LastReceiveTime { get; set; }

		public int BytesPerSecond { get; set; }

		private int currentBPS = 0;

		private void UpdateBPS(int bytes)
		{
			if ((DateTime.Now - LastReceiveTime).TotalMilliseconds > 1000)
			{
				BytesPerSecond = currentBPS;
				currentBPS = 0;
				LastReceiveTime = DateTime.Now;
			}
			else
			{
				currentBPS += bytes;
			}
		}

		public event EventHandler<FrameUpdatedEventArgs> FrameUpdated;

		MemoryStream linems = new MemoryStream(1024);
		MemoryStream jpegms = new MemoryStream(10240);

		string ReadLine(Stream stream)
		{
			linems.SetLength(0);
			linems.Position = 0;

			int b = stream.ReadByte();
			UpdateBPS(1);
			while (b != '\n')
			{
				if (b == -1)
				{
					throw new Exception("cannot read from remote server.");
				}
				if (b != '\r') linems.WriteByte((byte)b);
				b = stream.ReadByte();
				UpdateBPS(1);
			}

			return Encoding.ASCII.GetString(linems.ToArray());
		}

		byte[] buff = new byte[4096];

		Image ReadFrame(Stream s, int length)
		{
			jpegms.SetLength(0);
			jpegms.Position = 0;

			int received = 0;
			int readBytes = 0;

			while (true)
			{
				int want = length - received;
				if (want > buff.Length) want = buff.Length;

				readBytes = s.Read(buff, 0, want);
				if (want == 0 || readBytes == 0) break;
				UpdateBPS(readBytes);

				jpegms.Write(buff, 0, readBytes);
				received += readBytes;
			}

			jpegms.Position = 0;

			return Image.FromStream(jpegms);
		}
	}

	class FrameUpdatedEventArgs : EventArgs
	{
		public FrameUpdatedEventArgs(Image image)
		{
			this.Image = image;
		}
		public Image Image { get; set; }
	}

	class HttpProxyInfo
	{
		public string Host { get; set; }
		public int Port { get; set; }

		public string Domain { get; set; }
		public string User { get; set; }
		public string Password { get; set; }

		public static HttpProxyInfo Current { get; set; }

		public bool UseProxy { get; set; }
	}
}
