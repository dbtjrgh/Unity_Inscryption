using System.Collections.Generic;
using UnityEngine;

public class CardsTransition : MonoBehaviour
{
    public List<Card> mainDeck = new List<Card>();
    public List<Card> squirrelDeck = new List<Card>();
    public Transform[] handRows; // Row(1)~(4)
    public int maxHandSize = 20; // 각 Row별 최대 카드 수
    public DeckVisualizer deckVisualizer; // DeckVisualizer 참조
    public Transform playerHandTransform; // 플레이어 손패 위치
    public float cardSpacing = 0.5f; // 카드 간격
    public float cardAngle = 10f; // 카드 회전 각도

    private List<GameObject> playerHand = new List<GameObject>(); // 플레이어 손패에 있는 카드들
    private Dictionary<string, int> drawnCards = new Dictionary<string, int>(); // 카드 드로우 횟수 추적

    void Start()
    {
        InitializeDecks();
        ClearPlayerHand(); // 손에 있는 카드 초기화
    }

    void InitializeDecks()
    {
        // 메인 덱 초기화
        AddCardToDeck(mainDeck, "Wolf", 2);
        AddCardToDeck(mainDeck, "Turtle", 1);
        AddCardToDeck(mainDeck, "Dambi", 1);

        // 다람쥐 덱 초기화
        for (int i = 0; i < 20; i++)
        {
            squirrelDeck.Add(Resources.Load<Card>("Cards/Squirrel"));
        }

        ShuffleDeck(mainDeck);
        ShuffleDeck(squirrelDeck);
        deckVisualizer.UpdateDeckVisuals();
    }

    void AddCardToDeck(List<Card> deck, string cardName, int count)
    {
        Card card = Resources.Load<Card>($"Cards/{cardName}");
        for (int i = 0; i < count; i++)
        {
            deck.Add(card);
        }
    }

    void ShuffleDeck(List<Card> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    void ClearPlayerHand()
    {
        foreach (GameObject cardGO in playerHand)
        {
            Destroy(cardGO); // 손에 있는 카드 제거
        }
        playerHand.Clear(); // 리스트 비우기
    }

    public void DrawCardFromMainDeck()
    {
        if (mainDeck.Count > 0)
        {
            Card card = mainDeck[mainDeck.Count - 1]; // 메인 덱의 맨 위에 있는 카드
            mainDeck.RemoveAt(mainDeck.Count - 1);
            MoveCardToHand(card);
            deckVisualizer.UpdateDeckVisuals(); // 덱 시각화 업데이트
        }
        else
        {
            Debug.Log("No more cards to draw from the main deck.");
        }
    }

    public void DrawCardFromSquirrelDeck()
    {
        // squirrelDeck에서 카드를 가져오기
        if (squirrelDeck.Count > 0)
        {
            Card drawnCard = squirrelDeck[squirrelDeck.Count - 1]; // 가장 위  의 카드
            squirrelDeck.RemoveAt(squirrelDeck.Count - 1);

            // 가져온 카드를 손에 추가하기
            MoveCardToHand(drawnCard);
        }
        else
        {
            Debug.Log("No more cards to draw from the squirrel deck.");
        }
    }


    public void MoveCardToHand(Card card)
    {
        if (playerHand.Count >= maxHandSize)
        {
            Debug.Log("Maximum hand size reached. Cannot add more cards.");
            return;
        }

        GameObject cardGO = Instantiate(card.cardPrefab, playerHandTransform);
        CardDisplay cardDisplay = cardGO.GetComponent<CardDisplay>();
        cardDisplay.card = card;
        cardDisplay.DisplayCard();

        // 카드 앞뒤 반전 (Y축으로 180도 회전)
        cardGO.transform.Rotate(0f, 180f, 0f);

        // 손패에 있는 카드들 리스트에 추가
        playerHand.Add(cardGO);

        // 카드의 위치와 회전 설정
        UpdateHandPosition();
    }

    void UpdateHandPosition()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            float xOffset = i * cardSpacing;
            float angleOffset = i * cardAngle - ((playerHand.Count - 1) * cardAngle / 2);

            playerHand[i].transform.localPosition = new Vector3(xOffset, 0, 0);
            playerHand[i].transform.localRotation = Quaternion.Euler(0, 180f, angleOffset); // Y축으로 180도 회전
        }
    }
}
