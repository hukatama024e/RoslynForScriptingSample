using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RoslynForScriptingSample
{
	static class Sample
	{
		public static async Task HelloScriptingAsync()
		{
			var script = CSharpScript.Create( File.ReadAllText( @"Script\hello.csx" ) );
			var scriptState = await script.RunAsync();
		}

		public static async Task SetUsingAsync()
		{
			var optionSetting = ScriptOptions.Default
				.AddReferences( typeof( object ).Assembly )						// for System, System.Collection.Generic
				.AddReferences( typeof( System.Linq.Enumerable ).Assembly )		// for System.Linq
				.AddImports( "System", "System.Collections.Generic", "System.Linq" );

			var script = CSharpScript.Create( File.ReadAllText( @"Script\setUsing.csx" ), optionSetting );
			var scriptState = await script.RunAsync();
		}

		public static async Task SetParameterAsync()
		{
			var script = CSharpScript.Create( File.ReadAllText( @"Script\setParam.csx" ), ScriptOptions.Default, typeof( AppInfo ) );
			var scriptState = await script.RunAsync( new AppInfo { Version = "0.2.0" } );

			var paramA = scriptState.GetVariable( "paramA" );
			var paramB = scriptState.GetVariable( "paramB" );

			Console.WriteLine( $"{paramA.Name}={paramA.Value}" );
			Console.WriteLine( $"{paramB.Name}={paramB.Value}" );
		}

		public static async Task HookAsync()
		{
			var preHookScript = CSharpScript.Create( File.ReadAllText( @"Script\preHook.csx" ) );
			var postHookScript = CSharpScript.Create( File.ReadAllText( @"Script\postHook.csx" ) );

			Func<Task> mainProcess = async () => await Task.Run( () => Console.WriteLine( "Main Process!!" ) );

			await preHookScript.RunAsync();
			await mainProcess();
			await postHookScript.RunAsync();
		}
	}
}
