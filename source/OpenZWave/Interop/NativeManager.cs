using System;
using System.Reflection;

namespace OpenZWave
{
	internal static class NativeManager
	{
		public static T GetOrCreate<T>(this NativeMap<T> map, IntPtr ptr)
			where T : class
		{
			if (ptr == IntPtr.Zero)
				return null;

			if (map.TryGetValue(ptr, out var value))
				return value;

			var obj = (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { ptr }, null);
			map[ptr] = obj;
			return obj;
		}

		public static void Dispose<T>(this NativeMap<T> map, ref IntPtr ptr)
			where T : class
		{
			if (ptr != IntPtr.Zero)
				map.TryRemove(ptr, out var dummy);
			ptr = IntPtr.Zero;
		}
	}
}
