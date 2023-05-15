using System;

namespace tws.game.lib.net;

public sealed class PaddingAttribute : Attribute {
	public int Size { get; private set; }
	public PaddingAttribute( int size ) {
		Size = size;
	}
}
