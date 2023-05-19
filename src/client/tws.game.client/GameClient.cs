using System;
using System.Threading.Tasks;

using Serilog;

using tws.game.client.Renderer;
using tws.game.client.State;
using tws.game.Extensions;

namespace tws.game.client;
public abstract class GameClient<T> : BaseApp where T : BaseApp {
	private static T? instance = null;
	public static T Instance {
		get {
			if (instance == null)
				throw new NullReferenceException("Can not retrieve the GameClientInstance until one has already been instaniated.");

			return instance;
		}
	}
	protected IRenderer? renderer = null;
	protected IGameState? gameState;

	public GameClient( ILogger _logger, IGameState loadingGameState ) : base( _logger ) {
		gameState = loadingGameState;
	}

	protected override async ValueTask DisposeAsyncCore() {
		if( renderer != null ) { await renderer.DisposeAsync(); renderer = null; }
		if( gameState != null ) { await gameState.DisposeAsync(); gameState = null; }
	}

	public override async Task<int> Run() {
		double startDT = DateTime.Now.UnixTimestamp();
		double lastDT = startDT;
		double currDT = lastDT;
		double delta;

		while( gameState != null ) {
			bool isNoGC = GC.TryStartNoGCRegion( 1, 1, true );

			lastDT = currDT;
			currDT = DateTime.Now.UnixTimestamp();
			delta = currDT - lastDT;

			gameState = await Frame(delta);

			if( isNoGC )
				GC.EndNoGCRegion();
			GC.Collect( 1, GCCollectionMode.Forced, true, false );
			GC.WaitForPendingFinalizers();
			GC.Collect();
		}

		return 0;
	}

	protected async ValueTask<IGameState?> Frame(double dt) {
		return await OnFrame(dt);
	}

	protected async ValueTask<IGameState?> OnFrame( double dt ) {
		if( gameState == null ) return null;

		var ret = await gameState.Update( dt );

		if( renderer != null )
			ret = await ret.Render( renderer );

		return ret;
	}
}
