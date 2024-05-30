using UnityEngine;
using UnityEditor;
using System.IO;

public class SpriteToTexture : MonoBehaviour
{
    [MenuItem("Assets/Convert Sprite to Texture")]
    public static void ConvertSpriteToTexture()
    {
        Sprite sprite = Selection.activeObject as Sprite;
        if (sprite != null)
        {
            Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
            Color[] newColors = sprite.texture.GetPixels((int)sprite.textureRect.x, (int)sprite.textureRect.y, (int)sprite.textureRect.width, (int)sprite.textureRect.height);
            texture.SetPixels(newColors);
            texture.Apply();

            byte[] bytes = texture.EncodeToPNG();
            string path = Path.Combine(Application.dataPath, sprite.name + ".png");
            File.WriteAllBytes(path, bytes);

            AssetDatabase.Refresh();
            Debug.Log("Sprite converted to texture and saved at: " + path);
        }
        else
        {
            Debug.LogError("Selected object is not a sprite.");
        }
    }
}
