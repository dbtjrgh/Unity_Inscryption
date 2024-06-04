using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private Dictionary<string, string[]> dialogues = new Dictionary<string, string[]>();

    void Start()
    {
        // ��ȭ ���� ����
        dialogues.Add("ù ��ȭ", new string[]
        {
            "�� �ٸ� ������... �Ƿ� �������̱�.",
            "�� ������ ��Ģ�� �ؾ������� �𸣰ڱ�.",
            "�ٽ� �˷��ֵ��� ����."
        });

        dialogues.Add("�� ��° ��ȭ", new string[]
        {
            "�ٽ� ������.",
            "�̹����� �� ����� ������ ��ٸ��� �ִ�.",
            "�غ� �Ǿ���?"
        });

        // �ʱ� ��ȭ ����
        StartDialogue("ù ��ȭ");

    }

    public void StartDialogue(string dialogueKey)
    {
        if (dialogues.ContainsKey(dialogueKey))
        {
            dialogueManager.dialogueLines = dialogues[dialogueKey];
            dialogueManager.StartDialogue();
        }
        else
        {
            Debug.LogError("��ȭ Ű�� �������� �ʽ��ϴ�: " + dialogueKey);
        }
    }

    // ���� ��� �ٸ� �̺�Ʈ�� ���ǿ� ���� ��ȭ�� �����ϰ� �����ϴ� �޼���
    public void TriggerNextDialogue()
    {
        StartDialogue("�� ��° ��ȭ");
    }
}
