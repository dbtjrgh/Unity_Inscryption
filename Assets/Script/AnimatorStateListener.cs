using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorStateListener : StateMachineBehaviour
{
    public string targetStateName = "show";
    private CameraClearFlagsChanger cameraClearFlagsChanger;

    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (cameraClearFlagsChanger == null)
        {
            cameraClearFlagsChanger = FindObjectOfType<CameraClearFlagsChanger>();
        }
    }

    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (stateInfo.IsName(targetStateName) && cameraClearFlagsChanger != null)
        {
            cameraClearFlagsChanger.ChangeClearFlagsToSolidColor();
        }
    }
}
