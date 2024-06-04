using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform[] cameraPositions; // ī�޶� ��ġ �迭
    public float moveSpeed = 2.0f; // ī�޶� �̵� �ӵ�
    private int currentPosIndex = 0; // ���� ī�޶� ��ġ �ε���
    private Transform targetPosition; // ��ǥ ��ġ

    void Start()
    {
        if (cameraPositions.Length > 0)
        {
            // ���� ��ġ ����
            currentPosIndex = 0;
            targetPosition = cameraPositions[currentPosIndex];
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
        }
    }

    void Update()
    {
        // Ű �Է� ó��
        if (Input.GetKeyDown(KeyCode.W)) { MoveCamera(1); }
        if (Input.GetKeyDown(KeyCode.S)) { MoveCamera(0); }
        if (Input.GetKeyDown(KeyCode.A)) { MoveCamera(3); }
        if (Input.GetKeyDown(KeyCode.D)) { MoveCamera(2); }

        // ī�޶� �̵�
        if (targetPosition != null)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition.position, Time.deltaTime * moveSpeed);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetPosition.rotation, Time.deltaTime * moveSpeed);
        }
    }

    void MoveCamera(int positionIndex)
    {
        if (positionIndex >= 0 && positionIndex < cameraPositions.Length)
        {
            currentPosIndex = positionIndex;
            targetPosition = cameraPositions[currentPosIndex];
        }
    }
}
