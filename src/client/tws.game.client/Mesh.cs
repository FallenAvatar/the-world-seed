using System;
using System.Collections.Generic;

using Silk.NET.OpenGL;

namespace tws.game.client;
public class Mesh : IDisposable {
	public float[] Vertices { get; private set; }
	public uint[] Indices { get; private set; }
	public IReadOnlyList<Texture>? Textures { get; private set; }
	public VertexArrayObject<float, uint>? VAO { get; set; }
	public BufferObject<float>? VBO { get; set; }
	public BufferObject<uint>? EBO { get; set; }
	public GL GL { get; }

	public Mesh( GL gl, float[] vertices, uint[] indices, List<Texture> textures ) {
		GL = gl;
		Vertices = vertices;
		Indices = indices;
		Textures = textures;
		SetupMesh();
	}
	public void Dispose() {
		Textures = null;
		if( VAO != null ) { VAO.Dispose(); VAO = null; };
		if( VBO != null ) { VBO.Dispose(); VBO = null; };
		if( EBO != null ) { EBO.Dispose(); EBO = null; };
	}

	public void SetupMesh() {
		EBO = new BufferObject<uint>( GL, Indices, BufferTargetARB.ElementArrayBuffer );
		VBO = new BufferObject<float>( GL, Vertices, BufferTargetARB.ArrayBuffer );
		VAO = new VertexArrayObject<float, uint>( GL, VBO, EBO );
		VAO.VertexAttributePointer( 0, 3, VertexAttribPointerType.Float, 5, 0 );
		VAO.VertexAttributePointer( 1, 2, VertexAttribPointerType.Float, 5, 3 );
	}

	public void Bind() {
		if( VAO == null ) throw new NullReferenceException("Cannot bind a mesh with a null VAO.");

		VAO.Bind();
	}
}
