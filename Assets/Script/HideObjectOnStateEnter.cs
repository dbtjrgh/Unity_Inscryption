using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectOnStateEnter : StateMachineBehaviour
{
    public string objectToHideName; // ���̾��Ű���� ��Ȱ��ȭ�� ������Ʈ�� �̸�

    // OnStateEnter�� ���� �򰡰� ���۵� �� ȣ��˴ϴ�.
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject objectToHide = GameObject.Find(objectToHideName);
        if (objectToHide != null)
        {
            objectToHide.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Object to hide not found: " + objectToHideName);
        }
    }
}
