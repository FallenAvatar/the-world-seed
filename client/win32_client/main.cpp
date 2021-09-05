

#include "tws-core/common.h"
#include "tws-client/common.h"
#include <iostream>
#include <conio.h>
#include <Eigen/Dense>

using Eigen::MatrixXd;

int CALLBACK WinMain( HINSTANCE hInstance, HINSTANCE hPrevInstance, LPSTR lpCmdLine, int nCmdShow ) {
	UNREFERENCED_PARAMETER( hPrevInstance );
	UNREFERENCED_PARAMETER( lpCmdLine );

	if( !tws::core::console::CreateNewConsole( 1024 ) )
		return 1;

	MatrixXd m( 2, 2 );
	m( 0, 0 ) = 3;
	m( 1, 0 ) = 2.5;
	m( 0, 1 ) = -1;
	m( 1, 1 ) = m( 1, 0 ) + m( 0, 1 );
	std::cout << m << std::endl << std::flush;

	std::cout << "Press any key to continue..." << std::flush;
	_getch();

	return 0;
}