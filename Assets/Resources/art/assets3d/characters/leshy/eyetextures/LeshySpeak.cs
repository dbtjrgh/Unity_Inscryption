using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeshySpeak : MonoBehaviour
{
    public Texture2D[] textures; // 네모난 텍스쳐들
    public float radius = 5f; // 원형 배치의 반지름
    public float animationSpeed = 1f; // 애니메이션 속도
    public GameObject spritePrefab; // 스프라이트 프리팹

    private GameObject[] spriteObjects;
    private int currentTextureIndex = 0;
    private float timer = 0f;

    void Start()
    {
        CreateSprites();
        PositionSpritesInCircle();
    }

    void Update()
    {
        AnimateTextures();
    }

    void CreateSprites()
    {
        spriteObjects = new GameObject[textures.Length];
        for (int i = 0; i < textures.Length; i++)
        {
            GameObject spriteObject = Instantiate(spritePrefab, transform);
            SpriteRenderer renderer = spriteObject.GetComponent<SpriteRenderer>();
            renderer.sprite = Sprite.Create(textures[i], new Rect(0, 0, textures[i].width, textures[i].height), new Vector2(0.5f, 0.5f));
            spriteObjects[i] = spriteObject;
        }
    }

    void PositionSpritesInCircle()
    {
        int spriteCount = spriteObjects.Length;
        for (int i = 0; i < spriteCount; i++)
        {
            float angle = i * Mathf.PI * 2 / spriteCount;
            Vector3 newPosition = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
            spriteObjects[i].transform.localPosition = newPosition;
        }
    }

    void AnimateTextures()
    {
        timer += Time.deltaTime * animationSpeed;
        if (timer >= 1f)
        {
            timer = 0f;
            currentTextureIndex = (currentTextureIndex + 1) % spriteObjects.Length;
            UpdateSpriteVisibility();
        }
    }

    void UpdateSpriteVisibility()
    {
        for (int i = 0; i < spriteObjects.Length; i++)
        {
            spriteObjects[i].SetActive(i == currentTextureIndex);
        }
    }
}
