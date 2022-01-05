#ifndef __TWS_CORE_PLATFORM_WINDOWS_WINPLATINFO_H__
#define __TWS_CORE_PLATFORM_WINDOWS_WINPLATINFO_H__
#pragma once

#include "../../platinfo.h"

namespace tws::core::platform::windows {
	class WinPlatInfo : public tws::core::platform::PlatInfo {
	private:
		HINSTANCE hInst;

	public:
		static void Create( HINSTANCE hInstance ) {
			tws::core::platform::g_PlatInfo = new tws::core::platform::windows::WinPlatInfo( hInstance );
		}

		Property<HINSTANCE> hInstance { hInst };

		WinPlatInfo( HINSTANCE hInstance ) : PlatInfo() {
			hInst = hInstance;
		};
	};
}

#endif // __TWS_CORE_PLATFORM_WINDOWS_WINPLATINFO_H__