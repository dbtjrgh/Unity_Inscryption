using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClearFlagsChanger : MonoBehaviour
{
    public Camera pixelCamera; // PixelCamera¸¦ ÂüÁ¶

    private void Start()
    {
        if (pixelCamera == null)
        {
            pixelCamera = GetComponent<Camera>();
        }
    }

    public void ChangeClearFlagsToSolidColor()
    {
        if (pixelCamera != null)
        {
            pixelCamera.clearFlags = CameraClearFlags.SolidColor;
            Debug.Log("PixelCamera Clear Flags changed to Solid Color");
        }
        else
        {
            Debug.LogWarning("PixelCamera reference is missing!");
        }
    }
}
