#pragma once

#define VC_EXTRALEAN
#define WIN32_LEAN_AND_MEAN

#include "targetver.h"
#include <WinDef.h>

#ifdef TWSNETWORKING_EXPORTS
#define TWSNETWORKING_API __declspec(dllexport)
#else
#define TWSNETWORKING_API __declspec(dllimport)
#endif