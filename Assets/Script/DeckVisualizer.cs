using UnityEngine;

public class DeckVisualizer : MonoBehaviour
{
    public GameObject[] squirrelDeckVisuals; // 다람쥐 덱 시각화 오브젝트 배열
    public GameObject[] mainDeckVisuals; // 메인 덱 시각화 오브젝트 배열
    public CardsTransition cardsTransition; // CardsTransition 참조

    void Start()
    {
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
                Vector3 position = squirrelDeckVisuals[i].transform.localPosition;
                position.y = i * 0.04f; // Y축 위치 조정
                squirrelDeckVisuals[i].transform.localPosition = position;

                Vector3 rotation = squirrelDeckVisuals[i].transform.localEulerAngles;
                rotation.y = i * 2.0f; // Y축 회전 조정
                squirrelDeckVisuals[i].transform.localEulerAngles = rotation;
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
                Vector3 position = mainDeckVisuals[i].transform.localPosition;
                position.y = i * 0.04f; // Y축 위치 조정
                mainDeckVisuals[i].transform.localPosition = position;

                Vector3 rotation = mainDeckVisuals[i].transform.localEulerAngles;
                rotation.y = i * 2.0f; // Y축 회전 조정
                mainDeckVisuals[i].transform.localEulerAngles = rotation;
            }
            else
            {
                mainDeckVisuals[i].SetActive(false);
            }
        }
    }
}
