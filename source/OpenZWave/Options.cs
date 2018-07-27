﻿using System;
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
			if (NativeMethods.options_get_option_as_string(handle, name, null, out var len))
			{
				var builder = new StringBuilder((int)len);
				NativeMethods.options_get_option_as_string(handle, name, builder, out len);
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
}
