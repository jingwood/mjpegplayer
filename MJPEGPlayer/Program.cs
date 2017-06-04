using System;
using System.Windows.Forms;
using System.Text;

namespace unvell.MotionClient
{
	internal class CodecToolkit
	{
		private static readonly char[] alphatable = new char[] {
			',', '=', 's', '$', '#', 'G',
			'<', '>', ';', ':', 'M', 'W', 
			'p', 'Q', 'R', '2', '8', 
			'U', 'm', 'Z', 'X', '4',
			'y', 'V', '3', 'F', '@',
			'9', '~', '7', 'K', '5',
		};

		internal static string AlphaEncode(string str)
		{
			byte[] b = Encoding.ASCII.GetBytes(str);

			int len = b.Length * 8;

			byte[] buf = new byte[len / 5 + 1];

			for (int i = 0; i < len; i++)
			{
				buf[i / 5] |= (byte)(((b[i / 8] >> (7 - (i % 8))) & 1) << (4 - (i % 5)));
			}

			char[] cbuf = new char[buf.Length];
			for (int i = 0; i < buf.Length; i++)
			{
				cbuf[i] = alphatable[buf[i]];
			}

			return new string(cbuf);
		}

		internal static string AlphaDecode(string str)
		{
			byte[] bytes = new byte[str.Length];
			for (int i = 0; i < bytes.Length; i++)
			{
				bytes[i] = (byte)Array.IndexOf(alphatable, str[i]);
			}

			int len = bytes.Length * 5;

			byte[] buf = new byte[len / 8];

			for (int i = 0; i < len; i++)
			{
				if (i / 8 >= buf.Length) break;
				buf[i / 8] |= (byte)(((bytes[i / 5] >> (4 - (i % 5))) & 1) << (7 - (i % 8)));
			}

			return Encoding.ASCII.GetString(buf);
		}

	}

	static class Program
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm());
		}
	}
}
