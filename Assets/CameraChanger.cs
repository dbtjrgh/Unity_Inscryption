using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChanger : MonoBehaviour
{
    public Camera PerspectiveUICamera; // PixelCamera¸¦ ÂüÁ¶

    private void Start()
    {
        if (PerspectiveUICamera == null)
        {
            PerspectiveUICamera = GetComponent<Camera>();
        }
    }

    public void ChangeClearFlagsToSolidColor()
    {
        if (PerspectiveUICamera != null)
        {
            PerspectiveUICamera.clearFlags = CameraClearFlags.SolidColor;
            Debug.Log("PixelCamera Clear Flags changed to Solid Color");
        }
        else
        {
            Debug.LogWarning("PixelCamera reference is missing!");
        }
    }
}
