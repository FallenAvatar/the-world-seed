using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tws.game.Extensions;

namespace tws.game.client.State;
public abstract class BasePhysicsState : BaseGameState {
	protected double accum = 0.0;

	protected BasePhysicsState( GameClient game ) : base( game ) {}

	public override async Task<IGameState> Update( double delta ) {
		double frameTime = delta;
		IGameState ret = this;

		accum += frameTime;

		while( accum >= PhysicsFrameTime ) {
			ret = await DoUpdate( PhysicsFrameTime );
			accum -= PhysicsFrameTime;
		}

		return ret;
	}

	protected abstract Task<IGameState> DoUpdate( double dt );
}
