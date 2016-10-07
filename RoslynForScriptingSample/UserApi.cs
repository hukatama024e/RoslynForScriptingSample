using System;

namespace RoslynForScriptingSample
{
	class UserApi : IApi
	{
		private readonly string version = "0.2.0";
		private int timerHour = 0;
		private int timerMinute = 0;

		public UserApi()
		{
		}

		public string GetVersion()
		{
			return version;
		}

		public string GetCurrentTimer()
		{
			return $"{timerHour}:{timerMinute}";
		}

		public bool IsSettingTimer()
		{
			return ( timerHour > 0 || timerMinute > 0 );
		}

		public void OutputMessage( string message )
		{
			Console.WriteLine( message );
		}

		public void SetTimer( int hour, int minute )
		{
			timerHour = hour;
			timerMinute = minute;
		}
	}
}
