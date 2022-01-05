

#include <tws-core/common.h>
#include <tws-client/common.h>

int CALLBACK WinMain( HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow ) {
	UNREFERENCED_PARAMETER( hPrevInstance );
	UNREFERENCED_PARAMETER( lpCmdLine );

	tws::core::platform::windows::WinPlatInfo::Create( hInstance );

#ifdef _DEBUG
	if( !tws::core::Console::CreateNewConsole( 1024 ) )
		return 1;
#endif // _DEBUG

	while( tws::client::platui::g_winMgr.StillRunning() )
		tws::client::platui::g_winMgr.MessageLoop();

	return 0;
}