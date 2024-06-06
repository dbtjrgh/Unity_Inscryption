using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // ��ȭ �ؽ�Ʈ UI
    public string[] dialogueLines; // ��ȭ ����
    private int currentLineIndex = 0;

    public GameObject objectToControl_1; // �ؽ�Ʈ ���¿� ���� Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ
    public GameObject objectToControl_2; // �ؽ�Ʈ ���¿� ���� Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ
    public GameObject objectToControl_3; // �ؽ�Ʈ ���¿� ���� Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ
    public bool controlOrder; // true�� objectToControl_2�� ����, false�� objectToControl_3�� ����

    public event Action OnDialogueEnd; // ��ȭ ���� �̺�Ʈ

    void Start()
    {
        dialogueText.text = "";
        UpdateObjectState();
    }

    public void StartDialogue()
    {
        currentLineIndex = 0;
        dialogueText.text = dialogueLines[currentLineIndex];
        UpdateObjectState();
    }

    public void DisplayNextLine()
    {
        if (currentLineIndex < dialogueLines.Length - 1)
        {
            currentLineIndex++;
            dialogueText.text = dialogueLines[currentLineIndex];
            UpdateObjectState();
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueText.text = ""; // ��ȭ ���� �� �ؽ�Ʈ ����
        UpdateObjectState();
        OnDialogueEnd?.Invoke(); // ��ȭ ���� �̺�Ʈ ȣ��
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ����
        {
            DisplayNextLine();
        }
    }

    // �ؽ�Ʈ ���¿� ���� ������Ʈ�� Ȱ��ȭ ���¸� ������Ʈ�ϴ� �޼���
    void UpdateObjectState()
    {
        // �ؽ�Ʈ�� ���� �� �׻� Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ ó��
        if (objectToControl_1 != null)
        {
            objectToControl_1.SetActive(!string.IsNullOrEmpty(dialogueText.text));
        }

        // ��ȭ�� ���� ���� �� objectToControl_3 Ȱ��ȭ, ���� �� objectToControl_2 Ȱ��ȭ
        if (string.IsNullOrEmpty(dialogueText.text))
        {
            if (objectToControl_2 != null)
            {
                objectToControl_2.SetActive(true);
            }
            if (objectToControl_3 != null)
            {
                objectToControl_3.SetActive(false);
            }
        }
        else
        {
            if (objectToControl_2 != null)
            {
                objectToControl_2.SetActive(false);
            }
            if (objectToControl_3 != null)
            {
                objectToControl_3.SetActive(true);
            }
        }
    }
}
