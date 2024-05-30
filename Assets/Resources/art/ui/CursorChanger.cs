using UnityEngine;

public class CursorChanger : MonoBehaviour
{
    public Sprite cursorSprite; // Sprite Ÿ������ ����
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;

    void Start()
    {
        // ��������Ʈ�� �ؽ�ó�� ������
        Texture2D cursorTexture = cursorSprite.texture;
        Rect spriteRect = cursorSprite.rect;
        Vector2 cursorPivot = new Vector2(spriteRect.width / 2, spriteRect.height / 2);

        // �ؽ�ó�� �߶󳻾� Ŀ���� ���
        Texture2D croppedTexture = new Texture2D((int)spriteRect.width, (int)spriteRect.height);
        croppedTexture.SetPixels(cursorTexture.GetPixels((int)spriteRect.x, (int)spriteRect.y, (int)spriteRect.width, (int)spriteRect.height));
        croppedTexture.Apply();

        // Ŀ�� ����
        Cursor.SetCursor(croppedTexture, hotSpot, cursorMode);
    }
}
