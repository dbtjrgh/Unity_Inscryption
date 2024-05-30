using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameQuit : MonoBehaviour
{
    public Transform targetObject;
    public float threshold = 0.1f;
    public float delay = 3.0f;

    private bool isTransitioning = false;

    void Update()
    {
        if (!isTransitioning && Vector3.Distance(transform.position, targetObject.position) < threshold)
        {
            StartCoroutine(QuitAfterDelay());
        }
    }

    private IEnumerator QuitAfterDelay()
    {
        isTransitioning = true;
        yield return new WaitForSeconds(delay);
        Application.Quit();
#if UNITY_EDITOR
        // ����Ƽ �����Ϳ����� ������ ������ ������� �����Ƿ�, �����͸� �����ϵ��� �մϴ�.
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
