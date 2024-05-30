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
        // 유니티 에디터에서는 실제로 게임이 종료되지 않으므로, 에디터를 중지하도록 합니다.
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
