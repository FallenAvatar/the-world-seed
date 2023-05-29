using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Silk.NET.Windowing;

using tws.game.client.Renderer;

namespace tws.game.client.State;
public interface IGameState : IDisposable, IAsyncDisposable {
	Task Load();
	Task<IGameState> Update( double dt );
	Task<IGameState> Render( IRenderer renderer );
}
