using System.Collections.Generic;
using UnityEngine;

public class CardsTransition : MonoBehaviour
{
    public List<Card> mainDeck = new List<Card>();
    public List<Card> squirrelDeck = new List<Card>();
    public Transform[] handRows; // Row(1)~(4)
    public int maxHandSize = 20; // 각 Row별 최대 카드 수
    public DeckVisualizer deckVisualizer; // DeckVisualizer 참조

    void Start()
    {
        InitializeDecks();
        DrawInitialHand();
    }

    void InitializeDecks()
    {
        // 메인 덱 초기화
        mainDeck.Add(Resources.Load<Card>("Cards/Wolf"));
        mainDeck.Add(Resources.Load<Card>("Cards/Wolf"));
        mainDeck.Add(Resources.Load<Card>("Cards/Turtle"));
        mainDeck.Add(Resources.Load<Card>("Cards/Dambi"));

        // 다람쥐 덱 초기화
        for (int i = 0; i < 20; i++)
        {
            squirrelDeck.Add(Resources.Load<Card>("Cards/Squirrel"));
        }

        ShuffleDeck(mainDeck);
        ShuffleDeck(squirrelDeck);
        deckVisualizer.UpdateDeckVisuals();
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

    public void DrawInitialHand()
    {
        for (int i = 0; i < 4; i++)
        {
            DrawCardFromMainDeck();
        }
    }

    public void DrawCardFromMainDeck()
    {
        if (mainDeck.Count > 0)
        {
            Card drawnCard = mainDeck[0];
            mainDeck.RemoveAt(0);
            AddCardToHand(drawnCard);
            deckVisualizer.UpdateDeckVisuals(); // 덱 시각화 업데이트
        }
    }

    public void DrawCardFromSquirrelDeck()
    {
        if (squirrelDeck.Count > 0)
        {
            Card drawnCard = squirrelDeck[0];
            squirrelDeck.RemoveAt(0);
            AddCardToHand(drawnCard);
            deckVisualizer.UpdateDeckVisuals(); // 덱 시각화 업데이트
        }
    }

    void AddCardToHand(Card card)
    {
        foreach (Transform row in handRows)
        {
            if (row.childCount < maxHandSize)
            {
                GameObject cardGO = Instantiate(card.cardPrefab, row); // 각 카드의 프리팹을 사용
                CardDisplay cardDisplay = cardGO.GetComponent<CardDisplay>();
                cardDisplay.card = card;
                cardDisplay.DisplayCard();
                return;
            }
        }
    }
}
