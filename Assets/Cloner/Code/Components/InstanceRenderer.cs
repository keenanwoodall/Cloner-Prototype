using UnityEngine;
using System.Collections.Generic;
using System.Linq;

[ExecuteInEditMode]
public abstract class InstanceRenderer : MonoBehaviour
{
	public void Draw (Mesh mesh, Material material, List<Matrix4x4> matrices)
	{
		var batches = Split (matrices, 1023);

		for (int batchIndex = 0; batchIndex < batches.Count; batchIndex++)
		{
			for (int subMeshIndex = 0; subMeshIndex < mesh.subMeshCount; subMeshIndex++)
			{
				Graphics.DrawMeshInstanced (mesh, subMeshIndex, material, batches[batchIndex]);
			}
		}
	}

	private List<List<T>> Split<T> (List<T> source, int size)
	{
		return source
			.Select ((x, i) => new { Index = i, Value = x })
			.GroupBy (x => x.Index / size)
			.Select (x => x.Select (v => v.Value).ToList ())
			.ToList ();
	}
}