using System;
using System.Runtime.InteropServices;

namespace OpenZWave.Tests
{
	public static class Helpers
	{
		public static string GetControllerPath()
		{
			string port;
			if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
				port = "/dev/cu.usbserial";
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
				port = "\\\\.\\COM6";
			else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
				port = "/dev/ttyUSB0";
			else
				throw new PlatformNotSupportedException();
			return port;
		}
	}
}
