using System;
using Xunit;

namespace OpenZWave.Tests
{
	public class ValueIdTests
	{
		[Fact]
		public void TestCreateDestroy()
		{
			var valueid = new ValueId(1, 2, ValueGenre.System, 4, 5, 6, ZWValueType.Raw);
			valueid.Dispose();
		}

		[Fact]
		public void TestCheckProperties()
		{
			var valueid = new ValueId(1, 2, ValueGenre.System, 4, 5, 6, ZWValueType.Raw);

			Assert.Equal((uint)1, valueid.HomeId);
			Assert.Equal((byte)2, valueid.NodeId);
			Assert.Equal(ValueGenre.System, valueid.Genre);
			Assert.Equal((byte)4, valueid.CommandClassId);
			Assert.Equal((byte)5, valueid.Instance);
			Assert.Equal((byte)6, valueid.Index);
			Assert.Equal(ZWValueType.Raw, valueid.Type);
			Assert.True(valueid.Id > 0);

			valueid.Dispose();
		}
	}
}
