using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // ��ȭ �ؽ�Ʈ UI
    public string[] dialogueLines; // ��ȭ ����
    private int currentLineIndex = 0;

    public GameObject objectToControl_1; // �ؽ�Ʈ ���¿� ���� Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ
    public GameObject objectToControl_2; // �ؽ�Ʈ ���¿� ���� Ȱ��ȭ/��Ȱ��ȭ�� ������Ʈ

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
        if (objectToControl_1 != null)
        {
            objectToControl_1.SetActive(!string.IsNullOrEmpty(dialogueText.text));
        }
        if (objectToControl_2 != null)
        {
            objectToControl_2.SetActive(string.IsNullOrEmpty(dialogueText.text));
        }
    }
}
