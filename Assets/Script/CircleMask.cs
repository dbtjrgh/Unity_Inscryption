using UnityEngine;

public class CircleMask : MonoBehaviour
{
    public Texture2D sourceTexture;

    void Start()
    {
        Texture2D circularTexture = CreateCircularTexture(sourceTexture);
        GetComponent<Renderer>().material.mainTexture = circularTexture;
    }

    Texture2D CreateCircularTexture(Texture2D source)
    {
        int width = source.width;
        int height = source.height;
        Texture2D circularTexture = new Texture2D(width, height, TextureFormat.RGBA32, false);

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                float centerX = width / 2;
                float centerY = height / 2;
                float radius = width / 2;

                float dx = x - centerX;
                float dy = y - centerY;
                float distanceSquared = dx * dx + dy * dy;

                if (distanceSquared <= radius * radius)
                {
                    circularTexture.SetPixel(x, y, source.GetPixel(x, y));
                }
                else
                {
                    circularTexture.SetPixel(x, y, Color.clear);
                }
            }
        }

        circularTexture.Apply();
        return circularTexture;
    }
}
