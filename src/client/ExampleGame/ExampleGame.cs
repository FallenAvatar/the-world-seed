using System.Threading.Tasks;

using Serilog;

using tws.game.client.State;

namespace ExampleGame;
internal class ExampleGame : tws.game.client.GameClient<ExampleGame> {
	public ExampleGame( ILogger _logger ) : base( _logger, new State.GameState() ) { }

	public override async Task Init( string[] args ) {
		
	}

	public override async Task<int> Run() {
		

		return 0;
	}
}
