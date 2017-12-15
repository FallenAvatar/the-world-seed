#ifndef __TWS_NETWORKING_API_H__
#define __TWS_NETWORKING_API_H__

#include "common.h"

namespace TWS {
	namespace Networking {
// This class is exported from the tws-networking.dll
		class TWSNETWORKING_API API {
		public:
			API();
		};

		extern TWSNETWORKING_API int example_var;

		TWSNETWORKING_API int example_function( void );
	}
}

#endif // __TWS_NETWORKING_API_H__