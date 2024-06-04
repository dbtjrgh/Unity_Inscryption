using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    private Dictionary<string, string[]> dialogues = new Dictionary<string, string[]>();

    void Start()
    {
        // 대화 내용 설정
        dialogues.Add("첫 대화", new string[]
        {
            "또 다른 도전자... 실로 오랜만이군.",
            "이 게임의 규칙을 잊었을지도 모르겠군.",
            "다시 알려주도록 하지."
        });

        dialogues.Add("두 번째 대화", new string[]
        {
            "다시 만났군.",
            "이번에는 더 어려운 도전이 기다리고 있다.",
            "준비가 되었나?"
        });

        // 초기 대화 시작
        StartDialogue("첫 대화");

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
            Debug.LogError("대화 키가 존재하지 않습니다: " + dialogueKey);
        }
    }

    // 예를 들어 다른 이벤트나 조건에 따라 대화를 변경하고 시작하는 메서드
    public void TriggerNextDialogue()
    {
        StartDialogue("두 번째 대화");
    }
}
