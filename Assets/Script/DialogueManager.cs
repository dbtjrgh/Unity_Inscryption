using UnityEngine;
using UnityEngine.UI;
using System;

public class DialogueManager : MonoBehaviour
{
    public Text dialogueText; // 대화 텍스트 UI
    public string[] dialogueLines; // 대화 내용
    private int currentLineIndex = 0;

    public GameObject objectToControl_1; // 텍스트 상태에 따라 활성화/비활성화할 오브젝트
    public GameObject objectToControl_2; // 텍스트 상태에 따라 활성화/비활성화할 오브젝트
    public GameObject objectToControl_3; // 텍스트 상태에 따라 활성화/비활성화할 오브젝트
    public bool controlOrder; // true면 objectToControl_2을 먼저, false면 objectToControl_3를 먼저

    public event Action OnDialogueEnd; // 대화 종료 이벤트

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
        OnDialogueEnd?.Invoke(); // 대화 종료 이벤트 호출
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
        // 텍스트가 있을 때 항상 활성화/비활성화할 오브젝트 처리
        if (objectToControl_1 != null)
        {
            objectToControl_1.SetActive(!string.IsNullOrEmpty(dialogueText.text));
        }

        // 대화가 진행 중일 때 objectToControl_3 활성화, 종료 시 objectToControl_2 활성화
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
