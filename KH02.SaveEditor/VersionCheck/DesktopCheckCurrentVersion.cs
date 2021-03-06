﻿using System.Diagnostics;
using System.Reflection;
using Xe.VersionCheck;

namespace KH02.SaveEditor.VersionCheck
{
	public class DesktopCheckCurrentVersion : ICheckCurrentVersion
	{
		public string GetCurrentVersion()
		{
			var assembly = Assembly.GetExecutingAssembly();
			var fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

			return fvi.ProductVersion;
		}
	}
}
