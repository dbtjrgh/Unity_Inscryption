using UnityEngine;

public class ActivateObjectOnEvent : MonoBehaviour
{
    public GameObject objectToActivate;

    // 애니메이션 이벤트에서 호출될 메서드
    public void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
