using System;
using System.Text;
namespace OpenZWave
{
	public class ValueId
	{
		internal static readonly NativeMap<Notification> NativeToManagedMap = new NativeMap<Notification>();

		private IntPtr handle;

		internal ValueId(IntPtr ptr)
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


		public uint HomeId => NativeMethods.value_id_get_home_id(handle);

		public byte NodeId => NativeMethods.value_id_get_node_id(handle);

		public ValueGenre Genre => NativeMethods.value_id_get_genre_type(handle);

		public byte CommandClassId => NativeMethods.notification_get_group_index(handle);

		public byte Instance => NativeMethods.notification_get_group_index(handle);

		public byte Index => NativeMethods.notification_get_group_index(handle);

		public ZWValueType Type => NativeMethods.value_id_get_value_type(handle);

		public ulong Id => NativeMethods.value_id_get_id(handle);


		public override string ToString()
		{
			var len = NativeMethods.notification_get_as_string(handle, null);
			var builder = new StringBuilder(len);
			NativeMethods.notification_get_as_string(handle, builder);
			return builder.ToString();
		}
	}
}
