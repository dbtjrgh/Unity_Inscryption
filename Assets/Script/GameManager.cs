using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CardDeck playerDeck;
    public CardsTransition playerHand;

    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        playerDeck.InitializeDecks();
        playerHand.DrawInitialHand();
    }
}
