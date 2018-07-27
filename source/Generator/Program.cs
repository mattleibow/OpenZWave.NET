using CppSharp;

namespace Generator
{
	static class Program
	{
		public static void Main(string[] args)
		{
			ConsoleDriver.Run(new OpenZWave { RootPath = args.Length > 0 ? args[0] : string.Empty });
		}
	}
}