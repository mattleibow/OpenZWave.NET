using System;
using System.Text;

namespace OpenZWave
{
	public class Notification
	{
		internal static readonly NativeMap<Notification> NativeToManagedMap = new NativeMap<Notification>();

		private IntPtr handle;

		internal Notification(IntPtr ptr)
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

		public NotificationType Type => NativeMethods.notification_get_type(handle);

		//public NotificationCode Code => NativeMethods.notification_get_code(handle);

		public uint HomeId => NativeMethods.notification_get_home_id(handle);

		public byte NodeId => NativeMethods.notification_get_node_id(handle);

		// TODO: GetValueID

		public byte GroupIndex => NativeMethods.notification_get_group_index(handle);

		public byte Event => NativeMethods.notification_get_event(handle);

		public byte ButtonId => NativeMethods.notification_get_button_id(handle);

		public byte SceneId => NativeMethods.notification_get_scene_id(handle);

		public byte NotificationId => NativeMethods.notification_get_notification(handle);

		public byte Byte => NativeMethods.notification_get_byte(handle);

		public override string ToString()
		{
			var len = NativeMethods.notification_get_as_string(handle, null);
			var builder = new StringBuilder(len);
			NativeMethods.notification_get_as_string(handle, builder);
			return builder.ToString();
		}
	}

	public class NotificationReceivedEventArgs : EventArgs
	{
		public NotificationReceivedEventArgs(Notification notification)
		{
			Notification = notification;
		}

		public Notification Notification { get; }
	}
}
