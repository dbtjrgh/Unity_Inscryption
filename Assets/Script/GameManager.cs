using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardsTransition cardsTransition; // CardsTransition ����

    void Start()
    {
        // ���� ���� �� ���� ������ ī�带 ������
        cardsTransition.DrawCardFromMainDeck();
    }
}
