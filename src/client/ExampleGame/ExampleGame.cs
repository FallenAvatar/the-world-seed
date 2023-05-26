using System.Threading.Tasks;

using Serilog;

using Silk.NET.Windowing;

using tws.game.client.State;

namespace ExampleGame;
internal class ExampleGame : tws.game.client.GameClient<ExampleGame> {
	public ExampleGame( ILogger _logger ) : base( _logger ) { }

	protected override IGameState GetDefaultGameState() { return new State.GameState( this ); }
}
