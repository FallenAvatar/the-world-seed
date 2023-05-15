using System;
using System.Collections.Concurrent;

namespace tws.game.lib.net.Packets;
public static class ViewFactory {
	private static ConcurrentDictionary<Type, IPacketView> _instances = new();
	public static void Init() {
		// TODO: Get appropriate interfaces
		var types = new Type[0];
		foreach( var t in types )
			AddPacketView( t );
	}

	private static void AddPacketView( Type t ) {
		// TODO: Runtime generation of BasePacketView subclasses that implement user defined Intefaces
	}

	public static T Get<T>() where T : IPacketView {
		return (T)Get( typeof( T ) );
	}

	public static IPacketView Get( Type t ) {
		return _instances[t];
	}
}
