using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMouseCursor : MonoBehaviour
{
    private RectTransform rectTransform;
    private Canvas canvas;
    public float cursorSensitivity = 1.0f; // 커서 민감도를 조정할 수 있는 변수

    void Start()
    {
        // RectTransform을 가져옵니다.
        rectTransform = GetComponent<RectTransform>();
        if (rectTransform == null)
        {
            Debug.LogError("RectTransform is not found on the GameObject.");
            return;
        }

        // Canvas를 가져옵니다.
        canvas = GetComponentInParent<Canvas>();
        if (canvas == null)
        {
            Debug.LogError("Canvas is not found in the parent hierarchy.");
            return;
        }

        // 시스템 커서 숨기기
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined; // 커서를 화면 안에 제한
    }

    void Update()
    {
        if (rectTransform == null || canvas == null)
        {
            return;
        }

        // 마우스 위치 가져오기
        Vector3 mousePosition = Input.mousePosition;

        // 화면 좌표를 Canvas의 로컬 좌표로 변환
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out localPoint);

        // 민감도 적용
        localPoint *= cursorSensitivity;

        // 로컬 좌표를 RectTransform 위치로 설정
        rectTransform.localPosition = localPoint;

        // 캔버스 경계 내로 마우스 커서 위치 제한
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
            // 포커스를 잃었다가 다시 얻었을 때 커서를 다시 숨기고 제한
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
