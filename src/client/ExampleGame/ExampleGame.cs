using System.Threading.Tasks;

using Serilog;

using Silk.NET.Windowing;

using tws.game.client.State;

namespace ExampleGame;
internal class ExampleGame : tws.game.client.GameClient<ExampleGame> {
	public ExampleGame( ILogger _logger ) : base( _logger, new State.GameState() ) { }

	public override async Task Init( string[] args ) {
		await base.Init( args );
	}

	public override async Task<int> Run() {
		if( gameState != null ) {
			gameState.Window.Run( () => { await base.Frame(); } );
		}

		return 0;
	}
}
