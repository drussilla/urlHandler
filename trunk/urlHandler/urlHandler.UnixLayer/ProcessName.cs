using Mono.Unix;

using System;
using System.Diagnostics;

using urlHandler.Common.Interfaces;
using System.IO;
using System.Text.RegularExpressions;

namespace urlHandler.UnixLayer
{
	public class ProcessName : IProcessName
	{
		public string GetParentProcessName()
		{
			/*
			 * In linux (KDE) kde-open opens all urls. But I can not find method to get url ivocation process name.
			 * dash is the parent process of kde-open.
			 * This function need more investigation in future.
			int parentProcessId = UnixEnvironment.GetParentProcessId();
			var parentProcess = Process.GetProcessById(parentProcessId);
			int parentParentProcessId;
			Process parentParentProcess;
			using (var stream = File.CreateText("/home/druss/urlHandler2.log"))
			{
				stream.WriteLine(parentProcess.ProcessName);

				parentParentProcessId = getParentProcessId(parentProcessId);
				parentParentProcess = Process.GetProcessById(parentParentProcessId);

				stream.WriteLine(parentParentProcessId);
				stream.WriteLine(parentParentProcess.ProcessName);
				stream.WriteLine(getProcessCommandLine(parentParentProcessId));

				parentParentProcessId = getParentProcessId(parentParentProcessId);
				parentParentProcess = Process.GetProcessById(parentParentProcessId);
				stream.WriteLine(parentParentProcessId);
				stream.WriteLine(parentParentProcess.ProcessName);
			}
			*/
		
			return "Not implemented for linux environment";
		}

		private string getProcessCommandLine(int processId)
		{
			using (var cmdLine = File.OpenText("/proc/" + processId + "/cmdline"))
			{
				return cmdLine.ReadToEnd();
			}
		}

		/// <summary>
		/// Gets the parent process identifier for process with specified <paramref name="processId"/>
		/// </summary>
		/// <returns>
		/// The parent process identifier. 
		/// -1 if process status file in /proc/<paramref name="processId"/>/status not exist. 
		/// -2 if process status file in /proc/<paramref name="processId"/>/status has wrong structure.
		/// </returns>
		/// <param name='processId'>
		/// Process identifier.
		/// </param>
		private int getParentProcessId(int processId)
		{
			if (processId == 0)
			{
				return 0;
			}

			string processStatusFile = "/proc/" + processId + "/status";

			// process with specified id not exists.
			if (!File.Exists(processStatusFile))
			{
				return -1;
			}
			
			using (var procInfo = File.OpenText(processStatusFile))
			{
				var file = procInfo.ReadToEnd();
				Regex reg = new Regex(@".*PPid:\t(\d*).*");
				var match = reg.Match(file);
				int parentProcessId;
				if (match.Success 
				    && match.Groups.Count == 2 
				    && int.TryParse(match.Groups[1].Value, out parentProcessId))
				{
					return parentProcessId;
				}
				else
				{
					// process status file has wrong structure.
					return -2;
				}				
			}
		}
	}
}

