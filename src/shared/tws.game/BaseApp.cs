using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Serilog;

namespace tws.game;
public class BaseApp : IBaseApp {
	public ILogger Log { get; init; }

	protected BaseApp(ILogger _logger) { Log = _logger; }
	public void Dispose() { DisposeAsync().GetAwaiter().GetResult(); }
	public async ValueTask DisposeAsync() { await DisposeAsyncCore().ConfigureAwait( false ); GC.SuppressFinalize( this ); }
	protected virtual async ValueTask DisposeAsyncCore() { await Task.CompletedTask; }

	public async virtual Task Init( string[] args ) { await Task.CompletedTask; }

	public async virtual Task Quit(bool fromException = false) { await Task.CompletedTask; }

	public async virtual Task Load() {
		await Task.CompletedTask;
	}
	public async virtual Task<int> Run() {
		await Task.CompletedTask;

		return 0;
	}

	public void ExceptionCatchall( Exception? ex ) {
		Log.Error( ex, "tws.game.BaseApp.ExceptionCatchall" );

		Quit( true ).GetAwaiter().GetResult();
	}
}
