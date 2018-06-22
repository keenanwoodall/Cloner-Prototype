using UnityEngine;
using System.Collections.Generic;

public abstract class PointModifier : MonoBehaviour
{
	public abstract List<Matrix4x4> Modify (List<Matrix4x4> points);
}