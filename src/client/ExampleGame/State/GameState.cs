using System;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

using Silk.NET.Input;
using Silk.NET.Maths;
using Silk.NET.OpenGL;

using tws.game.client;
using tws.game.client.Renderer;
using tws.game.client.State;
using tws.game.Utils;

namespace ExampleGame.State;

internal class GameState : BasePhysicsState {
	private tws.game.client.Texture? Texture;
	private tws.game.client.Shader? Shader;
	private tws.game.client.Model? Model;

	//Setup the camera's location, directions, and movement speed
	private Vector3 CameraPosition = new Vector3( 0.0f, 0.0f, 3.0f );
	private Vector3 CameraFront = new Vector3( 0.0f, 0.0f, -1.0f );
	private Vector3 CameraUp = Vector3.UnitY;
	private Vector3 CameraDirection = Vector3.Zero;
	private float CameraYaw = -90f;
	private float CameraPitch = 0f;
	private float CameraZoom = 45f;

	//Used to track change in mouse movement to allow for moving of the Camera
	private Vector2 LastMousePosition;
	private double deltaTime;

	public GameState( GameClient game ) : base( game ) { }

	protected override async ValueTask DisposeAsyncCore() {
		await base.DisposeAsyncCore();
		if( Model != null ) { await Model.DisposeAsync(); Model = null; }
		if( Shader != null ) { await Shader.DisposeAsync(); Shader = null; }
		if( Texture != null ) { await Texture.DisposeAsync(); Texture = null; }
	}

	public override async Task Load() {
		if( Game.Input == null ) return;

		if( Game.Input.PrimaryKeyboard != null )
			Game.Input.PrimaryKeyboard.KeyDown += KeyDown;
		
		//for( int i = 0; i < Game.Input.Mice.Count; i++ ) {
		//	Game.Input.Mice[i].Cursor.CursorMode = CursorMode.Raw;
		//	Game.Input.Mice[i].MouseMove += OnMouseMove;
		//	Game.Input.Mice[i].Scroll += OnMouseWheel;
		//}
		foreach( var m in Game.Input.Mice ) {
			m.Cursor.CursorMode = CursorMode.Raw;
			m.MouseMove += OnMouseMove;
			m.Scroll += OnMouseWheel;
		}

		var Gl = Game.GL;
		if( Gl == null ) throw new NullReferenceException( "GL instance must be initialized." );

		Shader = new tws.game.client.Shader( Gl, @"assets\shader.vert", @"assets\shader.frag" );
		Texture = new tws.game.client.Texture( Gl, @"assets\silk.png" );
		Model = new tws.game.client.Model( Gl, @"assets\cube.model" );
	}

	protected override async Task<IGameState> DoUpdate( double dt ) {
		var moveSpeed = 2.5f * (float)dt;

		if( Game.Input?.PrimaryKeyboard == null ) return this;

		if( Game.Input.PrimaryKeyboard.IsKeyPressed( Key.W ) ) {
			//Move forwards
			CameraPosition += moveSpeed * CameraFront;
		}
		if( Game.Input.PrimaryKeyboard.IsKeyPressed( Key.S ) ) {
			//Move backwards
			CameraPosition -= moveSpeed * CameraFront;
		}
		if( Game.Input.PrimaryKeyboard.IsKeyPressed( Key.A ) ) {
			//Move left
			CameraPosition -= Vector3.Normalize( Vector3.Cross( CameraFront, CameraUp ) ) * moveSpeed;
		}
		if( Game.Input.PrimaryKeyboard.IsKeyPressed( Key.D ) ) {
			//Move right
			CameraPosition += Vector3.Normalize( Vector3.Cross( CameraFront, CameraUp ) ) * moveSpeed;
		}

		await Task.CompletedTask;

		return this;
	}

	public override async Task<IGameState> Render( IRenderer renderer ) {
		var Gl = Game.GL;
		if( Gl == null ) return this;
		if( Game.PlatformWindow == null ) return this;

		//Gl.Enable( EnableCap.DepthTest );
		//Gl.Clear( ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit );

		if( Texture == null ) return this;
		Texture.Bind();
		if( Shader == null ) return this;
		Shader.Use();
		Shader.SetUniform( "uTexture0", 0 );

		//Use elapsed time to convert to radians to allow our cube to rotate over time
		var difference = (float)deltaTime;

		var model = Matrix4x4.CreateRotationY( MathHelper.DegreesToRadians( difference ) ) * Matrix4x4.CreateRotationX( MathHelper.DegreesToRadians( difference ) );
		var view = Matrix4x4.CreateLookAt( CameraPosition, CameraPosition + CameraFront, CameraUp );
		//It's super important for the width / height calculation to regard each value as a float, otherwise
		//it creates rounding errors that result in viewport distortion
		var projection = Matrix4x4.CreatePerspectiveFieldOfView( MathHelper.DegreesToRadians( CameraZoom ), (float)Game.PlatformWindow.Size.X / (float)Game.PlatformWindow.Size.Y, 0.1f, 100.0f );

		if( Model == null ) return this;
		foreach( var mesh in Model.Meshes ) {
			mesh.Bind();
			Shader.Use();
			Texture.Bind();
			Shader.SetUniform( "uTexture0", 0 );
			Shader.SetUniform( "uModel", model );
			Shader.SetUniform( "uView", view );
			Shader.SetUniform( "uProjection", projection );

			Gl.DrawArrays( PrimitiveType.Triangles, 0, (uint)mesh.Vertices.Length );
		}

		await Task.CompletedTask;

		return this;
	}

	private unsafe void OnMouseMove( IMouse mouse, Vector2 position ) {
		var lookSensitivity = 0.1f;
		if( LastMousePosition == default ) {
			LastMousePosition = position;
		} else {
			var xOffset = (position.X - LastMousePosition.X) * lookSensitivity;
			var yOffset = (position.Y - LastMousePosition.Y) * lookSensitivity;
			LastMousePosition = position;

			CameraYaw += xOffset;
			CameraPitch -= yOffset;

			//We don't want to be able to look behind us by going over our head or under our feet so make sure it stays within these bounds
			CameraPitch = Math.Clamp( CameraPitch, -89.0f, 89.0f );

			CameraDirection.X = MathF.Cos( MathHelper.DegreesToRadians( CameraYaw ) ) * MathF.Cos( MathHelper.DegreesToRadians( CameraPitch ) );
			CameraDirection.Y = MathF.Sin( MathHelper.DegreesToRadians( CameraPitch ) );
			CameraDirection.Z = MathF.Sin( MathHelper.DegreesToRadians( CameraYaw ) ) * MathF.Cos( MathHelper.DegreesToRadians( CameraPitch ) );
			CameraFront = Vector3.Normalize( CameraDirection );
		}
	}

	private unsafe void OnMouseWheel( IMouse mouse, ScrollWheel scrollWheel ) {
		//We don't want to be able to zoom in too close or too far away so clamp to these values
		CameraZoom = Math.Clamp( CameraZoom - scrollWheel.Y, 1.0f, 45f );
	}

	private void KeyDown( IKeyboard keyboard, Key key, int arg3 ) {
		if( key == Key.Escape ) {
			_ = Game.Close();
		}
	}
}
