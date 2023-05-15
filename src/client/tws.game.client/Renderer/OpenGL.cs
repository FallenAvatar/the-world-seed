using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws.game.client.Renderer;
public class OpenGL : IRenderer {
	public OpenGL() { }
	public void Dispose() { }

#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
	public async Task Init() { }
	public async Task Render() { }
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
}
