using System;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

using Serilog;

using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;
using Silk.NET.Windowing;

using tws.game.client.Input;
using tws.game.client.Renderer;
using tws.game.client.State;
using tws.game.Extensions;

namespace tws.game.client;
public abstract class GameClient : BaseApp {
	public GL? GL { get; protected set; }
	public IInputSystem? Input { get; protected set; }
	protected IRenderer? renderer = null;
	protected IGameState? gameState;
	private TimeSpan currDelta = TimeSpan.Zero;
	private DateTime startDT = DateTime.MinValue;
	public IView? PlatformWindow { get; protected set; }
	private bool isClosing = false;

	public GameClient( ILogger _logger ) : base( _logger ) {
		startDT = DateTime.UtcNow;
	}

	protected override async ValueTask DisposeAsyncCore() {
		await base.DisposeAsyncCore();
		if( renderer != null ) { await renderer.DisposeAsync(); renderer = null; }
		if( gameState != null ) { await gameState.DisposeAsync(); gameState = null; }
	}

	protected abstract IGameState GetDefaultGameState();

	public override async Task<int> Run() {
		Log.Information( "GameClient.Run" );
		PlatformWindow = Window.Create( WindowOptions.Default with {
			Size = new Vector2D<int>( 800, 600 ),
			Title = "LearnOpenGL with Silk.NET",
			IsVisible = true,
		} );
		Log.Information( "Window Created." );

		PlatformWindow.Load += Load;
		PlatformWindow.Closing += Close;

		await Task.Run( () => {
			PlatformWindow.Initialize();
			Log.Information( "Window Initialized." );

			startDT = DateTime.Now;
			gameState = GetDefaultGameState();

			Log.Information( "Window Running." );

			PlatformWindow.Run( () => {
				if( isClosing ) {
					PlatformWindow.Close();
					return;
				}
				PlatformWindow.DoEvents();
				gameState = RunFrame().GetAwaiter().GetResult();
				Log.Information("PlatformWindow.Run: frame end");
			} );
		} );

		return 0;
	}

	public override async Task Load() {
		Log.Information("Window Loaded.");
		if( PlatformWindow == null ) throw new Exception("This should be impossible...");
		if( gameState != null ) { await gameState.Load(); }
		Input = new SilkInputSystem( PlatformWindow.CreateInput() );
		
		GL = GL.GetApi( PlatformWindow );
	}

	const double minFrameTime = (double)(1M / 75M);

	protected async ValueTask<IGameState?> RunFrame() {
		double frameStart = DateTime.Now.UnixTimestamp();
		bool isNoGC = GC.TryStartNoGCRegion( 1, 1, false );

		TimeSpan lastDelta = currDelta;
		currDelta = DateTime.Now - startDT;
		double delta = (currDelta - lastDelta).TotalSeconds;

		gameState = await OnFrame( delta );

		if( isNoGC )
			GC.EndNoGCRegion();
		GC.Collect( 1, GCCollectionMode.Forced, true, false );
		GC.WaitForPendingFinalizers();
		GC.Collect();

		double frameEnd = DateTime.Now.UnixTimestamp();
		double frameTime = frameEnd - frameStart;
		Log.Information( "Frame Ran: {0}", (frameTime * 1000f) );

		if( frameTime < minFrameTime )
			await Task.Delay( (int)((minFrameTime - frameTime) * 1000f) );

		return gameState;
	}

	protected async ValueTask<IGameState?> OnFrame( double dt ) {
		if( gameState == null ) return null;

		var currGameState = gameState;

		currGameState = await currGameState.Update( dt );

		if( /*renderer != null &&*/ currGameState == gameState ) {
			GL.ClearColor( Color.Pink );
			GL.Enable( EnableCap.DepthTest );
			GL.Clear(ClearBufferMask.DepthBufferBit | ClearBufferMask.ColorBufferBit );
			currGameState = await currGameState.Render( renderer );

			PlatformWindow.GLContext.MakeCurrent();
		}

		return currGameState;
	}

	public async Task Close() {
		CloseAsync().GetAwaiter().GetResult();
	}

	public async Task CloseAsync() {
		isClosing = true;

		await Task.CompletedTask;
	}
}
