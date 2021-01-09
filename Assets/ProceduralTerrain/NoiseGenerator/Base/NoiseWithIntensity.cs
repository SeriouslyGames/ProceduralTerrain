using System;

namespace ProceduralTerrain.NoiseGenerator.Base
{
    [Serializable]
    class NoiseWithIntensity
    {
        public NoiseGeneratorBase noise;
        public float intensity = 1f;
    }
}