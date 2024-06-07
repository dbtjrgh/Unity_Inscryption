using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Text nameText;
    public Text attackText;
    public Text healthText;
    public Text costText;

    void Start()
    {
        DisplayCard();
    }

    public void DisplayCard()
    {
        if (card != null)
        {
            nameText.text = card.cardName;
            attackText.text = card.attack.ToString();
            healthText.text = card.health.ToString();
            costText.text = card.cost.ToString();
        }
        else
        {
            Debug.LogWarning("Card data is missing!");
        }
    }
}
