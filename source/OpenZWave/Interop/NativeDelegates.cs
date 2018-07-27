using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using notification_t = System.IntPtr;

namespace OpenZWave
{
	internal static class NativeDelegates
	{
		private static readonly IDictionary<Type, IntPtr> delegates;

		[UnmanagedFunctionPointer(CallingConvention.Cdecl)]
		private delegate void on_ontification_delegate_t(notification_t notification, IntPtr context);

		// so the GC doesn't collect the delegate
		private static readonly on_ontification_delegate_t onNotificationDelegate;

		static NativeDelegates()
		{
			onNotificationDelegate = new on_ontification_delegate_t(OnNotificationInternal);

			delegates = new Dictionary<Type, IntPtr>
			{
				{ typeof(OnNotificationDelegate), Marshal.GetFunctionPointerForDelegate(onNotificationDelegate) },
			};
		}

		public static IntPtr GetPointer<T>()
		{
			return delegates[typeof(T)];
		}

		[MonoPInvokeCallback(typeof(on_ontification_delegate_t))]
		private static void OnNotificationInternal(notification_t notification, IntPtr context)
		{
			var ctx = NativeDelegateContext.Unwrap(context);
			ctx.GetDelegate<OnNotificationDelegate>()(Notification.NativeToManagedMap.GetOrCreate(notification), ctx.ManagedContext);
		}
	}
}
