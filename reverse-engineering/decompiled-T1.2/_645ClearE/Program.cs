using System;
using System.Globalization;
using System.Threading;
using System.Windows.Forms;

namespace _645ClearE;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Thread.CurrentThread.CurrentUICulture = new CultureInfo("en");
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		Application.Run((Form)(object)new Form1());
	}
}
