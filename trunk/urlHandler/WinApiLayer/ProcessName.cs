using System;
using urlHandler.Common.Interfaces;

namespace urlHandler.WinApiLayer
{
	public class ProcessName : IProcessName
	{
		public string GetParentProcessName()
		{
			return Win32ApiWrapper.GetParentProcessName();
		}
	}
}

