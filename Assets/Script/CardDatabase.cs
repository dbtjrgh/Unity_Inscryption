using System.Collections.Generic;
using UnityEngine;

public class CardDatabase : MonoBehaviour
{
    public List<Card> allCards;

    void Start()
    {
        LoadAllCards();
    }

    void LoadAllCards()
    {
        allCards = new List<Card>(Resources.LoadAll<Card>("Cards"));
    }
}
