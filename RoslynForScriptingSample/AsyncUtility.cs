using Microsoft.CodeAnalysis.Scripting;
using System;
using System.Threading.Tasks;

namespace RoslynForScriptingSample
{
	static class AsyncUtility
	{
		public static async Task ExceptionHandleAsync( Func<Task> taskAsync )
		{
			try {
				await taskAsync();
			}
			catch( CompilationErrorException ex ) {
				Console.WriteLine( "[Script Error]" );
				Console.WriteLine( ex.Message );
			}
			catch( Exception ex) {
				Console.WriteLine( ex );
			}
		}
	}
}
