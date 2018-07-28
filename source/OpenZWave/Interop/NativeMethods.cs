using System;
using System.Runtime.InteropServices;
using System.Text;

using options_t = System.IntPtr;
using manager_t = System.IntPtr;
using notification_t = System.IntPtr;
using valueId_t = System.IntPtr;

namespace OpenZWave
{
	internal static class NativeMethods
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
		public extern static bool options_get_option_as_string(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, StringBuilder valueOut, out uint lengthOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static Options.OptionType options_get_option_type(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_are_locked(options_t o);


		// Notification

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static NotificationType notification_get_type(notification_t n);

		//[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		//public extern static NotificationCode notification_get_code(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static uint notification_get_home_id(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte notification_get_node_id(notification_t n);

		// TODO: GetValueID

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte notification_get_group_index(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte notification_get_event(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte notification_get_button_id(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte notification_get_scene_id(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte notification_get_notification(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte notification_get_byte(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int notification_get_as_string(notification_t n, StringBuilder strOut);



		//ValueID

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static uint value_id_get_home_id(valueId_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte value_id_get_node_id(valueId_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static ValueGenre value_id_get_genre_type(valueId_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte value_id_get_command_class_id(valueId_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte value_id_get_instance(valueId_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte value_id_get_value_index(valueId_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static ZWValueType value_id_get_value_type(valueId_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static ulong value_id_get_id(valueId_t n);



		// Manager

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static manager_t manager_create();

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static manager_t manager_get();

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_destroy();

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_version_as_string(StringBuilder versionOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_version_long_as_string(StringBuilder versionOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_write_config(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static options_t manager_get_options(manager_t m);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_add_watcher(manager_t m, IntPtr watcher, IntPtr context);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_remove_watcher(manager_t m, IntPtr watcher, IntPtr context);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_add_driver(manager_t m, [MarshalAs(UnmanagedType.LPStr)] string controllerPath, Driver.ControllerInterface controllerInterface);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_remove_driver(manager_t m, [MarshalAs(UnmanagedType.LPStr)] string controllerPath);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte manager_get_controller_node_id(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte manager_get_static_update_controller_node_id(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_primary_controller(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_static_update_controller(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_bridge_controller(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_library_version(manager_t m, uint homeId, StringBuilder versionOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_library_type_name(manager_t m, uint homeId, StringBuilder versionOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_send_queue_count(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_log_driver_statistics(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static Driver.ControllerInterface manager_get_controller_interface_type(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_controller_path(manager_t m, uint homeId, StringBuilder pathOut);
	}
}
