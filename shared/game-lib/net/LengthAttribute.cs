using System;

namespace tws.game.lib.net;

public sealed class LengthAttribute : Attribute {
	public int Length { get; }

	public LengthAttribute( int len ) {
		Length = len;
	}
}
