using UnityEngine;

public class DeckVisualizer : MonoBehaviour
{
    public GameObject squirrelDeckPrefab; // �ٶ��� �� ī�� ������
    public GameObject mainDeckPrefab; // ���� �� ī�� ������
    public Transform squirrelDeckTransform; // �ٶ��� �� ��ġ
    public Transform mainDeckTransform; // ���� �� ��ġ
    public CardsTransition cardsTransition; // CardsTransition ����

    private GameObject[] squirrelDeckVisuals; // �ٶ��� �� �ð�ȭ ������Ʈ �迭
    private GameObject[] mainDeckVisuals; // ���� �� �ð�ȭ ������Ʈ �迭

    void Start()
    {
        // �ٶ��� �� �ð�ȭ ������Ʈ �ʱ�ȭ
        squirrelDeckVisuals = new GameObject[20];
        for (int i = 0; i < 20; i++)
        {
            GameObject card = Instantiate(squirrelDeckPrefab, squirrelDeckTransform);
            card.transform.localPosition = new Vector3(0, 0, -i * 0.01f); // Z�� ��ġ ����
            card.transform.localRotation = Quaternion.Euler(0, 0, i * 2.0f); // Z�� ȸ�� ����
            card.SetActive(false);
            squirrelDeckVisuals[i] = card;
        }

        // ���� �� �ð�ȭ ������Ʈ �ʱ�ȭ
        mainDeckVisuals = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            GameObject card = Instantiate(mainDeckPrefab, mainDeckTransform);
            card.transform.localPosition = new Vector3(0, 0, -i * 0.01f); // Z�� ��ġ ����
            card.transform.localRotation = Quaternion.Euler(0, 0, i * 2.0f); // Z�� ȸ�� ����
            card.SetActive(false);
            mainDeckVisuals[i] = card;
        }

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
            }
            else
            {
                mainDeckVisuals[i].SetActive(false);
            }
        }
    }
}
