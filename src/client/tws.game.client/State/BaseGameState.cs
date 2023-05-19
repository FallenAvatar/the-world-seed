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

	public async virtual Task<IGameState> Render( IRenderer renderer ) { await Task.CompletedTask; return this;  }

	public async virtual Task<IGameState> Update( double dt ) { await Task.Delay( (int)(500.0 / PhysicsUpdatesPerSecond) ); return this; } // 500 instead of 1000 to allow for render time
}
