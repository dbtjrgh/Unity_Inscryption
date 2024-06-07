using System.Collections.Generic;
using UnityEngine;

public class CardDeck : MonoBehaviour
{
    public List<Card> mainDeck = new List<Card>();
    public List<Card> squirrelDeck = new List<Card>();

    void Start()
    {
        InitializeDecks();
    }

    public void InitializeDecks()
    {
        // ∏ﬁ¿Œ µ¶ √ ±‚»≠
        mainDeck.Add(Resources.Load<Card>("Cards/Wolf"));
        mainDeck.Add(Resources.Load<Card>("Cards/Wolf"));
        mainDeck.Add(Resources.Load<Card>("Cards/Turtle"));
        mainDeck.Add(Resources.Load<Card>("Cards/Dambi"));

        // ¥Ÿ∂˜¡„ µ¶ √ ±‚»≠
        for (int i = 0; i < 10; i++)
        {
            squirrelDeck.Add(Resources.Load<Card>("Cards/Squirrel"));
        }

        ShuffleDeck(mainDeck);
        ShuffleDeck(squirrelDeck);
    }

    public void ShuffleDeck(List<Card> deck)
    {
        for (int i = 0; i < deck.Count; i++)
        {
            Card temp = deck[i];
            int randomIndex = Random.Range(i, deck.Count);
            deck[i] = deck[randomIndex];
            deck[randomIndex] = temp;
        }
    }

    public Card DrawCardFromMainDeck()
    {
        if (mainDeck.Count > 0)
        {
            Card drawnCard = mainDeck[0];
            mainDeck.RemoveAt(0);
            return drawnCard;
        }
        return null;
    }

    public Card DrawCardFromSquirrelDeck()
    {
        if (squirrelDeck.Count > 0)
        {
            Card drawnCard = squirrelDeck[0];
            squirrelDeck.RemoveAt(0);
            return drawnCard;
        }
        return null;
    }
}
