using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Silk.NET.Input;

namespace tws.game.client.Input;
internal class SilkInputSystem : IInputSystem {
	private readonly IInputContext inputContext;
	public IReadOnlyList<IKeyboard> Keyboards { get { return inputContext.Keyboards; } }
	public IReadOnlyList<IMouse> Mice { get { return inputContext.Mice; } }
	public IReadOnlyList<IGamepad> Gamepads { get { return inputContext.Gamepads; } }
	public IReadOnlyList<IInputDevice> OtherDevices { get { return inputContext.OtherDevices; } }

	public SilkInputSystem(IInputContext _inputContext) {
		inputContext = _inputContext;
	}
}
