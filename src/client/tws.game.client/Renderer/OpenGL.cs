using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Silk.NET.SDL;
using tws.game.client.State;

namespace tws.game.client.Renderer;
public class OpenGL : BaseRenderer {
	public OpenGL() { }

	protected override async ValueTask DisposeAsyncCore() { await base.DisposeAsyncCore(); }

	public override async Task Init() { await Task.CompletedTask; }
	public override async Task Render() { await Task.CompletedTask; }
}
