using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace OpenZWave
{
	public enum OptionType
	{
		Invalid = 0,
		Bool,
		Int,
		String
	}

	public class Options
	{
		internal static readonly ConcurrentDictionary<IntPtr, Options> NativeToManagedMap = new ConcurrentDictionary<IntPtr, Options>();

		private IntPtr handle;

		internal Options(IntPtr ptr)
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

		public static Options Instance => NativeToManagedMap.GetOrCreate(NativeMethods.options_get());

		public static Options Initialize(string configPath, string userPath, string commandLine)
		{
			return NativeToManagedMap.GetOrCreate(NativeMethods.options_create(configPath, userPath, commandLine));
		}

		public static bool Destroy()
		{
			return NativeMethods.options_destroy();
		}

		public bool AreLocked => NativeMethods.options_are_locked(handle);

		public bool Lock()
		{
			return NativeMethods.options_lock(handle);
		}

		public bool AddOption(string name, bool value)
		{
			return NativeMethods.options_add_option_bool(handle, name, value);
		}

		public bool AddOption(string name, int value)
		{
			return NativeMethods.options_add_option_int(handle, name, value);
		}

		public bool AddOption(string name, string value, bool append)
		{
			return NativeMethods.options_add_option_string(handle, name, value, append);
		}

		public bool GetOption(string name, out bool value)
		{
			return NativeMethods.options_get_option_as_bool(handle, name, out value);
		}

		public bool GetOption(string name, out int value)
		{
			return NativeMethods.options_get_option_as_int(handle, name, out value);
		}

		public bool GetOption(string name, out string value)
		{
			if (NativeMethods.options_get_option_as_string(handle, name, IntPtr.Zero, out var len))
			{
				var builder = new StringBuilder((int)len);
				NativeMethods.options_get_option_as_string(handle, name, builder, IntPtr.Zero);
				value = builder.ToString();
				return true;
			}

			value = null;
			return false;
		}

		public OptionType GetOptionType(string name)
		{
			return NativeMethods.options_get_option_type(handle, name);
		}
	}

	internal static class NativeManager
	{
		public static T GetOrCreate<T>(this ConcurrentDictionary<IntPtr, T> map, IntPtr ptr)
			where T : class
		{
			if (ptr == IntPtr.Zero)
				return null;

			if (map.TryGetValue(ptr, out var value))
				return value;

			var obj = (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { ptr }, null);
			map[ptr] = obj;
			return obj;
		}

		public static void Dispose<T>(this ConcurrentDictionary<IntPtr, T> map, ref IntPtr ptr)
			where T : class
		{
			if (ptr != IntPtr.Zero)
				map.TryRemove(ptr, out var dummy);
			ptr = IntPtr.Zero;
		}
	}
}
