using UnityEngine;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    public GameObject npc; // NPC 오브젝트
    public GameObject uiPanel; // UI 패널
    public Transform finalPosition; // 애니메이션이 끝날 때 오브젝트가 위치할 위치

    void Start()
    {
        uiPanel.SetActive(false); // UI 패널을 시작 시 비활성화
    }

    // 애니메이션 이벤트에서 호출될 메서드
    public void OnAnimationEnd()
    {
        transform.position = finalPosition.position; // 오브젝트를 최종 위치로 이동
        ShowNPCDialogue();
    }

    void ShowNPCDialogue()
    {
        // NPC의 대화 로직 구현 (여기서는 UI 패널을 활성화하는 예시)
        uiPanel.SetActive(true);
        // 추가적으로 NPC의 대화 내용을 설정하거나 애니메이션을 재생할 수 있습니다.
    }
}
