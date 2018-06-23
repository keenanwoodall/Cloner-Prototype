using System.Collections.Generic;
using UnityEngine;

public class MeshCloner : Cloner
{
	public Vector3 scale = Vector3.one;
	public bool alignWithNormals;
	public MeshFilter target;

	private Vector3[] vertices;
	private Vector3[] normals;

	protected override int PointCount { get { return (target == null) ? 0 : target.mesh.vertexCount; } }


	protected override void CalculatePoints (ref List<Matrix4x4> points)
	{
		if (target == null)
			return;

		vertices = target.sharedMesh.vertices;
		normals = target.sharedMesh.normals;

		for (int i = 0; i < points.Count; i++)
		{
			var position = target.transform.rotation * (vertices[i]);
			position.Scale (target.transform.localScale);
			position += target.transform.position;
			var rotation = (alignWithNormals ? (Quaternion.LookRotation (normals[i])) : Quaternion.identity);
			points[i] = Matrix4x4.TRS (position, rotation, scale);
		}
	}
}