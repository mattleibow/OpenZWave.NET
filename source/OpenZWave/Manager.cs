using System;
using System.Linq;
using System.Text;

using WatchersMap = System.Collections.Concurrent.ConcurrentDictionary<(OpenZWave.OnNotificationDelegate, object), OpenZWave.NativeMethods.on_ontification_delegate_t>;

namespace OpenZWave
{
	public delegate void OnNotificationDelegate(Notification notification, object context);

	public class Manager
	{
		internal static readonly NativeMap<Manager> NativeToManagedMap = new NativeMap<Manager>();

		private IntPtr handle;
		private readonly WatchersMap watchers = new WatchersMap();

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
			var instance = Instance;
			if (instance != null)
				return instance;

			var manager = NativeToManagedMap.GetOrCreate(NativeMethods.manager_create());

			// add the watcher for the events
			manager.AddWatcher(manager.OnNotificationFromUnmanaged, null);

			return manager;
		}

		public static Manager Instance => NativeToManagedMap.GetOrCreate(NativeMethods.manager_get());

		public static void Destroy()
		{
			var instance = Instance;
			if (instance != null)
			{
				// remove the watcher that we added
				instance.RemoveWatcher(instance.OnNotificationFromUnmanaged, null);
			}

			NativeMethods.manager_destroy();
		}

		public static string VersionString => GetStringHelper(NativeMethods.manager_get_version_as_string);

		public static string VersionLongString => GetStringHelper(NativeMethods.manager_get_version_long_as_string);

		private static string GetStringHelper(Func<StringBuilder, int> func)
		{
			var sb = new StringBuilder();
			var length = func(sb);
			return sb.ToString(0, length);
		}


		//-----------------------------------------------------------------------------
		// Configuration
		//-----------------------------------------------------------------------------

		public Options Options => Options.NativeToManagedMap.GetOrCreate(NativeMethods.manager_get_options(handle));

		public void WriteConfig(uint homeId) => NativeMethods.manager_write_config(handle, homeId);


		//-----------------------------------------------------------------------------
		//	Notifications
		//-----------------------------------------------------------------------------

		public bool AddWatcher(OnNotificationDelegate watcher, object context = null)
		{
			if (watchers.TryGetValue((watcher, context), out var del))
				return false;

			del = new NativeMethods.on_ontification_delegate_t((notificationPtr, ctx) =>
			{
				var notification = Notification.NativeToManagedMap.GetOrCreate(notificationPtr);
				watcher?.Invoke(notification, context);
			});

			var added = NativeMethods.manager_add_watcher(handle, del, IntPtr.Zero);

			if (added)
				watchers.AddOrUpdate((watcher, context), del, (k, v) => del);

			return added;
		}

		public bool RemoveWatcher(OnNotificationDelegate watcher, object context = null)
		{
			if (!watchers.TryRemove((watcher, context), out var del))
				return false;

			return NativeMethods.manager_remove_watcher(handle, del, IntPtr.Zero);
		}

		public event EventHandler<NotificationReceivedEventArgs> NotificationReceived;

		private void OnNotificationFromUnmanaged(Notification notification, object context)
		{
			NotificationReceived?.Invoke(this, new NotificationReceivedEventArgs(notification));
		}


		//-----------------------------------------------------------------------------
		//	Drivers
		//-----------------------------------------------------------------------------

		public bool AddDriver(string controllerPath, Driver.ControllerInterface controllerInterface = Driver.ControllerInterface.Serial) => NativeMethods.manager_add_driver(handle, controllerPath, controllerInterface);

		public bool RemoveDriver(string controllerPath) => NativeMethods.manager_remove_driver(handle, controllerPath);

		public byte GetControllerNodeId(uint homeId) => NativeMethods.manager_get_controller_node_id(handle, homeId);

		public byte GetStaticUpdateControllerNodeId(uint homeId) => NativeMethods.manager_get_static_update_controller_node_id(handle, homeId);

		public bool IsPrimaryController(uint homeId) => NativeMethods.manager_is_primary_controller(handle, homeId);

		public bool IsStaticUpdateController(uint homeId) => NativeMethods.manager_is_static_update_controller(handle, homeId);

		public bool IsBridgeController(uint homeId) => NativeMethods.manager_is_bridge_controller(handle, homeId);

		public string GetLibraryVersion(uint homeId) => GetStringHelper(homeId, NativeMethods.manager_get_library_version);

		public string GetLibraryTypeName(uint homeId) => GetStringHelper(homeId, NativeMethods.manager_get_library_type_name);

		public int GetSendQueueCount(uint homeId) => NativeMethods.manager_get_send_queue_count(handle, homeId);

		public void LogDriverStatistics(uint homeId) => NativeMethods.manager_log_driver_statistics(handle, homeId);

		public Driver.ControllerInterface GetControllerInterfaceType(uint homeId) => NativeMethods.manager_get_controller_interface_type(handle, homeId);

		public string GetControllerPath(uint homeId) => GetStringHelper(homeId, NativeMethods.manager_get_controller_path);

		private string GetStringHelper(uint homeId, Func<IntPtr, uint, StringBuilder, int> func)
		{
			var sb = new StringBuilder();
			var length = func(handle, homeId, sb);
			return sb.ToString(0, length);
		}


		//-----------------------------------------------------------------------------
		//	Polling Z-Wave devices
		//-----------------------------------------------------------------------------	

		public int PollInterval => NativeMethods.manager_get_poll_interval(handle);

		/// <summary>
		/// Set the time period between polls of a node's state.
		/// </summary>
		/// <remarks>
		/// Due to patent concerns, some devices do not report state changes automatically to the controller.
		/// These devices need to have their state polled at regular intervals.  The length of the interval
		/// is the same for all devices.  To even out the Z-Wave network traffic generated by polling, OpenZWave
		/// divides the polling interval by the number of devices that have polling enabled, and polls each
		/// in turn.  It is recommended that if possible, the interval should not be set shorter than the
		/// number of polled devices in seconds (so that the network does not have to cope with more than one poll per second).
		/// </remarks>
		/// <param name="milliseconds"> Milliseconds The length of the polling interval in seconds..</param>
		/// <param name="intervalBetweenPolls">If set to <c>true</c>Interval between polls.</param>
		public void SetPollInterval(int milliseconds, bool intervalBetweenPolls) => NativeMethods.manager_set_poll_interval(handle, milliseconds, intervalBetweenPolls);

		public bool EnablePoll(ValueId valueId, byte intensity = 1) => NativeMethods.manager_enable_poll(handle, valueId.handle, intensity);

		public bool DisablePoll(ValueId valueId) => NativeMethods.manager_disable_poll(handle, valueId.handle);

		public bool IsPolled(ValueId valueId) => NativeMethods.manager_is_polled(handle, valueId.handle);

		public void SetPollIntensity(ValueId valueId, byte intensity) => NativeMethods.manager_set_poll_intensity(handle, valueId.handle, intensity);

		public byte GetPollIntensity(ValueId valueId) => NativeMethods.manager_get_poll_intensity(handle, valueId.handle);


		//-----------------------------------------------------------------------------
		//	Node information
		//-----------------------------------------------------------------------------

		public bool RefreshNodeInfo(uint homeId, byte nodeId) => NativeMethods.manager_refresh_node_info(handle, homeId, nodeId);

		public bool RequestNodeState(uint homeId, byte nodeId) => NativeMethods.manager_request_node_state(handle, homeId, nodeId);

		public bool IsNodeListeningDevice(uint homeId, byte nodeId) => NativeMethods.manager_is_node_listening_device(handle, homeId, nodeId);

		public bool RequestNodeDynamic(uint homeId, byte nodeId) => NativeMethods.manager_request_node_dynamic(handle, homeId, nodeId);

		public bool IsFrequentListenindDevice(uint homeId, byte nodeId) => NativeMethods.manager_is_node_frequent_listening_device(handle, homeId, nodeId);

		public bool IsNodeBeamingDevice(uint homeId, byte nodeId) => NativeMethods.manager_is_node_beaming_device(handle, homeId, nodeId);

		public bool IsNodeRoutingDevice(uint homeId, byte nodeId) => NativeMethods.manager_is_node_routing_device(handle, homeId, nodeId);

		public bool IsNodeSecurityDevice(uint homeId, byte nodeId) => NativeMethods.manager_is_node_security_device(handle, homeId, nodeId);

		public uint GetNodeMaxBaudRate(uint homeId, byte nodeId) => NativeMethods.manager_get_node_max_baud_rate(handle, homeId, nodeId);

		public byte GetNodeVersion(uint homeId, byte nodeId) => NativeMethods.manager_get_node_version(handle, homeId, nodeId);

		public byte GetNodeSecurity(uint homeId, byte nodeId) => NativeMethods.manager_get_node_security(handle, homeId, nodeId);

		public bool IsNodeZWavePlus(uint homeId, byte nodeId) => NativeMethods.manager_is_node_zwave_plus(handle, homeId, nodeId);

		public byte GetNodeBasic(uint homeId, byte nodeId) => NativeMethods.manager_get_node_basic(handle, homeId, nodeId);

		public byte GetNodeGeneric(uint homeId, byte nodeId) => NativeMethods.manager_get_node_generic(handle, homeId, nodeId);

		public byte GetNodeSpecific(uint homeId, byte nodeId) => NativeMethods.manager_get_node_specific(handle, homeId, nodeId);

		public string GetNodeType(uint homeId, byte nodeId) => GetNodeStringHelper(homeId, nodeId, NativeMethods.manager_get_node_type);

		public byte[] GetNodeNeighbors(uint homeId, byte nodeId)
		{
			NativeMethods.manager_get_node_neighbors(handle, homeId, nodeId, out var neighbors, out var num);
			return neighbors;
		}

		public string GetNodeManufacturerName(uint homeId, byte nodeId) => GetNodeStringHelper(homeId, nodeId, NativeMethods.manager_get_node_manufacturer_name);

		public string GetNodeProductName(uint homeId, byte nodeId) => GetNodeStringHelper(homeId, nodeId, NativeMethods.manager_get_node_product_name);

		public string GetNodeName(uint homeId, byte nodeId) => GetNodeStringHelper(homeId, nodeId, NativeMethods.manager_get_node_name);

		public string GetNodeLocation(uint homeId, byte nodeId) => GetNodeStringHelper(homeId, nodeId, NativeMethods.manager_get_node_location);

		public string GetNodeManufacturerId(uint homeId, byte nodeId) => GetNodeStringHelper(homeId, nodeId, NativeMethods.manager_get_node_manufacturer_id);

		public string GetNodeProductType(uint homeId, byte nodeId) => GetNodeStringHelper(homeId, nodeId, NativeMethods.manager_get_node_product_type);

		public string GetNodeProductId(uint homeId, byte nodeId) => GetNodeStringHelper(homeId, nodeId, NativeMethods.manager_get_node_product_id);

		private string GetNodeStringHelper(uint homeId, byte nodeId, Func<IntPtr, uint, byte, StringBuilder, int> func)
		{
			var sb = new StringBuilder();
			var length = func(handle, homeId, nodeId, sb);
			return sb.ToString(0, length);
		}

		public void SetNodeManufacturerName(uint homeId, byte nodeId, string name) => NativeMethods.manager_set_node_manufacturer_name(handle, homeId, nodeId, name);

		public void SetNodeName(uint homeId, byte nodeId, string name) => NativeMethods.manager_set_node_name(handle, homeId, nodeId, name);

		public void SetNodeLocation(uint homeId, byte nodeId, string name) => NativeMethods.manager_set_node_location(handle, homeId, nodeId, name);

		public void SetNodeOn(uint homeId, byte nodeId) => NativeMethods.manager_set_node_on(handle, homeId, nodeId);

		public void SetNodeOff(uint homeId, byte nodeId) => NativeMethods.manager_set_node_off(handle, homeId, nodeId);

		public void SetNodeLevel(uint homeId, byte nodeId, byte level) => NativeMethods.manager_set_node_level(handle, homeId, nodeId, level);


		//-----------------------------------------------------------------------------
		// Values
		//-----------------------------------------------------------------------------

		public string GetValueLabel(ValueId valueId) => GetValueIdStringHelper(valueId, NativeMethods.manager_get_node_value_label);

		public void SetValueLabel(ValueId valueId, string value) => NativeMethods.manager_set_node_value_label(handle, valueId.handle, value);

		public string GetValueUnits(ValueId valueId) => GetValueIdStringHelper(valueId, NativeMethods.manager_get_node_value_units);

		public void SetValueUnits(ValueId valueId, string value) => NativeMethods.manager_set_node_value_units(handle, valueId.handle, value);

		public string GetValueHelp(ValueId valueId) => GetValueIdStringHelper(valueId, NativeMethods.manager_get_node_value_help);

		private string GetValueIdStringHelper(ValueId valueId, Func<IntPtr, IntPtr, StringBuilder, int> func)
		{
			var sb = new StringBuilder();
			var length = func(handle, valueId.handle, sb);
			return sb.ToString(0, length);
		}

		public void SetValueHelp(ValueId valueId, string value) => NativeMethods.manager_set_node_value_help(handle, valueId.handle, value);

		public uint GetValueMin(ValueId valueId) => NativeMethods.manager_get_value_min(handle, valueId.handle);

		public uint GetValueMax(ValueId valueId) => NativeMethods.manager_get_value_max(handle, valueId.handle);

		public bool IsValueReadOnly(ValueId valueId) => NativeMethods.manager_is_value_read_only(handle, valueId.handle);

		public bool IsValueWriteOnly(ValueId valueId) => NativeMethods.manager_is_value_write_only(handle, valueId.handle);

		public bool IsValueSet(ValueId valueId) => NativeMethods.manager_is_value_set(handle, valueId.handle);

		public bool IsValuePolled(ValueId valueId) => NativeMethods.manager_is_value_polled(handle, valueId.handle);

		public bool GetValueAsBool(ValueId valueId, out bool value) => NativeMethods.manager_get_value_as_bool(handle, valueId.handle, out value);

		public bool GetValueAsByte(ValueId valueId, out byte value) => NativeMethods.manager_get_value_as_byte(handle, valueId.handle, out value);

		public bool GetValueAsFloat(ValueId valueId, out float value) => NativeMethods.manager_get_value_as_float(handle, valueId.handle, out value);

		public bool GetValueAsInt(ValueId valueId, out int value) => NativeMethods.manager_get_value_as_int(handle, valueId.handle, out value);

		public bool GetValueAsShort(ValueId valueId, out short value) => NativeMethods.manager_get_value_as_short(handle, valueId.handle, out value);

		public bool GetValueAsString(ValueId valueId, out string value)
		{
			var sb = new StringBuilder();
			var success = NativeMethods.manager_get_node_value_string(handle, valueId.handle, sb, out int length);
			value = sb.ToString(0, length);
			return success;
		}

		public bool GetValueListSelection(ValueId valueId, out string value)
		{
			var sb = new StringBuilder();
			var success = NativeMethods.manager_get_node_value_list_selection(handle, valueId.handle, sb, out int length);
			value = sb.ToString(0, length);
			return success;
		}


		//-----------------------------------------------------------------------------
		// Climate Control Schedules
		//-----------------------------------------------------------------------------


		//-----------------------------------------------------------------------------
		// SwitchAll
		//-----------------------------------------------------------------------------


		//-----------------------------------------------------------------------------
		// Configuration Parameters
		//-----------------------------------------------------------------------------

		public void RequestConfigParam(uint homeId, byte nodeId, byte param) => NativeMethods.manager_request_config_params(handle, homeId, nodeId, param);

		public void RequestAllConfigParams(uint homeId, byte nodeId) => NativeMethods.manager_request_all_config_params(handle, homeId, nodeId);


		//-----------------------------------------------------------------------------
		// Groups (wrappers for the Node methods)
		//-----------------------------------------------------------------------------


		//-----------------------------------------------------------------------------
		// Controller commands
		//-----------------------------------------------------------------------------

		public void ResetController(uint homeId) => NativeMethods.manager_reset_controller(handle, homeId);

		public void SoftReset(uint homeId) => NativeMethods.manager_soft_reset(handle, homeId);


		//-----------------------------------------------------------------------------
		// Network commands
		//-----------------------------------------------------------------------------

		public bool AddNode(uint homeId, bool doSecurity = true) => NativeMethods.manager_add_node(handle, homeId, doSecurity);

		public bool RemoveNode(uint homeId) => NativeMethods.manager_remove_node(handle, homeId);

		public bool RemoveFailedNode(uint homeId, byte nodeId) => NativeMethods.manager_remove_failed_node(handle, homeId, nodeId);

		public bool HasNodeFailed(uint homeId, byte nodeId) => NativeMethods.manager_has_node_failed(handle, homeId, nodeId);

		public bool CreateNewPrimary(uint homeId) => NativeMethods.manager_create_new_primary(handle, homeId);

		public bool ReceiveConfiguration(uint homeId) => NativeMethods.manager_revieve_configuration(handle, homeId);

		public bool TransferPrimaryRole(uint homeId) => NativeMethods.manager_transfer_primary_role(handle, homeId);


		//-----------------------------------------------------------------------------
		// Scene commands
		//-----------------------------------------------------------------------------


		//-----------------------------------------------------------------------------
		// Statistics interface
		//-----------------------------------------------------------------------------
	}
}
