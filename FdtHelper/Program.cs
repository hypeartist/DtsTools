using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DtsTools
{
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
			Application.Run(new AppForm());
		}

		// public static string Postfix = @"caf";
		// public static string Ext = @"dts";
		// public static string BaseFolder = $@"d:\7\{Postfix}\";
	}
}
