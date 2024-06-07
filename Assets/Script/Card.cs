using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int attack;
    public int health;
    public int cost;
    public GameObject cardPrefab; // ������ �ʵ� �߰�
}
