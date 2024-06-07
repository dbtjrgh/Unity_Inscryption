using UnityEngine;

public class DeckVisualizer : MonoBehaviour
{
    public GameObject squirrelDeckPrefab; // 다람쥐 덱 카드 프리팹
    public GameObject mainDeckPrefab; // 메인 덱 카드 프리팹
    public Transform squirrelDeckTransform; // 다람쥐 덱 위치
    public Transform mainDeckTransform; // 메인 덱 위치
    public CardsTransition cardsTransition; // CardsTransition 참조

    private GameObject[] squirrelDeckVisuals; // 다람쥐 덱 시각화 오브젝트 배열
    private GameObject[] mainDeckVisuals; // 메인 덱 시각화 오브젝트 배열

    void Start()
    {
        // 다람쥐 덱 시각화 오브젝트 초기화
        squirrelDeckVisuals = new GameObject[20];
        for (int i = 0; i < 20; i++)
        {
            GameObject card = Instantiate(squirrelDeckPrefab, squirrelDeckTransform);
            card.transform.localPosition = new Vector3(0, 0, -i * 0.01f); // Z축 위치 조정
            card.transform.localRotation = Quaternion.Euler(0, 0, i * 2.0f); // Z축 회전 조정
            card.SetActive(false);
            squirrelDeckVisuals[i] = card;
        }

        // 메인 덱 시각화 오브젝트 초기화
        mainDeckVisuals = new GameObject[4];
        for (int i = 0; i < 4; i++)
        {
            GameObject card = Instantiate(mainDeckPrefab, mainDeckTransform);
            card.transform.localPosition = new Vector3(0, 0, -i * 0.01f); // Z축 위치 조정
            card.transform.localRotation = Quaternion.Euler(0, 0, i * 2.0f); // Z축 회전 조정
            card.SetActive(false);
            mainDeckVisuals[i] = card;
        }

        UpdateDeckVisuals();
    }

    public void UpdateDeckVisuals()
    {
        // 다람쥐 덱 시각화 업데이트
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

        // 메인 덱 시각화 업데이트
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
