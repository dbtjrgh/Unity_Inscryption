using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leshy_enter_animation : MonoBehaviour
{
    public Animator animator; // Animator ������Ʈ
    public GameObject uiPanel; // UI �г� (��ȭâ)
    public DialogueManager dialogueManager; // ��ȭ ���� ��ũ��Ʈ

    private bool animationEnded = false; // �ִϸ��̼� ���� Ȯ�� �÷���

    void Start()
    {
        // UI �гΰ� ��� �ڽ��� ��Ȱ��ȭ
        Debug.Log("Deactivating UI panel and all children.");
        SetActiveRecursively(uiPanel, false);
        animator.SetTrigger("enter"); // Ư�� �ִϸ��̼� Ʈ���� ����
    }

    void Update()
    {
        // �ִϸ��̼� ���°� Idle�� ��ȯ�Ǿ����� Ȯ��
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        if (stateInfo.IsName("idle") && !animationEnded)
        {
            animationEnded = true;
            OnAnimationEnd();
        }
    }

    public void OnAnimationEnd()
    {
        Debug.Log("Animation ended"); // ����� �α׷� �̺�Ʈ Ȯ��

        // UI �гΰ� ��� �ڽ��� Ȱ��ȭ
        SetActiveRecursively(uiPanel, true);
        Debug.Log("UI panel and all children activated.");

        // Ư�� �ڽ� �ؽ�Ʈ ������Ʈ Ȱ��ȭ
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

        // ��ȭ ����
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