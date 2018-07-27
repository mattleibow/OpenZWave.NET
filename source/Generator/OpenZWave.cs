using System.IO;
using System.Linq;
using CppSharp;
using CppSharp.AST;

namespace Generator
{
	class OpenZWave : ILibrary
	{
		public string RootPath { get; set; }

		public void Setup(Driver driver)
		{
			if (string.IsNullOrEmpty(RootPath))
				RootPath = ".";
			RootPath = Path.GetFullPath(RootPath);

			var options = driver.Options;
			//options.Verbose = true;
			options.OutputDir = "OpenZWave_CppSharp";
			//options.GenerateDefaultValuesForArguments = true;

			var module = options.AddModule("openzwave-1.4");
			module.IncludeDirs.Add(Path.Combine(RootPath, "cpp/src"));
			module.Headers.AddRange(Directory.GetFiles(Path.Combine(RootPath, "cpp/src"), "*.h"));

			//module.Headers.AddRange(Directory.GetFiles(Path.Combine(RootPath, "cpp/src/platform"), "*.h"));
			//module.Headers.AddRange(Directory.GetFiles(Path.Combine(RootPath, "cpp/src/value_classes"), "*.h"));

			module.OutputNamespace = "";

			var parserOptions = driver.ParserOptions;
			parserOptions.AddIncludeDirs(Path.Combine(RootPath, "cpp/hidapi"));
			parserOptions.AddIncludeDirs(Path.Combine(RootPath, "cpp/src"));
			parserOptions.AddIncludeDirs(Path.Combine(RootPath, "cpp/tinyxml"));
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
			foreach (var header in Directory.GetFiles(Path.Combine(RootPath, "cpp/src/platform"), "*.h"))
			{
				if (exceptions.Contains(Path.GetFileName(header)))
					continue;
				ctx.IgnoreHeadersWithName(header);
			}
			foreach (var header in Directory.GetFiles(Path.Combine(RootPath, "cpp/src/value_classes"), "*.h"))
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
