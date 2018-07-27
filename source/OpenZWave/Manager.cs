using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace OpenZWave
{
	public class Manager
	{
		internal static readonly ConcurrentDictionary<IntPtr, Manager> NativeToManagedMap = new ConcurrentDictionary<IntPtr, Manager>();

		private IntPtr handle;

		internal Manager(IntPtr ptr)
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


		//-----------------------------------------------------------------------------
		// Construction
		//-----------------------------------------------------------------------------

		public static Manager Initialize()
		{
			return NativeToManagedMap.GetOrCreate(NativeMethods.manager_create());
		}

		public static Manager Instance => NativeToManagedMap.GetOrCreate(NativeMethods.manager_get());

		public static void Destroy()
		{
			NativeMethods.manager_destroy();
		}

		public static string VersionString
		{
			get
			{
				var len = NativeMethods.manager_get_version_as_string(null);
				var builder = new StringBuilder(len);
				NativeMethods.manager_get_version_as_string(builder);
				return builder.ToString();
			}
		}

		public static string VersionLongString
		{
			get
			{
				var len = NativeMethods.manager_get_version_long_as_string(null);
				var builder = new StringBuilder(len);
				NativeMethods.manager_get_version_long_as_string(builder);
				return builder.ToString();
			}
		}


		//-----------------------------------------------------------------------------
		// Configuration
		//-----------------------------------------------------------------------------

		public Options Options => Options.NativeToManagedMap.GetOrCreate(NativeMethods.manager_get_options(handle));

		public void WriteConfic(uint homeId)
		{
			NativeMethods.manager_write_config(handle, homeId);
		}


		//-----------------------------------------------------------------------------
		//	Notifications
		//-----------------------------------------------------------------------------

	}
}
