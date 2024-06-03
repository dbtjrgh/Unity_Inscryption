using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // ��ȭ �ؽ�Ʈ UI
    public string[] dialogueLines; // ��ȭ ����
    private int currentLineIndex = 0;

    void Start()
    {
        dialogueText.text = "";
    }

    public void StartDialogue()
    {
        currentLineIndex = 0;
        dialogueText.text = dialogueLines[currentLineIndex];
    }

    public void DisplayNextLine()
    {
        if (currentLineIndex < dialogueLines.Length - 1)
        {
            currentLineIndex++;
            dialogueText.text = dialogueLines[currentLineIndex];
        }
        else
        {
            EndDialogue();
        }
    }

    void EndDialogue()
    {
        dialogueText.text = ""; // ��ȭ ���� �� �ؽ�Ʈ ����
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // ���콺 Ŭ�� ����
        {
            DisplayNextLine();
        }
    }
}
