using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public Text nameText;
    public Text attackText;
    public Text healthText;

    void Start()
    {
        DisplayCard();
    }

    public void DisplayCard()
    {
        nameText.text = card.cardName;
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();
    }
}
