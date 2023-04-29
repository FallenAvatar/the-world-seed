using System;

namespace tws.game.lib.net;

public class ExistsPrefixAttribute : Attribute {
	public Type ExistsType;
	public object TrueValue;

	public ExistsPrefixAttribute( Type t, object trueVal ) {
		ExistsType = t;
		TrueValue = trueVal;
	}
}
