using System.Collections.Generic;
using UnityEngine;

public class CardsTransition : MonoBehaviour
{
    public List<Card> mainDeck = new List<Card>();
    public List<Card> squirrelDeck = new List<Card>();
    public Transform[] handRows; // Row(1)~(4)
    public int maxHandSize = 20; // �� Row�� �ִ� ī�� ��
    public DeckVisualizer deckVisualizer; // DeckVisualizer ����
    public Transform playerHandTransform; // �÷��̾� ���� ��ġ
    public float cardSpacing = 0.5f; // ī�� ����
    public float cardAngle = 10f; // ī�� ȸ�� ����

    private List<GameObject> playerHand = new List<GameObject>(); // �÷��̾� ���п� �ִ� ī���
    private Dictionary<string, int> drawnCards = new Dictionary<string, int>(); // ī�� ��ο� Ƚ�� ����

    void Start()
    {
        InitializeDecks();
        ClearPlayerHand(); // �տ� �ִ� ī�� �ʱ�ȭ
    }

    void InitializeDecks()
    {
        // ���� �� �ʱ�ȭ
        AddCardToDeck(mainDeck, "Wolf", 2);
        AddCardToDeck(mainDeck, "Turtle", 1);
        AddCardToDeck(mainDeck, "Dambi", 1);

        // �ٶ��� �� �ʱ�ȭ
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
            Destroy(cardGO); // �տ� �ִ� ī�� ����
        }
        playerHand.Clear(); // ����Ʈ ����
    }

    public void DrawCardFromMainDeck()
    {
        if (mainDeck.Count > 0)
        {
            Card card = mainDeck[mainDeck.Count - 1]; // ���� ���� �� ���� �ִ� ī��
            mainDeck.RemoveAt(mainDeck.Count - 1);
            MoveCardToHand(card);
            deckVisualizer.UpdateDeckVisuals(); // �� �ð�ȭ ������Ʈ
        }
        else
        {
            Debug.Log("No more cards to draw from the main deck.");
        }
    }

    public void DrawCardFromSquirrelDeck()
    {
        // squirrelDeck���� ī�带 ��������
        if (squirrelDeck.Count > 0)
        {
            Card drawnCard = squirrelDeck[squirrelDeck.Count - 1]; // ���� ��  �� ī��
            squirrelDeck.RemoveAt(squirrelDeck.Count - 1);

            // ������ ī�带 �տ� �߰��ϱ�
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

        // ī�� �յ� ���� (Y������ 180�� ȸ��)
        cardGO.transform.Rotate(0f, 180f, 0f);

        // ���п� �ִ� ī��� ����Ʈ�� �߰�
        playerHand.Add(cardGO);

        // ī���� ��ġ�� ȸ�� ����
        UpdateHandPosition();
    }

    void UpdateHandPosition()
    {
        for (int i = 0; i < playerHand.Count; i++)
        {
            float xOffset = i * cardSpacing;
            float angleOffset = i * cardAngle - ((playerHand.Count - 1) * cardAngle / 2);

            playerHand[i].transform.localPosition = new Vector3(xOffset, 0, 0);
            playerHand[i].transform.localRotation = Quaternion.Euler(0, 180f, angleOffset); // Y������ 180�� ȸ��
        }
    }
}
