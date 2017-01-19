using UnityEngine;
using System.Collections;
using System;
using UnityEditor;
[Serializable]
public class ColorPalette : ScriptableObject {
    
    [MenuItem("Assets/Create/Color Palette")]
    public static void CreateColorPalette()
    {
        if(Selection.activeObject is Texture2D)
        {
            var selectedTexture = Selection.activeObject as Texture2D;

            var selectionPath = AssetDatabase.GetAssetPath(selectedTexture);

            selectionPath = selectionPath.Replace(".png", "-color-palette.asset");

            var newPalette = CustomAssetUtility.CreateAsset<ColorPalette>(selectionPath);
        }
    }

}
