using UnityEngine;

public class DeckVisualizer : MonoBehaviour
{
    public GameObject[] squirrelDeckVisuals; // �ٶ��� �� �ð�ȭ ������Ʈ �迭
    public GameObject[] mainDeckVisuals; // ���� �� �ð�ȭ ������Ʈ �迭
    public CardsTransition cardsTransition; // CardsTransition ����

    void Start()
    {
        UpdateDeckVisuals();
    }

    public void UpdateDeckVisuals()
    {
        // �ٶ��� �� �ð�ȭ ������Ʈ
        for (int i = 0; i < squirrelDeckVisuals.Length; i++)
        {
            if (i < cardsTransition.squirrelDeck.Count)
            {
                squirrelDeckVisuals[i].SetActive(true);
                Vector3 position = squirrelDeckVisuals[i].transform.localPosition;
                position.y = i * 0.04f; // Y�� ��ġ ����
                squirrelDeckVisuals[i].transform.localPosition = position;

                Vector3 rotation = squirrelDeckVisuals[i].transform.localEulerAngles;
                rotation.y = i * 2.0f; // Y�� ȸ�� ����
                squirrelDeckVisuals[i].transform.localEulerAngles = rotation;
            }
            else
            {
                squirrelDeckVisuals[i].SetActive(false);
            }
        }

        // ���� �� �ð�ȭ ������Ʈ
        for (int i = 0; i < mainDeckVisuals.Length; i++)
        {
            if (i < cardsTransition.mainDeck.Count)
            {
                mainDeckVisuals[i].SetActive(true);
                Vector3 position = mainDeckVisuals[i].transform.localPosition;
                position.y = i * 0.04f; // Y�� ��ġ ����
                mainDeckVisuals[i].transform.localPosition = position;

                Vector3 rotation = mainDeckVisuals[i].transform.localEulerAngles;
                rotation.y = i * 2.0f; // Y�� ȸ�� ����
                mainDeckVisuals[i].transform.localEulerAngles = rotation;
            }
            else
            {
                mainDeckVisuals[i].SetActive(false);
            }
        }
    }
}
