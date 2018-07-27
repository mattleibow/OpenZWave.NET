using System;

namespace OpenZWave
{
	[AttributeUsage(AttributeTargets.Method)]
	internal sealed class MonoPInvokeCallbackAttribute : Attribute
	{
		public MonoPInvokeCallbackAttribute(Type type)
		{
			Type = type;
		}

		public Type Type { get; private set; }
	}
}
