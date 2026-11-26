using System;
using System.Windows.Forms;

namespace _645ClearE;

internal static class Program
{
	[STAThread]
	private static void Main()
	{
		Application.EnableVisualStyles();
		Application.SetCompatibleTextRenderingDefault(false);
		try
		{
			Application.Run((Form)(object)new Form1());
		}
		catch (Exception ex)
		{
			throw ex;
		}
	}
}
