using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // 대화 텍스트 UI
    public string[] dialogueLines; // 대화 내용
    private int currentLineIndex = 0;

    public GameObject objectToControl_1; // 텍스트 상태에 따라 활성화/비활성화할 오브젝트
    public GameObject objectToControl_2; // 텍스트 상태에 따라 활성화/비활성화할 오브젝트

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
        dialogueText.text = ""; // 대화 종료 시 텍스트 비우기
        UpdateObjectState();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // 마우스 클릭 감지
        {
            DisplayNextLine();
        }
    }

    // 텍스트 상태에 따라 오브젝트의 활성화 상태를 업데이트하는 메서드
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
