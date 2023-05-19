using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws.game.client.Renderer;
public abstract class BaseRenderer : IRenderer {
	public void Dispose() { DisposeAsync().GetAwaiter().GetResult(); }
	public async ValueTask DisposeAsync() { await DisposeAsyncCore().ConfigureAwait( false ); GC.SuppressFinalize( this ); }
	protected virtual async ValueTask DisposeAsyncCore() { await Task.CompletedTask; }

	public abstract Task Init();
	public abstract Task Render();
}
