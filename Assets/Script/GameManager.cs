using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardsTransition cardsTransition; // CardsTransition 참조

    void Start()
    {
        // 게임 시작 시 메인 덱에서 카드를 가져옴
        cardsTransition.DrawCardFromMainDeck();
    }
}
