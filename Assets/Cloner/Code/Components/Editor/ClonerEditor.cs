using UnityEngine;
using UnityEditor;

namespace Cloner
{
	[CustomEditor (typeof (Cloner), true)]
	public class ClonerEditor : Editor
	{
		public override void OnInspectorGUI ()
		{
			base.OnInspectorGUI ();
			(target as Cloner).UpdatePoints ();
			Repaint ();
		}
	}
}