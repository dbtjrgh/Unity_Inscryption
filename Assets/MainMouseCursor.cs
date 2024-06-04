using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMouseCursor : MonoBehaviour
{
    private RectTransform rectTransform;
    private Canvas canvas;

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

        // 화면 좌표를 Canvas 로컬 좌표로 변환
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, mousePosition, canvas.worldCamera, out localPoint);

        // 로컬 좌표를 RectTransform 위치로 설정
        rectTransform.localPosition = localPoint;
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
