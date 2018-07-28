using System;
using Xunit;

namespace OpenZWave.Tests
{
	public class ManagerTests : IDisposable
	{
		void IDisposable.Dispose()
		{
			Manager.Destroy();
			Options.Destroy();
		}

		[Fact]
		public void TestCreateInstanceDestroy()
		{
			Options.Initialize("config/", "", "");
			Options.Instance.Lock();

			var manager = Manager.Initialize();
			Assert.NotNull(manager);

			var instance = Manager.Instance;
			Assert.NotNull(instance);

			Assert.Equal(manager, instance);

			Manager.Destroy();

			Assert.Null(Manager.Instance);

			Options.Destroy();
		}

		[Fact]
		public void TestGetOptions()
		{
			Options.Initialize("config/", "", "");
			Options.Instance.Lock();

			var manager = Manager.Initialize();

			Assert.NotNull(manager.Options);

			Manager.Destroy();
			Options.Destroy();
		}

		[Theory]
		[InlineData((object)null)]
		[InlineData(1)]
		[InlineData("text")]
		[InlineData(1.4)]
		public void TestAddRemoveWatcher(object ctx)
		{
			Options.Initialize("config/", "", "");
			Options.Instance.Lock();

			var manager = Manager.Initialize();

			Assert.True(manager.AddWatcher(watcher, ctx));
			Assert.False(manager.AddWatcher(watcher, ctx));

			Assert.True(manager.RemoveWatcher(watcher, ctx));
			Assert.False(manager.RemoveWatcher(watcher, ctx));

			Manager.Destroy();
			Options.Destroy();

			void watcher(Notification notification, object context)
			{
			}
		}

		[Fact]
		public void TestAddRemoveSerialDriver()
		{
			Options.Initialize("config/", "", "");
			Options.Instance.Lock();

			var manager = Manager.Initialize();

			manager.AddDriver(Helpers.GetControllerPath());

			Manager.Destroy();
			Options.Destroy();
		}

		[Fact]
		public void TestAddRemoveHidDriver()
		{
			Options.Initialize("config/", "", "");
			Options.Instance.Lock();

			var manager = Manager.Initialize();

			manager.AddDriver("HID Controller", Driver.ControllerInterface.Hid);

			Manager.Destroy();
			Options.Destroy();
		}

		[Fact]
		public void TestVersion()
		{
			Assert.NotNull(Manager.VersionString);

			Assert.Contains("1.4", Manager.VersionString);
		}

		[Fact]
		public void TestVersionLong()
		{
			Assert.NotNull(Manager.VersionLongString);

			Assert.Contains("1.4", Manager.VersionLongString);
		}
	}
}
