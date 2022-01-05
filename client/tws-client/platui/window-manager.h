#pragma once

#include "./window.h"
#include <map>

namespace tws::client::platui {
	class WindowManager {
	public:
		WindowManager() {}
		~WindowManager() {
			for( auto w = _windows.begin(); w != _windows.end(); ++w )
				delete w->second;
			
			_windows.clear();
		}

		Window* Create(int x, int y, int w, int h) {
			auto win = new Window( x, y, w, h );

			_windows.insert( { win->GetHandle(), win } );

			return win;
		}

		bool StillRunning() {
			return false;
		}

		void MessageLoop() {

		}

	protected:
		std::map<long, Window*> _windows;
	};

	WindowManager g_winMgr;
}