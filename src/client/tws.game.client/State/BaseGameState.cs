using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tws.game.client.Renderer;

namespace tws.game.client.State;
public abstract class BaseGameState : IGameState {
	public virtual double PhysicsUpdatesPerSecond { get; init; } = 60.0;
	public double PhysicsFrameTime { get { return 1.0 / PhysicsUpdatesPerSecond; } }

	public BaseGameState() { }
	public void Dispose() { DisposeAsync().GetAwaiter().GetResult(); }
	public async ValueTask DisposeAsync() { await DisposeAsyncCore().ConfigureAwait( false ); GC.SuppressFinalize( this ); }
	protected virtual async ValueTask DisposeAsyncCore() { await Task.CompletedTask; }

	public abstract Task<IGameState> Render( IRenderer renderer );

	public abstract Task<IGameState> Update( double dt );
}
