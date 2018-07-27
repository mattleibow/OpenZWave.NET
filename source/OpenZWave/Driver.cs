using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenZWave
{
	public class Driver
	{
		public enum ControllerInterface
		{
			Unknown = 0,
			Serial,
			Hid
		}

		internal static readonly NativeMap<Manager> NativeToManagedMap = new NativeMap<Manager>();

		private IntPtr handle;

		internal Driver(IntPtr ptr)
		{
			handle = ptr;
		}

		public void Dispose()
		{
			Dispose(true);
		}

		public virtual void Dispose(bool disposing)
		{
			NativeToManagedMap.Dispose(ref handle);
		}
	}
}
