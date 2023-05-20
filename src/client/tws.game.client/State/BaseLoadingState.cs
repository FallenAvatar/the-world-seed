using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tws.game.client.State;
public abstract class BaseLoadingState : BaseGameState {

	public BaseLoadingState() { PhysicsUpdatesPerSecond = 10.0; }

	protected override async ValueTask DisposeAsyncCore() { await base.DisposeAsyncCore(); }
}
