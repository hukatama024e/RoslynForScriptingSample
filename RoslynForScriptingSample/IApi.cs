namespace RoslynForScriptingSample
{
	public interface IApi
	{
		string GetVersion();
		string GetCurrentTimer();
		bool IsSettingTimer();
		void OutputMessage( string message );
		void SetTimer( int hour, int minute );
	}
}
