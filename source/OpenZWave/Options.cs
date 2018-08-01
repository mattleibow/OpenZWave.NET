using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Text;

namespace OpenZWave
{
	public class Options
	{
		public enum OptionType
		{
			Invalid = 0,
			Bool,
			Int,
			String
		}

		internal static readonly NativeMap<Options> NativeToManagedMap = new NativeMap<Options>();

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

		public static Options Initialize(string configPath, string userPath, string commandLine) =>
			NativeToManagedMap.GetOrCreate(NativeMethods.options_create(configPath, userPath, commandLine));

		public static bool Destroy() => NativeMethods.options_destroy();

		public bool AreLocked => NativeMethods.options_are_locked(handle);

		public bool Lock() => NativeMethods.options_lock(handle);

		public bool AddOption(string name, bool value) => NativeMethods.options_add_option_bool(handle, name, value);

		public bool AddOption(string name, int value) => NativeMethods.options_add_option_int(handle, name, value);

		public bool AddOption(string name, string value, bool append) => NativeMethods.options_add_option_string(handle, name, value, append);

		public bool GetOption(string name, out bool value) => NativeMethods.options_get_option_as_bool(handle, name, out value);

		public bool GetOption(string name, out int value) => NativeMethods.options_get_option_as_int(handle, name, out value);

		public bool GetOption(string name, out string value)
		{
			var builder = new StringBuilder();
			var result = NativeMethods.options_get_option_as_string(handle, name, builder, out var len);
			value = builder.ToString(0, len);
			return result;
		}

		public OptionType GetOptionType(string name) => NativeMethods.options_get_option_type(handle, name);
	}
}
