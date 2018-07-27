using System;
using System.Runtime.InteropServices;
using System.Text;
using options_t = System.IntPtr;

namespace OpenZWave
{
	public static class NativeMethods
	{
		private const string LibraryName = "openzwave_c";

		// Options

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static options_t options_create([MarshalAs(UnmanagedType.LPStr)] string configPath, [MarshalAs(UnmanagedType.LPStr)] string userPath, [MarshalAs(UnmanagedType.LPStr)] string commandLine);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_destroy();

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static options_t options_get();

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_lock(options_t o);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_add_option_bool(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.I1)] bool value);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_add_option_int(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, int value);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_add_option_string(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.LPStr)] string value, [MarshalAs(UnmanagedType.I1)] bool append);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_get_option_as_bool(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, [MarshalAs(UnmanagedType.I1)] out bool valueOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_get_option_as_int(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, out int valueOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_get_option_as_string(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, StringBuilder valueOut, IntPtr lengthOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_get_option_as_string(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, IntPtr valueOutZero, out uint length);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static OptionType options_get_option_type(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_are_locked(options_t o);

		// 
	}
}
