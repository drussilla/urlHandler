using System;
using urlHandler.Common.Interfaces;
using System.Configuration;

namespace urlHandler.Common
{
	public class DynamicProcessName : IProcessName
	{
		private static readonly object Sync = new object();

		private static volatile DynamicProcessName instance;

		private DynamicProcessName()
		{
		}

		public static DynamicProcessName Instance
		{
			get
			{
				if (instance == null)
				{
					lock (Sync)
					{
						if (instance == null)
						{
							instance = new DynamicProcessName();
						}
					}
				}

				return instance;
			}
		}

		public string GetParentProcessName()
		{
			try
			{
				string value = ConfigurationManager.AppSettings["Platform"];
				if (string.IsNullOrEmpty(value))
				{
					Console.WriteLine ("Platform value should be specified in config to check ProcessName rule");
				}
				IProcessName implementation = null;
				if (value.Equals("Windows", StringComparison.OrdinalIgnoreCase))
				{
					implementation = Activator.CreateInstance("urlHandler.WinApiLayer", "urlHandler.WinApiLayer.ProcessName").Unwrap() as IProcessName;

				}
				else if (value.Equals("Unix", StringComparison.OrdinalIgnoreCase))
				{
					implementation = Activator.CreateInstance("urlHandler.UnixLayer", "urlHandler.UnixLayer.ProcessName").Unwrap() as IProcessName;
				}

				if (implementation != null)
				{
					Console.WriteLine (implementation.GetParentProcessName());
				}
				else
				{
					Console.WriteLine ("Implementetion of GetParentProcessName not found. Platform value should be specified in config to check ProcessName rule.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine (ex.Message + "\n\n" + ex.StackTrace);
			}

			return "test";
		}
	}
}

