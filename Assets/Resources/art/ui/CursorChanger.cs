using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Sprite cursorSprite; // Sprite 타입으로 변경
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        // 스프라이트의 텍스처를 가져옴
        Texture2D cursorTexture = cursorSprite.texture;
        Rect spriteRect = cursorSprite.rect;
        Vector2 cursorPivot = new Vector2(spriteRect.width / 2, spriteRect.height / 2);

        // 텍스처를 잘라내어 커서로 사용
        Texture2D croppedTexture = new Texture2D((int)spriteRect.width, (int)spriteRect.height);
        croppedTexture.SetPixels(cursorTexture.GetPixels((int)spriteRect.x, (int)spriteRect.y, (int)spriteRect.width, (int)spriteRect.height));
        croppedTexture.Apply();

        // 커서 설정
        Cursor.SetCursor(croppedTexture, hotSpot, cursorMode);
    }
}
