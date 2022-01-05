#pragma once

namespace tws::client::platui {
	class Window {
	public:
		Window( int w, int h );
		Window( int x, int y, int w, int h );
		~Window();

		bool Show();
		bool ShowFullscreen();
		bool Hide();

		const long GetHandle() const;
	protected:
	};
}