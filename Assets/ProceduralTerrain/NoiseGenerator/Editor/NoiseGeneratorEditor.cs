using ProceduralTerrain.NoiseGenerator.Base;
using UnityEditor;
using UnityEngine;

namespace ProceduralTerrain.NoiseGenerator.Editor
{
    [CustomEditor(typeof(NoiseGeneratorBase), true)]
    public class NoiseGeneratorEditor : UnityEditor.Editor
    {
        private Texture2D _previewTexture;
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var noise = (NoiseGeneratorBase) target;
            if (noise.NeedsUpdate() || _previewTexture == null)
            {
                _previewTexture = noise.GenerateTexture(Screen.width, Screen.width, noise.previewResolution);
                noise.NeedsUpdate(false);
            }
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("Preview", EditorStyles.boldLabel);
            EditorGUILayout.Space(5);

            if(_previewTexture == null) return;
            
            var layoutRect = EditorGUILayout.GetControlRect();
            var textureRect = new Rect(layoutRect.x, layoutRect.y, Screen.width-40f, Screen.width-40f);
            EditorGUILayout.Space(Screen.width);
            EditorGUI.DrawPreviewTexture(textureRect, _previewTexture);
        }
    }
}
