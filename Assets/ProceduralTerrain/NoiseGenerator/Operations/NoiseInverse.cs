using ProceduralTerrain.NoiseGenerator.Base;
using UnityEngine;

namespace ProceduralTerrain.NoiseGenerator
{
    [CreateAssetMenu(fileName = "Data", menuName = "ProceduralTerrain/Noise/Operations/Inverse", order = 1)]
    public class NoiseInverse : NoiseGeneratorBase
    {
        [SerializeField] private NoiseGeneratorBase noise;

        // Start is called before the first frame update
        public override float GetNoise(float x, float y, float z = 0)
        {
            if (noise != null ){
                return( -noise.GetNoise(x, y , z )) ;
            }
            else{
                return 0;
            }
        }
    }
}
