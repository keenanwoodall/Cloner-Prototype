using UnityEngine;
using System.Collections.Generic;

public class GridCloner : MeshCloner
{
	public Vector3Int count = new Vector3Int (1, 1, 1);
	public float padding = 0f;

	private int oneOverXYSize;
	private int ZYSize;

	protected override int PointCount { get { return count.x * count.y * count.z; } }

	protected override List<Matrix4x4> CalculatePoints (List<Matrix4x4> points)
	{
		if (count.x < 0 || count.y < 0 || count.z < 0)
			return points;
		for (int x = 0; x < count.x; x++)
		{
			for (int y = 0; y < count.y; y++)
			{
				for (int z = 0; z < count.z; z++)
				{
					var index = x + count.x * (y + count.y * z);
					print (index);
					points[index] = Matrix4x4.TRS (transform.position + new Vector3 (x * padding, y * padding, z * padding), transform.rotation, transform.localScale);
				}
			}
		}

		return points;
	}

	protected override bool ParametersChanged ()
	{
		return true;
	}
}