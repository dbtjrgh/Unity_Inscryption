using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTriggerOnKey : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "NextStateTrigger";
    public string requiredAnimationState = "show"; // �Ϸ�Ǿ�� �ϴ� �ִϸ��̼� ���� �̸�

    private bool canTriggerNext = false;

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // ���� �ִϸ��̼� ���°� 'show'�� �ƴ��� Ȯ��
        if (!stateInfo.IsName(requiredAnimationState))
        {
            canTriggerNext = true;
        }
        else
        {
            canTriggerNext = false;
        }

        // 'show' �ִϸ��̼��� �ƴ� ������ ���� �Է��� �޾Ƽ� Ʈ���� Ȱ��ȭ
        if (canTriggerNext && (Input.anyKeyDown || Input.GetMouseButtonDown(0)))
        {
            animator.SetTrigger(triggerName);
            canTriggerNext = false; // Ʈ���� �� �ٽ� false�� �����Ͽ� �� ���� Ʈ���ŵǰ� ��
        }
    }
}
