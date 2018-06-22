using UnityEngine;
using System.Collections.Generic;

public abstract class Cloner : MonoBehaviour
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

	private List<List<T>> Split<T> (List<T> elements, int size)
	{
		var l = new List<List<T>> ();
		for (int i = 0; i < elements.Count; i += size)
			l.Add (elements.GetRange (i, Mathf.Min (size, elements.Count - 1)));
		return l;
	}
}