using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public DialogueManager dialogueManager;

    void Start()
    {
        // ��ȭ ���� ����
        dialogueManager.dialogueLines = new string[]
        {
            "�� �ٸ� ������... �Ƿ� �������̱�.",
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

        // ��ȭ ����
        dialogueManager.StartDialogue();
    }
}
