using System;
using Xunit;

namespace OpenZWave.Tests
{
	public class OptionsTests : IDisposable
	{
		void IDisposable.Dispose()
		{
			Options.Destroy();
		}

		[Fact]
		public void TestCreateInstanceDestroy()
		{
			var options = Options.Initialize("config/", "", "");
			Assert.NotNull(options);

			var instance = Options.Instance;
			Assert.NotNull(instance);

			Assert.Equal(options, instance);

			Assert.True(Options.Destroy());

			Assert.Null(Options.Instance);
		}

		[Theory]
		[InlineData("test", true)]
		[InlineData("test", false)]
		[InlineData("test with space", true)]
		[InlineData("test with space", false)]
		public void TestAddGetBool(string name, bool value)
		{
			Options.Initialize("config/", "", "");

			Assert.True(Options.Instance.AddOption(name, value));

			Assert.True(Options.Instance.GetOption(name, out bool outValue));
			Assert.Equal(value, outValue);

			Options.Destroy();
		}

		[Theory]
		[InlineData("test", "value", true)]
		[InlineData("test", "value", false)]
		[InlineData("test with space", "value with space", true)]
		[InlineData("test with space", "value with space", false)]
		public void TestAddGetString(string name, string value, bool append)
		{
			Options.Initialize("config/", "", "");

			Assert.True(Options.Instance.AddOption(name, value, append));

			Assert.True(Options.Instance.GetOption(name, out string outValue));
			Assert.Equal(value, outValue);

			Options.Destroy();
		}
	}
}
