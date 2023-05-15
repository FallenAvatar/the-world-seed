using System;
using System.Runtime.CompilerServices;

namespace tws.game.lib.net;

[AttributeUsage( AttributeTargets.Field, Inherited = true, AllowMultiple = false )]
public sealed class FieldAttribute : Attribute {
	private readonly int _order;
	public FieldAttribute( [CallerLineNumber] int order = 0 ) {
		_order = order;
	}

	public int Order { get { return _order; } }
}
