OutputMessage( $"API Version:{GetVersion()}" );

OutputMessage( $"Timer Setting:{IsSettingTimer()}" );
OutputMessage( $"Current Timer:{GetCurrentTimer()}" );

SetTimer( 2, 10 );

OutputMessage( "[Set timer]" );
OutputMessage( $"Timer Setting:{IsSettingTimer()}" );
OutputMessage( $"Current Timer:{GetCurrentTimer()}" );

