using UnityEngine;

public class DeckClickHandler : MonoBehaviour
{
    public enum DeckType { MainDeck, SquirrelDeck }
    public DeckType deckType;
    public CardsTransition cardsTransition;

    void OnMouseDown()
    {
        if (cardsTransition == null)
        {
            Debug.LogError("CardsTransition reference is not set!");
            return;
        }

        if (deckType == DeckType.MainDeck)
        {
            cardsTransition.DrawCardFromMainDeck();
        }
        else if (deckType == DeckType.SquirrelDeck)
        {
            cardsTransition.DrawCardFromSquirrelDeck();
        }
    }
}
