using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private Dictionary<string, string[]> dialogues = new Dictionary<string, string[]>();
    private Dictionary<string, GameObject> objectsToActivateByDialogue = new Dictionary<string, GameObject>();

    private GameObject currentObjectToActivate;
    private string currentDialogueKey;

    // Inspector���� ������ ������Ʈ
    public GameObject board; // Ȱ��ȭ�� Board ������Ʈ
    public GameObject anotherObject; // Ȱ��ȭ�� Board ������Ʈ

    void Start()
    {
        // ��ȭ ���� ����
        dialogues.Add("ù ��ȭ", new string[]
        {
            "�� �ٸ� ������... �Ƿ� �������̱�.",
            "�� ������ ��Ģ�� �ؾ������� �𸣰ڱ�.",
            "�ٽ� �˷��ֵ��� ����."
        });

        dialogues.Add("2��° ��ȭ", new string[]
        {
            "�ٶ��� ī�带 ���Ŷ�."
        });

        dialogues.Add("3��° ��ȭ", new string[]
        {
            "���� ��� ���Ŷ�."
        });

        dialogues.Add("4��° ��ȭ", new string[]
        {
            "���� 1�� �ǰ� �ʿ��ϴ�. ����� �ʼ�����."
        });

        dialogues.Add("5��° ��ȭ", new string[]
        {
            "���ο� �����̱�. ��� ���Ŷ�."
        });

        dialogues.Add("6��° ��ȭ", new string[]
        {
            "����� ������� �� �ʿ��ϴ�. ���� ������� �ʴ�."
        });

        dialogues.Add("7��° ��ȭ", new string[]
        {
            "�ٶ��� ī�带 ���Ŷ�."
        });

        dialogues.Add("8��° ��ȭ", new string[]
        {
            "�ٶ��� ī�带 ���Ŷ�."
        });

       

        // ��ȭ �� �̺�Ʈ ����
        dialogueManager.OnDialogueEnd += OnDialogueEnd;

        // ù ��ȭ�� ���� �� Ȱ��ȭ�� ������Ʈ ����
        objectsToActivateByDialogue["ù ��ȭ"] = board;

        // �ʱ� ��ȭ ����
        StartDialogue("ù ��ȭ");

        //StartDialogue("2��° ��ȭ");
        // ����: �ٸ� ��ȭ�� ���� �� Ȱ��ȭ�� ������Ʈ ����
        //objectsToActivateByDialogue["2��° ��ȭ"] = anotherObject;
    }

    public void StartDialogue(string dialogueKey)
    {
        if (dialogues.ContainsKey(dialogueKey))
        {
            currentDialogueKey = dialogueKey;  // ���� ��ȭ Ű ����

            dialogueManager.dialogueLines = dialogues[dialogueKey];
            dialogueManager.StartDialogue();

            // ��ȭ Ű�� ���� Ȱ��ȭ ������Ʈ ����
            if (objectsToActivateByDialogue.ContainsKey(dialogueKey))
            {
                currentObjectToActivate = objectsToActivateByDialogue[dialogueKey];
            }
            else
            {
                currentObjectToActivate = null;
            }
        }
        else
        {
            Debug.LogError("��ȭ Ű�� �������� �ʽ��ϴ�: " + dialogueKey);
        }
    }

    private void OnDialogueEnd()
    {
        Debug.Log("OnDialogueEnd �̺�Ʈ ȣ���: " + currentDialogueKey);

        // ��ȭ�� ���� �� ���� ������ ������Ʈ Ȱ��ȭ
        if (currentObjectToActivate != null)
        {
            Debug.Log("������Ʈ Ȱ��ȭ: " + currentObjectToActivate.name);
            currentObjectToActivate.SetActive(true);
        }
    }

    void OnDestroy()
    {
        dialogueManager.OnDialogueEnd -= OnDialogueEnd;
    }
}
