#ifndef __PLATFORM_WINDOWS_H__
#define __PLATFORM_WINDOWS_H__

#define VC_EXTRALEAN
#define WIN32_LEAN_AND_MEAN

#include <WinSDKVer.h>
#define _WIN32_WINNT NTDDI_WINXPSP3
#include <SDKDDKVer.h>
#include <windows.h>

#include "console.h"

#endif // __PLATFORM_WINDOWS_H__
