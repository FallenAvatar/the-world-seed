#pragma once
#include <cstdint>
#include <iostream>

#include "common.h"

namespace engine {
	class console {
	public:
		static bool RedirectConsoleIO();
		static bool ReleaseConsole();
		static void AdjustConsoleBuffer( int16_t minLength );
		static bool CreateNewConsole( int16_t minLength );
	};
}