using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTriggerOnKey : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "NextStateTrigger";
    public string requiredAnimationState = "show"; // 완료되어야 하는 애니메이션 상태 이름

    private bool canTriggerNext = false;

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 현재 애니메이션 상태가 'show'가 아닌지 확인
        if (!stateInfo.IsName(requiredAnimationState))
        {
            canTriggerNext = true;
        }
        else
        {
            canTriggerNext = false;
        }

        // 'show' 애니메이션이 아닌 상태일 때만 입력을 받아서 트리거 활성화
        if (canTriggerNext && (Input.anyKeyDown || Input.GetMouseButtonDown(0)))
        {
            animator.SetTrigger(triggerName);
            canTriggerNext = false; // 트리거 후 다시 false로 설정하여 한 번만 트리거되게 함
        }
    }
}
