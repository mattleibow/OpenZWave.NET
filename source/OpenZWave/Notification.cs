using System;

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
	}

	public class NotificationReceivedEventArgs : EventArgs
	{
		public NotificationReceivedEventArgs(Notification notification)
		{
			Notification = notification;
		}

		private Notification Notification { get; }
	}
}
