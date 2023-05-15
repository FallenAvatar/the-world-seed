using System;

namespace tws.game.lib.net;

public sealed class LengthPrefixedAttribute : Attribute {
	public Type LengthType;

	public LengthPrefixedAttribute( Type t ) {
		LengthType = t;
	}
}
