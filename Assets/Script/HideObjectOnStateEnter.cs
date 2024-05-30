using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideObjectOnStateEnter : StateMachineBehaviour
{
    public string objectToHideName; // 하이어라키에서 비활성화할 오브젝트의 이름

    // OnStateEnter는 상태 평가가 시작될 때 호출됩니다.
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
