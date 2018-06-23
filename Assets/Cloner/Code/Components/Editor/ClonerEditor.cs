using UnityEditor;
using UnityEngine;

namespace Cloner
{
	[CustomEditor (typeof (Cloner), true)]
	[CanEditMultipleObjects]
	public class ClonerEditor : Editor
	{
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();
			Repaint ();
		}
	}
}