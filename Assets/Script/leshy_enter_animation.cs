using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leshy_enter_animation : MonoBehaviour
{
    public Animator animator; // Animator 컴포넌트
    public GameObject uiPanel; // UI 패널 (대화창)
    public DialogueManager dialogueManager; // 대화 관리 스크립트

    private bool animationEnded = false; // 애니메이션 종료 확인 플래그

    void Start()
    {
        // UI 패널과 모든 자식을 비활성화
        Debug.Log("Deactivating UI panel and all children.");
        SetActiveRecursively(uiPanel, false);
        animator.SetTrigger("enter"); // 특정 애니메이션 트리거 설정
    }

    void Update()
    {
        // 애니메이션 상태가 Idle로 전환되었는지 확인
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("idle") && !animationEnded)
        {
            animationEnded = true;
            OnAnimationEnd();
        }
    }

    public void OnAnimationEnd()
    {
        Debug.Log("Animation ended"); // 디버그 로그로 이벤트 확인

        // UI 패널과 모든 자식을 활성화
        SetActiveRecursively(uiPanel, true);
        Debug.Log("UI panel and all children activated.");

        // 특정 자식 텍스트 오브젝트 활성화
        Transform targetTextTransform = uiPanel.transform.Find("TextDisplayer/TextCanvas/TextFitter/DialogueText");
        if (targetTextTransform != null)
        {
            targetTextTransform.gameObject.SetActive(true);
            Debug.Log("Target text object activated.");
        }
        else
        {
            Debug.LogError("Target text object not found");
        }

        // 대화 시작
        dialogueManager.StartDialogue();
    }

    private void SetActiveRecursively(GameObject obj, bool state)
    {
        if (obj == null) return;

        foreach (Transform child in obj.transform)
        {
            SetActiveRecursively(child.gameObject, state);
        }

        obj.SetActive(state);
    }
}