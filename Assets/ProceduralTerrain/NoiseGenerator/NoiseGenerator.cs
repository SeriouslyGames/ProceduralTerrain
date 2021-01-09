using ProceduralTerrain.NoiseGenerator.Base;
using UnityEngine;

[System.Serializable]
public class FractalProperties
{
    public int octaves = 1;
    public float lacunarity = 1f;
    public float gain = 1f;
}

namespace ProceduralTerrain.NoiseGenerator
{
    [CreateAssetMenu(fileName = "Data", menuName = "ProceduralTerrain/Noise/Noise", order = 1)]
    public class NoiseGenerator : NoiseGeneratorBase
    {
        [SerializeField] private FastNoise.NoiseType noiseType = FastNoise.NoiseType.Perlin;
        [SerializeField] private int seed = 0;
        [SerializeField] private float intensity = 1;
        [SerializeField] private float frequency = 1f;
        
        // TODO: Do not show this parameters if noise type is not fractal
        [Header("Fractal properties")]
        [SerializeField] private FractalProperties fractalProperties;

        [SerializeField] private FastNoise.FractalType fractalType = FastNoise.FractalType.FBM;

        private readonly FastNoise _noise = new FastNoise();

        protected void Awake()
        {
            _noise.SetSeed(seed);
        }
        protected override void OnValidate()
        {
            base.OnValidate();
            _noise.SetNoiseType(noiseType);
            _noise.SetSeed(seed);
            _noise.SetFrequency(frequency/50f);
            _noise.SetFractalType(fractalType);
            _noise.SetFractalOctaves(fractalProperties.octaves);
            _noise.SetFractalLacunarity(fractalProperties.lacunarity);
            _noise.SetFractalGain(fractalProperties.gain);
        }
        public override float GetNoise(float x, float y, float z = 0)
        {
            return _noise.GetNoise(x, y, z)*intensity;
        }
    }
}