using Microsoft.CodeAnalysis.Scripting;
using Microsoft.CodeAnalysis.CSharp.Scripting;
using System.IO;
using System.Threading.Tasks;

namespace RoslynForScriptingSample
{
	class Hook
	{
		private ScriptRunner<object> preHook = null;
		private ScriptRunner<object> postHook = null;

		public Hook()
		{
		}

		public void EntryPreHook( string scriptPath )
		{
			preHook = GetScriptDelegate( scriptPath );
		}

		public void EntryPostHook( string scriptPath )
		{
			postHook = GetScriptDelegate( scriptPath );
		}

		public async Task InvokePreHook()
		{
			await preHook().ConfigureAwait( false );
		}

		public async Task InvokePostHook()
		{
			await postHook().ConfigureAwait( false );
		}

		private ScriptRunner<object> GetScriptDelegate( string scriptPath )
		{
			var script = CSharpScript.Create( File.ReadAllText( scriptPath ) );
			return script.CreateDelegate();
		}
	}
}
