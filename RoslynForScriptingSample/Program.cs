using Microsoft.CodeAnalysis.Scripting;
using System;

namespace RoslynForScriptingSample
{
	class Program
	{
		static void Main( string[] args )
		{
			try {
				Sample.SetParameterAsync().Wait();
			}
			catch( CompilationErrorException ex ) {
				Console.WriteLine( "[Script Error]" );
				Console.WriteLine( ex.Message );
			}
			catch( Exception ex) {
				Console.WriteLine( ex );
			}

			Console.ReadKey();
		}
	}
}
