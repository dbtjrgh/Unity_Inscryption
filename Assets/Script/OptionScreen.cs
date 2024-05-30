using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionScreen : MonoBehaviour
{
    public Transform targetObject;
    public Transform newPosition;
    public GameObject objectToActivate;
    public float threshold = 0.01f;  // �� ������Ʈ�� ������ ��ĥ ���� ������ �Ӱ谪
    public float delayBeforeMove = 3.0f;  // ��ǥ ��ġ ���� �� �̵� �� ��� �ð�
    public float moveDuration = 5.0f;  // �̵� �ð�

    private Vector3 initialPosition;
    private Vector3 targetInitialPosition;
    private bool isTransitioning = false;
    private bool isActivated = false;

    void Start()
    {
        // �ʱ� ��ġ ����
        initialPosition = transform.position;
        targetInitialPosition = targetObject.position;
        objectToActivate.SetActive(false);  // ��Ȱ��ȭ ���·� ����
    }

    void Update()
    {
        // ������Ʈ�� ��ǥ ��ġ�� �����ߴ��� Ȯ��
        if (!isTransitioning && Vector3.Distance(transform.position, targetObject.position) < threshold)
        {
            StartCoroutine(WaitAndMoveObjects());
        }

        // ESC Ű�� ������ �����·� ����
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ResetObjects();
        }
    }

    void OnMouseDown()
    {
        // ��ũ��Ʈ�� ������ ������Ʈ�� Ŭ���ϸ� �����·� ����
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

        // �̵� �Ϸ� �� ������Ʈ Ȱ��ȭ
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
            isTransitioning = false;  // ���� �Ŀ� �ٽ� �̵� �����ϵ���
            StopAllCoroutines();  // ��� �ڷ�ƾ ����
        }
    }
}
