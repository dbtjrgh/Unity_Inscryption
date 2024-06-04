using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    public Transform[] cameraPositions; // 카메라 위치 배열
    public float moveSpeed = 2.0f; // 카메라 이동 속도
    private int currentPosIndex = 0; // 현재 카메라 위치 인덱스
    private Transform targetPosition; // 목표 위치

    void Start()
    {
        if (cameraPositions.Length > 0)
        {
            // 시작 위치 설정
            currentPosIndex = 0;
            targetPosition = cameraPositions[currentPosIndex];
            transform.position = targetPosition.position;
            transform.rotation = targetPosition.rotation;
        }
    }

    void Update()
    {
        // 키 입력 처리
        if (Input.GetKeyDown(KeyCode.W)) { MoveCamera(1); }
        if (Input.GetKeyDown(KeyCode.S)) { MoveCamera(0); }
        if (Input.GetKeyDown(KeyCode.A)) { MoveCamera(3); }
        if (Input.GetKeyDown(KeyCode.D)) { MoveCamera(2); }

        // 카메라 이동
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
