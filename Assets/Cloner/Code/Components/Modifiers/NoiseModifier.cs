using System.Collections.Generic;
using UnityEngine;

namespace Cloner
{
	public class NoiseModifier : PointModifier
	{
		public float speed = 0.1f;
		public float magnitude = 1f;
		public float frequency = 1f;
		[Range (1, 8)]
		public int octaves = 2;
		public float lacunarity = 2f;
		public float gain = 2f;
		public bool lookAlongDerivative = true;
		public FastNoise.NoiseType noiseType = FastNoise.NoiseType.SimplexFractal;
		public FastNoise.Interp interpolation;

		private FastNoise noise = new FastNoise ();
		private float t;

		public override List<Matrix4x4> Modify (List<Matrix4x4> points)
		{
			if (frequency == 0)
				frequency = 0.0001f;
			if (magnitude == 0f)
				magnitude = 0.0001f;

			t += Time.deltaTime * speed / frequency;
			noise.SetNoiseType (noiseType);
			noise.SetInterp (interpolation);

			noise.SetFrequency (frequency);
			noise.SetFractalOctaves (octaves);
			noise.SetFractalLacunarity (lacunarity);
			noise.SetFractalGain (gain);

			for (int i = 0; i < points.Count; i++)
			{
				Vector4 p = points[i].GetColumn (3);
				var x = noise.GetNoise (p.x + t, 0f, 0f) * magnitude;
				var y = noise.GetNoise (0f, p.y + t, 0f) * magnitude;
				var z = noise.GetNoise (0f, 0f, p.z + t) * magnitude;
				var derivative = new Vector3 (x, y, z);

				points[i] *= Matrix4x4.TRS (derivative, (lookAlongDerivative) ? Quaternion.LookRotation (derivative) : Quaternion.identity, Vector3.one);
			}

			return points;
		}
	}
}