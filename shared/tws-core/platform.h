#pragma once

// COMPILER_MSVC, COMPILER_LLVM, COMPILER_GCC, COMPILER_CLANG
#if !defined(COMPILER_MSVC)
	#define COMPILER_MSVC 0
#endif

#if !defined(COMPILER_LLVM)
	#define COMPILER_LLVM 0
#endif

#if !defined(COMPILER_GCC)
	#define COMPILER_GCC 0
#endif

#if !defined(COMPILER_CLANG)
	#define COMPILER_CLANG 0
#endif

#if !COMPILER_MSVC && !COMPILER_LLVM && !COMPILER_GCC && !COMPILER_CLANG
	#if _MSC_VER
		#undef COMPILER_MSVC
		#define COMPILER_MSVC 1
	#elif __llvm__
		#undef COMPILER_LLVM
		#define COMPILER_LLVM 1
	#elif __clang__
		#undef COMPILER_CLANG
		#define COMPILER_CLANG 1
	#elif __GNUC__
		#undef COMPILER_GCC
		#define COMPILER_GCC 1
	#endif
#endif

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
	#elif __APPLE__
		#undef PLATFORM_MAC
		#define PLATFORM_MAC 1
	#elif __linux__
		#undef PLATFORM_LINUX
		#define PLATFORM_LINUX 1
	#endif
#endif

#if COMPILER_MSVC
	#include "./platform/compiler/msvc.h"
#elif COMPILER_LLVM
	#include "./platform/compiler/llvm.h"
#elif COMPILER_GCC
	#include "./platform/compiler/clang.h"
#elif COMPILER_CLANG
	#include "./platform/compiler/gcc.h"
#else
	#error "Unrecognized Compiler"
#endif

#if PLATFORM_WINDOWS
	#include "./platform/os/windows.h"
#elif PLATFORM_MAC
	#include "./platform/os/mac.h"
#elif PLATFORM_LINUX
	#include "./platform/os/linux.h";
#else
	#error Unknown Platform
#endif