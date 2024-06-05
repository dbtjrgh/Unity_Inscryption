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

    // Inspector에서 설정할 오브젝트
    public GameObject board; // 활성화할 Board 오브젝트
    public GameObject anotherObject; // 활성화할 Board 오브젝트

    void Start()
    {
        // 대화 내용 설정
        dialogues.Add("첫 대화", new string[]
        {
            "또 다른 도전자... 실로 오랜만이군.",
            "이 게임의 규칙을 잊었을지도 모르겠군.",
            "다시 알려주도록 하지."
        });

        dialogues.Add("2번째 대화", new string[]
        {
            "다람쥐 카드를 내거라."
        });

        dialogues.Add("3번째 대화", new string[]
        {
            "이제 담비를 내거라."
        });

        dialogues.Add("4번째 대화", new string[]
        {
            "담비는 1의 피가 필요하다. 희생이 필수이지."
        });

        dialogues.Add("5번째 대화", new string[]
        {
            "명예로운 죽음이군. 담비를 내거라."
        });

        dialogues.Add("6번째 대화", new string[]
        {
            "늑대는 희생양이 둘 필요하다. 아직 충분하지 않다."
        });

        dialogues.Add("7번째 대화", new string[]
        {
            "다람쥐 카드를 내거라."
        });

        dialogues.Add("8번째 대화", new string[]
        {
            "다람쥐 카드를 내거라."
        });

       

        // 대화 끝 이벤트 구독
        dialogueManager.OnDialogueEnd += OnDialogueEnd;

        // 첫 대화가 끝난 후 활성화할 오브젝트 설정
        objectsToActivateByDialogue["첫 대화"] = board;

        // 초기 대화 설정
        StartDialogue("첫 대화");

        //StartDialogue("2번째 대화");
        // 예시: 다른 대화가 끝난 후 활성화할 오브젝트 설정
        //objectsToActivateByDialogue["2번째 대화"] = anotherObject;
    }

    public void StartDialogue(string dialogueKey)
    {
        if (dialogues.ContainsKey(dialogueKey))
        {
            currentDialogueKey = dialogueKey;  // 현재 대화 키 저장

            dialogueManager.dialogueLines = dialogues[dialogueKey];
            dialogueManager.StartDialogue();

            // 대화 키에 따른 활성화 오브젝트 설정
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
            Debug.LogError("대화 키가 존재하지 않습니다: " + dialogueKey);
        }
    }

    private void OnDialogueEnd()
    {
        Debug.Log("OnDialogueEnd 이벤트 호출됨: " + currentDialogueKey);

        // 대화가 끝난 후 현재 설정된 오브젝트 활성화
        if (currentObjectToActivate != null)
        {
            Debug.Log("오브젝트 활성화: " + currentObjectToActivate.name);
            currentObjectToActivate.SetActive(true);
        }
    }

    void OnDestroy()
    {
        dialogueManager.OnDialogueEnd -= OnDialogueEnd;
    }
}
