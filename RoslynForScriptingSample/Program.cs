using System;

namespace RoslynForScriptingSample
{
	class Program
	{
		static void Main( string[] args )
		{
			AsyncUtility.ExceptionHandleAsync( Sample.SetParameterAsync ).Wait();
			Console.ReadKey();
		}
	}
}
