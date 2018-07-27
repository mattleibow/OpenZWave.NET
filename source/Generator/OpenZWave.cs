using System.IO;
using System.Linq;
using CppSharp;
using CppSharp.AST;

namespace Generator
{
	class OpenZWave : ILibrary
	{
		string root = "/Users/matthew/Projects/OpenZWave.NET/externals/open-zwave/";

		public void Setup(Driver driver)
		{
			var options = driver.Options;
			//options.Verbose = true;
			options.OutputDir = "OpenZWave_CppSharp";
			//options.GenerateDefaultValuesForArguments = true;

			var module = options.AddModule("openzwave-1.4");
			module.IncludeDirs.Add(root + "cpp/src");
			module.Headers.AddRange(Directory.GetFiles(root + "cpp/src", "*.h"));

			//module.Headers.AddRange(Directory.GetFiles(root + "cpp/src/platform", "*.h"));
			//module.Headers.AddRange(Directory.GetFiles(root + "cpp/src/value_classes", "*.h"));

			module.OutputNamespace = "";

			var parserOptions = driver.ParserOptions;
			parserOptions.AddIncludeDirs(root + "cpp/hidapi");
			parserOptions.AddIncludeDirs(root + "cpp/src");
			parserOptions.AddIncludeDirs(root + "cpp/tinyxml");
		}

		public void SetupPasses(Driver driver)
		{
		}

		public void Preprocess(Driver driver, ASTContext ctx)
		{
			ctx.IgnoreHeadersWithName("src/aes/*");
			ctx.IgnoreHeadersWithName("src/command_classes/*");
			ctx.IgnoreHeadersWithName("src/platform/unix/*");
			ctx.IgnoreHeadersWithName("src/platform/winRT/*");
			ctx.IgnoreHeadersWithName("src/platform/windows/*");

			var exceptions = new[]
			{
				"TimeStamp.h",
				"ValueID.h",
				"Log.h",
			};
			foreach (var header in Directory.GetFiles(root + "cpp/src/platform", "*.h"))
			{
				if (exceptions.Contains(Path.GetFileName(header)))
					continue;
				ctx.IgnoreHeadersWithName(header);
			}
			foreach (var header in Directory.GetFiles(root + "cpp/src/value_classes", "*.h"))
			{
				if (exceptions.Contains(Path.GetFileName(header)))
					continue;
				ctx.IgnoreClassWithName(Path.GetFileNameWithoutExtension(header));
			}

			// rename for C#
			ctx.FindCompleteClass("Notification").Methods.First(p => p.Name == "GetNotification").Name = "GetCode";
			ctx.FindCompleteClass("Msg").Methods.First(p => p.Name == "Finalize").Name = "FinalizeMessage";

			// undo properties
			ctx.IgnoreConversionToProperty("Options::Lock");

			// remove a broken generation
			ctx.TranslationUnits.First(t => t.FileName == "Log.h")
				.Namespaces.First()
				.Variables.First(v => v.Name == "LogLevelString")
				.ExplicitlyIgnore();
			ctx.IgnoreClassWithName("ozwversion");
			ctx.FindCompleteClass("Driver").FindClass("PollEntry").Access = AccessSpecifier.Internal;


			//ctx.IgnoreConversionToProperty("ValueList::GetItem");
			//ctx.IgnoreFunctionWithName("Value::GetPollIntensity");
			//ctx.IgnoreFunctionWithName("Value::SetPollIntensity");
		}

		public void Postprocess(Driver driver, ASTContext ctx)
		{
		}
	}
}
