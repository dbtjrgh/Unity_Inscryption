using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CardField : MonoBehaviour, IDropHandler
{
    public List<GameObject> fieldCards = new List<GameObject>();

    public void OnDrop(PointerEventData eventData)
    {
        GameObject droppedCard = eventData.pointerDrag;
        if (droppedCard != null && droppedCard.GetComponent<CardDisplay>() != null)
        {
            fieldCards.Add(droppedCard);
            droppedCard.transform.SetParent(transform);
            // 추가적으로 카드 배치 후 필요한 처리
        }
    }
}
