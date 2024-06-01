using UnityEngine;

public class EyeBallAnimation : MonoBehaviour
{
    public Material eyeMaterial;      // �ִϸ��̼��� ������ ��Ƽ����
    public Texture2D[] eyeTextures;   // �ִϸ��̼ǿ� ���� �ؽ�ó �迭
    public float frameRate = 10f;     // �ִϸ��̼� ������ �ӵ�

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
