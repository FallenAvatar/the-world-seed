using System;
using System.Collections.Concurrent;

namespace tws.game.lib.net.Packets;
public enum BitEndianess {
	Unknown = 0,
	LittleEndian,
	LittleBigEndian,
	BigLittleEndian,
	BigEndian,
}

public class BasePacketView : IPacketView {
	public BitEndianess Endianess { get; protected set; }

	protected ConcurrentDictionary<string, object> fields = new();

	public BasePacketView( BitEndianess e ) {
		Endianess = e;

		if( Endianess == BitEndianess.LittleBigEndian || Endianess == BitEndianess.BigLittleEndian )
			throw new NotImplementedException( "LittleBigEndian and BigLittleEndian NYI" );
	}

	protected void SetupFields() {
	}

	public T? Get<T>( Memory<byte> data, string name ) {
		return default;
	}

	public T? Get<T>( Memory<byte> data, int offset, int length = -1 ) {
		return default;
	}
}