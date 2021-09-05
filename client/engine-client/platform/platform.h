#ifndef __PLATFORM_H__
#define __PLATFORM_H__

// COMPILER_MSVC, COMPILER_LLVM, COMPILER_GCC

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
#include "./msvc/msvc.h"
#elif __llvm__
#undef COMPILER_LLVM
#define COMPILER_LLVM 1
#include "./llvm/llvm.h"
#include <x86intrin.h>
#elif __clang__
#undef COMPILER_CLANG
#define COMPILER_CLANG 1
#include "./clang/clang.h"
#elif __GNUC__
#undef COMPILER_GCC
#define COMPILER_GCC 1
#include "./gcc/gcc.h"
#include <intrin.h>
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
#include "./windows/windows.h"
#elif __APPLE__
#undef PLATFORM_MAC
#define PLATFORM_MAC 1
#include "./mac/mac.h"
#elif __linux__
#undef PLATFORM_LINUX
#define PLATFORM_LINUX 1
#include "./linux/linux.h";
#else
#error Unknown Platform
#endif
#endif

#endif // __PLATFORM_H__
