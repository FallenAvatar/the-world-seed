using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Silk.NET.Windowing;

using tws.game.client.Renderer;

namespace tws.game.client.State;
public interface IGameState : IDisposable, IAsyncDisposable {
	public IView Window { get; }
	public Task<IGameState> Update( double dt );
	public Task<IGameState> Render( IRenderer renderer );
}
