using UnityEngine;

[CreateAssetMenu(fileName = "NewCard", menuName = "Card")]
public class Card : ScriptableObject
{
    public string cardName;
    public int attack;
    public int health;
    public int cost;
    public Sprite artwork;
    public GameObject cardPrefab;

    public int maxDrawCount = 1; // 추가: 각 카드의 최대 드로우 가능 수
}
