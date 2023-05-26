using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Silk.NET.Input;

namespace tws.game.client.Input;
public interface IInputSystem {
	IReadOnlyList<IKeyboard> Keyboards { get; }
	IKeyboard? PrimaryKeyboard { get { return Keyboards[0] ?? null; } }
	IReadOnlyList<IMouse> Mice { get; }
	IMouse? PrimaryMouse { get { return Mice[0] ?? null; } }
	IReadOnlyList<IGamepad> Gamepads { get; }
	IGamepad? PrimaryGamepad { get { return Gamepads[0] ?? null; } }
	IReadOnlyList<IInputDevice> OtherDevices { get; }
}
