using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScreen : MonoBehaviour
{
    public Transform targetObject;
    public Transform newPosition;
    public GameObject objectToActivate;
    public float threshold = 0.01f;  // 두 오브젝트가 완전히 겹칠 때를 감지할 임계값
    public float delayBeforeMove = 3.0f;  // 목표 위치 도달 후 이동 전 대기 시간
    public float moveDuration = 5.0f;  // 이동 시간

    private Vector3 initialPosition;
    private Vector3 targetInitialPosition;
    private bool isTransitioning = false;
    private bool isActivated = false;

    void Start()
    {
        // 초기 위치 저장
        initialPosition = transform.position;
        targetInitialPosition = targetObject.position;
        objectToActivate.SetActive(false);  // 비활성화 상태로 시작
    }

    void Update()
    {
        // 오브젝트가 목표 위치에 도달했는지 확인
        if (!isTransitioning && Vector3.Distance(transform.position, targetObject.position) < threshold)
        {
            StartCoroutine(WaitAndMoveObjects());
        }

        // ESC 키를 누르면 원상태로 복귀
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetObjects();
        }
    }

    void OnMouseDown()
    {
        // 스크립트를 적용한 오브젝트를 클릭하면 원상태로 복귀
        ResetObjects();
    }

    private IEnumerator WaitAndMoveObjects()
    {
        isTransitioning = true;
        yield return new WaitForSeconds(delayBeforeMove);

        float elapsedTime = 0f;

        Vector3 startPosition = transform.position;
        Vector3 targetStartPosition = targetObject.position;

        while (elapsedTime < moveDuration)
        {
            transform.position = Vector3.Lerp(startPosition, newPosition.position, elapsedTime / moveDuration);
            targetObject.position = Vector3.Lerp(targetStartPosition, newPosition.position, elapsedTime / moveDuration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.position = newPosition.position;
        targetObject.position = newPosition.position;

        // 이동 완료 후 오브젝트 활성화
        objectToActivate.SetActive(true);
        isActivated = true;
        isTransitioning = false;
    }

    private void ResetObjects()
    {
        if (isActivated)
        {
            transform.position = initialPosition;
            targetObject.position = targetInitialPosition;
            objectToActivate.SetActive(false);
            isActivated = false;
            isTransitioning = false;  // 리셋 후에 다시 이동 가능하도록
            StopAllCoroutines();  // 모든 코루틴 중지
        }
    }
}
