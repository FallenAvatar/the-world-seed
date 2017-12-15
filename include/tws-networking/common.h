

#ifndef __COMMON_H__
#define __COMMON_H__

#if !defined(PLATFORM_WINDOWS)
#define PLATFORM_WINDOWS 0
#endif

#if !defined(PLATFORM_MAC)
#define PLATFORM_MAC 0
#endif

#if !defined(PLATFORM_LINUX)
#define PLATFORM_LINUX 0
#endif

#if !PLATFORM_WINDOWS && !PLATFORM_MAC && !PLATFORM_LINUX
#if _WIN32
#undef PLATFORM_WINDOWS
#define PLATFORM_WINDOWS 1
#include "./win32/common.h"
#elif __APPLE__
#undef PLATFORM_MAC
#define PLATFORM_MAC 1
#elif __linux__
#undef PLATFORM_LINUX
#define PLATFORM_LINUX 1
#else
#error Unknown Platform
#endif
#endif

#endif // __COMMON_H__