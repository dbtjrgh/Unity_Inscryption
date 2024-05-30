using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorTriggerOnKey : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "NextStateTrigger";

    void Update()
    {
        if (Input.anyKeyDown || Input.GetMouseButtonDown(0))
        {
            animator.SetTrigger(triggerName);
        }
    }
}
