using System;

namespace RoslynForScriptingSample
{
	class Program
	{
		static void Main( string[] args )
		{
			AsyncUtility.ExceptionHandleAsync( Sample.HookAsync ).Wait();
			Console.ReadKey();
		}
	}
}
