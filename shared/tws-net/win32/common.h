#pragma once

#define VC_EXTRALEAN
#define WIN32_LEAN_AND_MEAN

#include <WinSDKVer.h>
#define _WIN32_WINNT NTDDI_WINXPSP3
#include <SDKDDKVer.h>
#include <windows.h>

#ifdef TWSNETWORKING_EXPORTS
#define TWSNETWORKING_API __declspec(dllexport)
#else
#define TWSNETWORKING_API __declspec(dllimport)
#endif