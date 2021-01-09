using System;
using System.Linq;
using ProceduralTerrain.NoiseGenerator.Base;
using UnityEngine;

namespace ProceduralTerrain.NoiseGenerator
{
    [CreateAssetMenu(fileName = "Data", menuName = "ProceduralTerrain/Noise/Operations/Sum", order = 1)]
    public class NoiseSum : NoiseGeneratorBase
    {
        [SerializeField] private NoiseWithIntensity[] noiseArray;
        [SerializeField] private float zoom = 1f;
        public override float GetNoise(float x, float y, float z = 0)
        {
            return noiseArray.Sum(noiseWithIntensity => noiseWithIntensity.noise.GetNoise(x * zoom, y * zoom, z * zoom)*noiseWithIntensity.intensity);
        }
    }
}
