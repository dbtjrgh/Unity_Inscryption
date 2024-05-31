using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMouseCursor : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        // ���� ī�޶� ã�Ƽ� �Ҵ�
        mainCamera = Camera.main;

        // �ý��� Ŀ�� �����
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined; // Ŀ���� ȭ�� �ȿ� ����
    }

    void Update()
    {
        // ���콺 ��ġ ��������
        Vector3 mousePosition = Input.mousePosition;

        // ȭ�� ��ǥ�� ���� ��ǥ�� ��ȯ
        Vector3 worldPosition = mainCamera.ScreenToWorldPoint(mousePosition);
        worldPosition.z = 0; // Z �� ��ġ�� 0���� �����Ͽ� 2D ��� ����

        // ������Ʈ ��ġ�� ���� ��ǥ�� �̵�
        transform.position = worldPosition;
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
