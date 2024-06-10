using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    // 전환할 목표 씬의 이름
    public string targetScene;
    // 거리 계산을 위한 목표 오브젝트의 위치
    public Transform targetObject;
    // 거리 임계값
    public float threshold = 0.1f;
    // 씬 전환 전 대기할 시간
    public float delay = 3.0f;

    // 씬 전환 중인지 여부를 저장하는 플래그
    private bool isTransitioning = false;

    // 매 프레임마다 호출되는 메서드
    void Update()
    {
        // 씬 전환 중이 아니고, 현재 오브젝트와 목표 오브젝트 간의 거리가 임계값 이하일 때
        if (!isTransitioning && Vector3.Distance(transform.position, targetObject.position) < threshold)
        {
            // 씬 전환 코루틴 시작
            StartCoroutine(TransitionAfterDelay());
        }
    }

    // 딜레이 후 씬 전환을 수행하는 코루틴
    private IEnumerator TransitionAfterDelay()
    {
        // 씬 전환 중으로 플래그 설정
        isTransitioning = true;
        // 지정된 시간만큼 대기
        yield return new WaitForSeconds(delay);
        // 새로운 씬 로드
        SceneManager.LoadScene(targetScene);
    }
}
