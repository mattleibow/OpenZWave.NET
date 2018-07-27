using System;
using System.Collections.Concurrent;

namespace OpenZWave
{
	internal class NativeMap<T> : ConcurrentDictionary<IntPtr, T>
	{
	}
}
