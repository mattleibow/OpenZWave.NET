﻿using System;
using System.Threading.Tasks;

using OpenZWave;

namespace OpenZWaveApp
{
	public class Program
	{
		public static void Main(string[] args)
		{
			Task.Run(Start);

			Console.WriteLine($"type 'exit' to close");

			var command = "";
			while (command != "exit")
			{
				// TODO: Allow issuing CommandClass commands on nodes from the console input
				// TODO: Add "Associate node to controller" option
				// TODO: Add "Query node parameters" based on implemented classes
				command = Console.ReadLine();
			}

			Manager.Destroy();

			Console.WriteLine("\nGood Bye!\n");
		}

		private static async Task Start()
		{
			Console.WriteLine($"Starting OpenZWaveApp with OpenZWave Version {Manager.VersionString}");

			// Create the OpenZWave Manager.
			// The first argument is the path to the config files (where the manufacturer_specific.xml file is located
			// The second argument is the path for saved Z-Wave network state and the log file.  If you leave it NULL 
			// the log file will appear in the program's working directory.
			Options.Initialize("config/", "", "");
			Options.Instance.AddOption("SaveLogLevel", (int)LogLevel.Detail);
			Options.Instance.AddOption("QueueLogLevel", (int)LogLevel.Debug);
			Options.Instance.AddOption("DumpTrigger", (int)LogLevel.Error);
			Options.Instance.AddOption("PollInterval", 500);
			Options.Instance.AddOption("IntervalBetweenPolls", true);
			Options.Instance.AddOption("ValidateValueChanges", true);
			Options.Instance.Lock();

			Manager.Initialize();

			// Add a callback handler to the manager.  The second argument is a context that
			// is passed to the OnNotification method.  If the OnNotification is a method of
			// a class, the context would usually be a pointer to that class object, to
			// avoid the need for the notification handler to be a static.
			Manager.Instance.NotificationReceived += OnNotification;

			//// Add a Z-Wave Driver
			//// Modify this line to set the correct serial port for your PC interface.
			//string port;
			//if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
			//  port = "/dev/cu.usbserial";
			//else if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
			//  port = "\\\\.\\COM6";
			//else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
			//  port = "/dev/ttyUSB0";
			//else
			//  throw new PlatformNotSupportedException();

			string port = "/dev/cu.usbmodem1461";

			//if (args.Length > 0)
			//  port = args[0];
			//if (port.ToLower() == "usb")
			//    Manager.Instance.AddDriver("HID Controller", Driver.ControllerInterface.ControllerInterfaceHid);
			//else
			Manager.Instance.AddDriver(port);
		}

		private static void OnNotification(object sender, NotificationReceivedEventArgs e)
		{
			Console.WriteLine($"Recieved notification: {e.Notification}");
		}
	}
}