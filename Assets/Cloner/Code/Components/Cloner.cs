using UnityEngine;
using System.Collections.Generic;

public abstract class Cloner : InstanceRenderer
{
	public bool update = true;
	public Mesh mesh;
	public Material material;

	protected List<Matrix4x4> points = new List<Matrix4x4> ();

	protected abstract int PointCount { get; }
	protected abstract void CalculatePoints (ref List<Matrix4x4> points);

	private void Start ()
	{
		if (PointCount != points.Count)
			ResizePointsList (PointCount);
		UpdatePoints ();
	}
	private void Update ()
	{
		if (mesh == null || material == null || PointCount < 1)
			return;

		if (update)
		{
			if (PointCount != points.Count)
				ResizePointsList (PointCount);
			UpdatePoints ();
		}

		Draw (mesh, material, points);
	}

	public void UpdatePoints ()
	{
		CalculatePoints (ref points);
	}

	private void ResizePointsList (int goalCount)
	{
		var difference = goalCount - points.Count;

		if (difference > 0)
			for (int i = 0; i < difference; i++)
				points.Add (new Matrix4x4 ());
		else
			while (points.Count > goalCount)
				points.RemoveAt (points.Count - 1);
	}
}
