using System;
using System.Net;
using System.Threading.Tasks;

namespace tws.game.lib.net;

public interface IPacketSender {
	Task<bool> Send( Memory<byte> p, IPEndPoint ep );
}
