using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System;
using System.IO;

namespace RoslynForScriptingSample
{
	static class Sample
	{
		public static async void HelloRoslynForScripting()
		{
			var script = CSharpScript.Create( File.ReadAllText( @"Script\hello.csx" ) );
			var scriptState = await script.RunAsync();
		}

		public static async void SetUsing()
		{
			var optionSetting = ScriptOptions.Default
				.AddReferences( typeof( object ).Assembly )						// for System, System.Collection.Generic
				.AddReferences( typeof( System.Linq.Enumerable ).Assembly )		// for System.Linq
				.AddImports( "System", "System.Collections.Generic", "System.Linq" );

			var script = CSharpScript.Create( File.ReadAllText( @"Script\setUsing.csx" ), optionSetting );
			var scriptState = await script.RunAsync();
		}

		public static async void SetParameter()
		{
			var script = CSharpScript.Create( File.ReadAllText( @"Script\setParam.csx" ) );
			var scriptState = await script.RunAsync();

			var paramA = scriptState.GetVariable( "paramA" );
			var paramB = scriptState.GetVariable( "paramB" );

			Console.WriteLine( $"{paramA.Name}={paramA.Value}" );
			Console.WriteLine( $"{paramB.Name}={paramB.Value}" );
		}
	}
}
