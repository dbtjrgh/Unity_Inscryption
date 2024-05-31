using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // 메인 카메라를 찾아서 할당
        mainCamera = Camera.main;

        // 시스템 커서 숨기기
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined; // 커서를 화면 안에 제한
    }

    void Update()
    {
        // 마우스 위치 가져오기
        Vector3 mousePosition = Input.mousePosition;

        // 화면 좌표를 월드 좌표로 변환
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0; // Z 축 위치를 0으로 설정하여 2D 평면 유지

        // 오브젝트 위치를 월드 좌표로 이동
        transform.position = worldPosition;
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
