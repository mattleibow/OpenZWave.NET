using System;
using System.Runtime.InteropServices;
using System.Text;

using options_t = System.IntPtr;
using manager_t = System.IntPtr;
using notification_t = System.IntPtr;
using value_id_t = System.IntPtr;

namespace OpenZWave
{
	internal static class NativeMethods
	{
		private const string LibraryName = "openzwave_c";


		//==============================================================================
		// DELEGATES
		//==============================================================================

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		public delegate void on_ontification_delegate_t(notification_t notification, IntPtr context);


		//==============================================================================
		// OPTIONS
		//==============================================================================

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
		public extern static bool options_get_option_as_string(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name, StringBuilder valueOut, out int lengthOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static Options.OptionType options_get_option_type(options_t o, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool options_are_locked(options_t o);


		//==============================================================================
		// NOTIFICATION
		//==============================================================================

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static NotificationType notification_get_type(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static uint notification_get_home_id(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte notification_get_node_id(notification_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static value_id_t notification_get_value_id(notification_t n);

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


		//==============================================================================
		// VALUEID
		//==============================================================================

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static value_id_t value_id_create(uint homeId, byte nodeId, ValueGenre genre, byte commandClass, byte instance, byte index, ZWValueType type);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static value_id_t value_id_delete(value_id_t handle);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static uint value_id_get_home_id(value_id_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte value_id_get_node_id(value_id_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static ValueGenre value_id_get_genre_type(value_id_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte value_id_get_command_class_id(value_id_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte value_id_get_instance(value_id_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte value_id_get_value_index(value_id_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static ZWValueType value_id_get_value_type(value_id_t n);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static ulong value_id_get_id(value_id_t n);


		//==============================================================================
		// MANAGER
		//==============================================================================

		//-----------------------------------------------------------------------------
		// Construction

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

		//-----------------------------------------------------------------------------
		// Configuration

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_write_config(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static options_t manager_get_options(manager_t m);

		//-----------------------------------------------------------------------------
		//	Drivers

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

		//-----------------------------------------------------------------------------
		//	Polling Z-Wave devices

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_poll_interval(manager_t m);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_poll_interval(manager_t m, int miliseconds, bool intervalBetweenPools);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static bool manager_enable_poll(manager_t m, value_id_t v, byte intensity = 1);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static bool manager_disable_poll(manager_t m, value_id_t v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static bool manager_is_polled(manager_t m, value_id_t v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_poll_intensity(manager_t m, value_id_t v, byte intensity);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte manager_get_poll_intensity(manager_t m, value_id_t v);

		//-----------------------------------------------------------------------------
		//	Node information

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_refresh_node_info(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_request_node_state(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_node_listening_device(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_request_node_dynamic(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_node_frequent_listening_device(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_node_beaming_device(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_node_routing_device(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_node_security_device(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static uint manager_get_node_max_baud_rate(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte manager_get_node_version(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte manager_get_node_security(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_node_zwave_plus(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte manager_get_node_basic(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte manager_get_node_generic(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static byte manager_get_node_specific(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_type(manager_t m, uint homeId, byte nodeId, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_get_node_neighbors(manager_t m, uint homeId, byte nodeId, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 4)] out byte[] neighbors, out uint num);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_manufacturer_name(manager_t m, uint homeId, byte nodeId, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_product_name(manager_t m, uint homeId, byte nodeId, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_name(manager_t m, uint homeId, byte nodeId, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_location(manager_t m, uint homeId, byte nodeId, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_manufacturer_id(manager_t m, uint homeId, byte nodeId, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_product_type(manager_t m, uint homeId, byte nodeId, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_product_id(manager_t m, uint homeId, byte nodeId, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_manufacturer_name(manager_t m, uint homeId, byte nodeId, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_name(manager_t m, uint homeId, byte nodeId, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_location(manager_t m, uint homeId, byte nodeId, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_on(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_off(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_level(manager_t m, uint homeId, byte nodeId, byte level);

		//-----------------------------------------------------------------------------
		// Values

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_value_label(manager_t m, value_id_t v, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_value_label(manager_t m, value_id_t v, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_value_units(manager_t m, value_id_t v, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_value_units(manager_t m, value_id_t v, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static int manager_get_node_value_help(manager_t m, value_id_t v, StringBuilder sbOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_set_node_value_help(manager_t m, value_id_t v, [MarshalAs(UnmanagedType.LPStr)] string name);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static uint manager_get_value_min(manager_t m, value_id_t v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static uint manager_get_value_max(manager_t m, value_id_t v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_value_read_only(manager_t m, value_id_t v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_value_write_only(manager_t m, value_id_t v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static bool manager_is_value_set(manager_t m, value_id_t v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_is_value_polled(manager_t m, value_id_t v);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_get_value_as_bool(options_t o, value_id_t v, [MarshalAs(UnmanagedType.I1)] out bool valueOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_get_value_as_byte(options_t o, value_id_t v, out byte valueOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_get_value_as_float(options_t o, value_id_t v, out float valueOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_get_value_as_short(options_t o, value_id_t v, out Int16 valueOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_get_value_as_int(options_t o, value_id_t v, out int valueOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_get_node_value_string(options_t o, value_id_t v, StringBuilder valueOut, out int lengthOut);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_get_node_value_list_selection(options_t o, value_id_t v, StringBuilder valueOut, out int lengthOut);

		//-----------------------------------------------------------------------------
		// Climate Control Schedules

		//-----------------------------------------------------------------------------
		// SwitchAll

		//-----------------------------------------------------------------------------
		// Configuration Parameters

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_request_config_params(manager_t m, uint homeId, byte nodeId, byte param);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_request_all_config_params(manager_t m, uint homeId, byte nodeId);

		//-----------------------------------------------------------------------------
		// Groups (wrappers for the Node methods)

		//-----------------------------------------------------------------------------
		//	Notifications

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_add_watcher(manager_t m, on_ontification_delegate_t watcher, IntPtr context);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_remove_watcher(manager_t m, on_ontification_delegate_t watcher, IntPtr context);

		//-----------------------------------------------------------------------------
		// Controller commands

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_reset_controller(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		public extern static void manager_soft_reset(manager_t m, uint homeId);

		//-----------------------------------------------------------------------------
		// Network commands

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_add_node(manager_t m, uint homeId, bool doSecurity = true);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_remove_node(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_remove_failed_node(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_has_node_failed(manager_t m, uint homeId, byte nodeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_create_new_primary(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_revieve_configuration(manager_t m, uint homeId);

		[DllImport(LibraryName, CallingConvention = CallingConvention.Cdecl)]
		[return: MarshalAs(UnmanagedType.I1)]
		public extern static bool manager_transfer_primary_role(manager_t m, uint homeId);

		//-----------------------------------------------------------------------------
		// Scene commands

		//-----------------------------------------------------------------------------
		// Statistics interface
	}
}
