using System.Collections.Generic;
using UnityEngine;

public class LinearCloner : MeshCloner
{
	public int count;
	public float padding = 0f;
	public float offset;

	private Vector3 spacing;

	protected override int PointCount { get { return count; } }

	protected override List<Matrix4x4> CalculatePoints (List<Matrix4x4> points)
	{
		spacing = Vector3.forward * (mesh.bounds.size.z + padding);
		for (int i = 0; i < points.Count; i++)
			points[i] = Matrix4x4.TRS (transform.position + transform.rotation * (spacing * i + Vector3.forward * offset), transform.rotation, transform.localScale);
		return points;
	}

	protected override bool ParametersChanged ()
	{
		return true;
	}
}