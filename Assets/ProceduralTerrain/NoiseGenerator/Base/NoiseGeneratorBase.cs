using UnityEngine;

namespace ProceduralTerrain.NoiseGenerator.Base
{
    public class NoiseGeneratorBase : ScriptableObject
    {
        private bool _updatePreview = true;
        
        [Range(0.1f, 1.0f)]
        public float previewResolution = 0.2f;

        protected virtual void OnValidate()
        {
            _updatePreview = true;
        }
        
        public void NeedsUpdate(bool needsUpdate)
        {
            _updatePreview = needsUpdate;
        }
        
        public bool NeedsUpdate()
        {
            return _updatePreview;
        }

        public virtual float GetNoise(float x, float y, float z = 0)
        {
            return 0;
        }
        
        public Texture2D GenerateTexture(int width, int height, float resolution)
        {
            var textureWidth = Mathf.FloorToInt(width * resolution);
            var textureHeight = Mathf.FloorToInt(height * resolution);
            var texture = new Texture2D(textureWidth, textureHeight);

            for (var i = 0; i < textureWidth; i++)
            {
                for (var j = 0; j < textureHeight; j++)
                {
                    var y = GetNoise((i / resolution) - (width / 2f), (j / resolution)- (height / 2f));
                    texture.SetPixel(i, j, new Color(y,y,y,1f));
                }
            }
            texture.Apply();
            return texture;
        }
    }
}