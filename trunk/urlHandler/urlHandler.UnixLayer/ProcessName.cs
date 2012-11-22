using System;
using urlHandler.Common.Interfaces;

namespace urlHandler.UnixLayer
{
	public class ProcessName : IProcessName
	{
		public string GetParentProcessName()
		{
			return "Linux test";

			// TODO: write implementetion.
		}
	}
}

