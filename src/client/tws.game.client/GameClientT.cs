using System;
using System.Linq;
using System.Threading.Tasks;

using Serilog;

using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

using tws.game.client.Input;
using tws.game.client.Renderer;
using tws.game.client.State;
using tws.game.Extensions;

namespace tws.game.client;
public abstract class GameClient<T> : GameClient where T : GameClient {
	private static T? instance = null;

	protected GameClient( ILogger _logger ) : base( _logger ) {}

	public static T Instance {
		get {
			if (instance == null)
				throw new NullReferenceException("Can not retrieve the GameClient.Instance until one has already been instaniated.");

			return instance;
		}
	}
}
