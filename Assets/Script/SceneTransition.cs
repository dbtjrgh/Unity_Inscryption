using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // ��ȯ�� ��ǥ ���� �̸�
    public string targetScene;
    // �Ÿ� ����� ���� ��ǥ ������Ʈ�� ��ġ
    public Transform targetObject;
    // �Ÿ� �Ӱ谪
    public float threshold = 0.1f;
    // �� ��ȯ �� ����� �ð�
    public float delay = 3.0f;

    // �� ��ȯ ������ ���θ� �����ϴ� �÷���
    private bool isTransitioning = false;

    // �� �����Ӹ��� ȣ��Ǵ� �޼���
    void Update()
    {
        // �� ��ȯ ���� �ƴϰ�, ���� ������Ʈ�� ��ǥ ������Ʈ ���� �Ÿ��� �Ӱ谪 ������ ��
        if (!isTransitioning && Vector3.Distance(transform.position, targetObject.position) < threshold)
        {
            // �� ��ȯ �ڷ�ƾ ����
            StartCoroutine(TransitionAfterDelay());
        }
    }

    // ������ �� �� ��ȯ�� �����ϴ� �ڷ�ƾ
    private IEnumerator TransitionAfterDelay()
    {
        // �� ��ȯ ������ �÷��� ����
        isTransitioning = true;
        // ������ �ð���ŭ ���
        yield return new WaitForSeconds(delay);
        // ���ο� �� �ε�
        SceneManager.LoadScene(targetScene);
    }
}
