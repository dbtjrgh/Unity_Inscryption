using UnityEngine;
using TMPro;

public class CardDisplay : MonoBehaviour
{
    public Card card;
    public TextMeshProUGUI attackText;
    public TextMeshProUGUI healthText;

    void Start()
    {
        DisplayCard();
    }

    public void DisplayCard()
    {
        attackText.text = card.attack.ToString();
        healthText.text = card.health.ToString();
    }
}
