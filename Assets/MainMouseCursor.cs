using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMouseCursor : MonoBehaviour
{
    private RectTransform rectTransform;
    private Canvas canvas;
    public float cursorSensitivity = 1.0f; // Ŀ�� �ΰ����� ������ �� �ִ� ����

    void Start()
    {
        // RectTransform�� �����ɴϴ�.
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform is not found on the GameObject.");
            return;
        }

        // Canvas�� �����ɴϴ�.
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas is not found in the parent hierarchy.");
            return;
        }

        // �ý��� Ŀ�� �����
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined; // Ŀ���� ȭ�� �ȿ� ����
    }

    void Update()
    {
        if (rectTransform == null || canvas == null)
        {
            return;
        }

        // ���콺 ��ġ ��������
        Vector3 mousePosition = Input.mousePosition;

        // ȭ�� ��ǥ�� Canvas�� ���� ��ǥ�� ��ȯ
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out localPoint);

        // �ΰ��� ����
        localPoint *= cursorSensitivity;

        // ���� ��ǥ�� RectTransform ��ġ�� ����
        rectTransform.localPosition = localPoint;

        // ĵ���� ��� ���� ���콺 Ŀ�� ��ġ ����
        Vector2 sizeDelta = rectTransform.sizeDelta;
        Vector2 canvasSize = canvas.GetComponent<RectTransform>().sizeDelta;

        float halfWidth = canvasSize.x / 2 - sizeDelta.x / 2;
        float halfHeight = canvasSize.y / 2 - sizeDelta.y / 2;

        rectTransform.localPosition = new Vector2(
            Mathf.Clamp(rectTransform.localPosition.x, -halfWidth, halfWidth),
            Mathf.Clamp(rectTransform.localPosition.y, -halfHeight, halfHeight)
        );
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            // ��Ŀ���� �Ҿ��ٰ� �ٽ� ����� �� Ŀ���� �ٽ� ����� ����
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
