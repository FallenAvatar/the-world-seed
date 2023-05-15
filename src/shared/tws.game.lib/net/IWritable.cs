using System;

namespace tws.game.lib.net;

public interface IWritable {
	Memory<byte> Write();
	Memory<byte> WriteBE();
}
