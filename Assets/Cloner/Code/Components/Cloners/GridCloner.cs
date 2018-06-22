using UnityEngine;
using System.Collections.Generic;

public class GridCloner : MeshCloner
{
	public Vector3Int count = Vector3Int.one;
	public Vector3 padding = Vector3.one;

	private int oneOverXYSize;
	private int ZYSize;

	protected override int PointCount { get { return count.x * count.y * count.z; } }

	protected override void CalculatePoints (ref List<Matrix4x4> points)
	{
		if (count.x < 0 || count.y < 0 || count.z < 0)
			return;

		float xPadding = padding.x + mesh.bounds.size.x;
		float yPadding = padding.y + mesh.bounds.size.y;
		float zPadding = padding.z + mesh.bounds.size.z;

		for (int x = 0; x < count.x; x++)
		{
			for (int y = 0; y < count.y; y++)
			{
				for (int z = 0; z < count.z; z++)
				{
					var index = x + count.x * (y + count.y * z);
					points[index] = Matrix4x4.TRS (transform.position + new Vector3 (x * xPadding, y * yPadding, z * zPadding), transform.rotation, transform.localScale);
				}
			}
		}
	}
}