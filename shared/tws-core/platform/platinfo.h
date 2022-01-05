#ifndef __TWS_CORE_PLATFORM_PLATINFO_H__
#define __TWS_CORE_PLATFORM_PLATINFO_H__
#pragma once

#include <tws-core/common.h>

namespace tws::core::platform {
	class PlatInfo {
	protected:
		PlatInfo() {};
	};

	PlatInfo* g_PlatInfo;
}

#endif // __TWS_CORE_PLATFORM_PLATINFO_H__