using System;

namespace OpenZWave
{
	public class ValueId : IDisposable
	{
		internal static readonly NativeMap<ValueId> NativeToManagedMap = new NativeMap<ValueId>();

		internal IntPtr handle;
		private bool ownsHandle;

		public ValueId(uint homeId, byte nodeId, ValueGenre genre, byte commandClass, byte instance, byte index, ZWValueType type)
			: this(NativeMethods.value_id_create(homeId, nodeId, genre, commandClass, instance, index, type))
		{
			ownsHandle = true;
		}

		internal ValueId(IntPtr ptr)
		{
			handle = ptr;
		}

		public void Dispose()
		{
			if (ownsHandle)
				NativeMethods.value_id_delete(handle);
			Dispose(true);
		}

		public virtual void Dispose(bool disposing)
		{
			NativeToManagedMap.Dispose(ref handle);
		}


		public uint HomeId => NativeMethods.value_id_get_home_id(handle);

		public byte NodeId => NativeMethods.value_id_get_node_id(handle);

		public ValueGenre Genre => NativeMethods.value_id_get_genre_type(handle);

		public byte CommandClassId => NativeMethods.value_id_get_command_class_id(handle);

		public byte Instance => NativeMethods.value_id_get_instance(handle);

		public byte Index => NativeMethods.value_id_get_value_index(handle);

		public ZWValueType Type => NativeMethods.value_id_get_value_type(handle);

		public ulong Id => NativeMethods.value_id_get_id(handle);
	}
}
