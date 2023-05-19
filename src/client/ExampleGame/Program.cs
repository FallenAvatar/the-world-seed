using System;
using System.Threading.Tasks;

using Serilog;
using Serilog.Core;

namespace ExampleGame;

internal class Program {
	static async Task<int> Main( string[] args ) {
		using var logger = new LoggerConfiguration()
			.MinimumLevel.Debug()
			.WriteTo.Console()
			.WriteTo.File( "logs/app.log", rollingInterval: RollingInterval.Hour )
			.CreateLogger();

		logger.Information( "Logger created." );
		AppDomain.CurrentDomain.UnhandledException += ( o, e ) => { ExampleGame.Instance.ExceptionCatchall( e.ExceptionObject as Exception ); };

		using var game = new ExampleGame(logger);

		await game.Init( args );
		return await game.Run();
	}
}
