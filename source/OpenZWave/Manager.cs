﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

using WatchersMap = System.Collections.Generic.Dictionary<(OpenZWave.OnNotificationDelegate, object), OpenZWave.NativeDelegateContext>;

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

		public void WriteConfig(uint homeId)
		{
			NativeMethods.manager_write_config(handle, homeId);
		}


		//-----------------------------------------------------------------------------
		//	Notifications
		//-----------------------------------------------------------------------------

		// Keep these private for now as we are using the event.
		private bool AddWatcher(OnNotificationDelegate watcher, object context)
		{
			var ctx = new NativeDelegateContext(context, watcher);
			watchers.Add((watcher, context), ctx);

			return NativeMethods.manager_add_watcher(handle, NativeDelegates.GetPointer<OnNotificationDelegate>(), ctx.NativeContext);
		}

		// Keep these private for now as we are using the event.
		private bool RemoveWatcher(OnNotificationDelegate watcher, object context)
		{
			if (!watchers.TryGetValue((watcher, context), out var ctx))
				return false;

			return NativeMethods.manager_remove_watcher(handle, NativeDelegates.GetPointer<OnNotificationDelegate>(), ctx.NativeContext);
		}

		public event EventHandler<NotificationReceivedEventArgs> NotificationReceived;

		private void OnNotificationFromUnmanaged(Notification notification, object context)
		{
			NotificationReceived?.Invoke(this, new NotificationReceivedEventArgs(notification));
		}
	}
}
