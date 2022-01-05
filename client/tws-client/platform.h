#pragma once

#include <tws-core/platform.h>

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