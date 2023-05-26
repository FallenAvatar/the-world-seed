using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws.game.client.State;
public abstract class BaseMenuState : BaseGameState {

	public BaseMenuState( GameClient game ) : base( game ) { PhysicsUpdatesPerSecond = 10.0; }
}
