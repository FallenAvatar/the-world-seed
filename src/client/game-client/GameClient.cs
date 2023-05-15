using System;
using System.Threading.Tasks;

using tws.game.client.Renderer;

namespace tws.game.client;
public class GameClient : BaseApp, IDisposable {
	private IRenderer? renderer = null;
	public bool Running { get; private set; } = true;

	public GameClient() {
	}

	public void Dispose() {
		if( renderer != null ) { renderer.Dispose(); renderer = null; }
	}

	public async Task Run( string[] args) {
		while( Running ) {
			// TODO: Update

			if( renderer != null )
				await renderer.Render();
		}
	}

	public void Quit() { Running = false; }
}
