using System.Linq;
using ProceduralTerrain.NoiseGenerator.Base;
using UnityEngine;

namespace ProceduralTerrain.NoiseGenerator.Operations
{
    [CreateAssetMenu(fileName = "Data", menuName = "ProceduralTerrain/Noise/Operations/Multiply", order = 1)]
    public class NoiseMultiply : NoiseGeneratorBase
    {
        [SerializeField] private NoiseWithIntensity[] noiseArray;
        [SerializeField] private float zoom = 1f;

        public override float GetNoise(float x, float y, float z = 0)
        {
            return noiseArray.Aggregate<NoiseWithIntensity, float>(0, (current, noiseWithIntensity) =>
            {
                if (noiseWithIntensity.noise == null) return 0;
                var noise = noiseWithIntensity.noise.GetNoise(x * zoom, y * zoom, z * zoom) *
                            noiseWithIntensity.intensity;
                if (current <= 0f)
                {
                    return noise;
                }
                else
                {
                    return current * noise;
                }
            });
        }
    }
}
