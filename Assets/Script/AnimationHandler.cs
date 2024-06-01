using UnityEngine;
using UnityEngine.UI;

public class AnimationHandler : MonoBehaviour
{
    public GameObject npc; // NPC ������Ʈ
    public GameObject uiPanel; // UI �г�
    public Transform finalPosition; // �ִϸ��̼��� ���� �� ������Ʈ�� ��ġ�� ��ġ

    void Start()
    {
        uiPanel.SetActive(false); // UI �г��� ���� �� ��Ȱ��ȭ
    }

    // �ִϸ��̼� �̺�Ʈ���� ȣ��� �޼���
    public void OnAnimationEnd()
    {
        transform.position = finalPosition.position; // ������Ʈ�� ���� ��ġ�� �̵�
        ShowNPCDialogue();
    }

    void ShowNPCDialogue()
    {
        // NPC�� ��ȭ ���� ���� (���⼭�� UI �г��� Ȱ��ȭ�ϴ� ����)
        uiPanel.SetActive(true);
        // �߰������� NPC�� ��ȭ ������ �����ϰų� �ִϸ��̼��� ����� �� �ֽ��ϴ�.
    }
}
