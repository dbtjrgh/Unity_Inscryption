using UnityEngine;

public class EyeBallAnimation : MonoBehaviour
{
    public Material eyeMaterial;      // 애니메이션을 적용할 머티리얼
    public Texture2D[] eyeTextures;   // 애니메이션에 사용될 텍스처 배열
    public float frameRate = 10f;     // 애니메이션 프레임 속도

    private int _currentFrame;
    private float _timer;

    void Start()
    {
        if (eyeTextures.Length == 0)
        {
            Debug.LogError("No eye textures assigned.");
            return;
        }

        if (eyeMaterial == null)
        {
            Debug.LogError("No eye material assigned.");
            return;
        }
    }

    void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 1f / frameRate)
        {
            _timer -= 1f / frameRate;
            _currentFrame = (_currentFrame + 1) % eyeTextures.Length;
            eyeMaterial.mainTexture = eyeTextures[_currentFrame];
        }
    }
}
