using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneTransition : MonoBehaviour
{
    public string targetScene;
    public Transform targetObject;
    public float threshold = 0.1f;
    public float delay = 3.0f;

    private bool isTransitioning = false;

    void Update()
    {
        if (!isTransitioning && Vector3.Distance(transform.position, targetObject.position) < threshold)
        {
            StartCoroutine(TransitionAfterDelay());
        }
    }

    private IEnumerator TransitionAfterDelay()
    {
        isTransitioning = true;
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(targetScene);
    }
}
