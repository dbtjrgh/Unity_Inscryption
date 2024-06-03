using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void Start()
    {
        // 대화 내용 설정
        dialogueManager.dialogueLines = new string[]
        {
            "또 다른 도전자... 실로 오랜만이군.",
            "Welcome to our village.",
            "It's a beautiful day today.",
            "Have you met the village chief?",
            "He has some important tasks for you.",
            "The village is peaceful thanks to his leadership.",
            "Feel free to explore around.",
            "Our villagers are friendly and helpful.",
            "Let us know if you need anything.",
            "Safe travels, and have a great adventure!"
        };

        // 대화 시작
        dialogueManager.StartDialogue();
    }
}
