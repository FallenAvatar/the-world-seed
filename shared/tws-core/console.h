#ifndef __TWS_CORE_CONSOLE_H__
#define __TWS_CORE_CONSOLE_H__
#pragma once
#include <cstdint>
#include <iostream>

#include "common.h"

namespace tws::core {
	class Console {
	public:
		static bool RedirectConsoleIO();
		static bool ReleaseConsole();
		static void AdjustConsoleBuffer( int16_t minLength );
		static bool CreateNewConsole( int16_t minLength );
	};
}

#endif