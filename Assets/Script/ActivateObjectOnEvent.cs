using UnityEngine;

public class ActivateObjectOnEvent : MonoBehaviour
{
    public GameObject objectToActivate;
    public GameObject objectToDisable;

    // �ִϸ��̼� �̺�Ʈ���� ȣ��� �޼���
    public void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
        if (objectToDisable != null)
        {
            objectToDisable.SetActive(false);
        }
    }
}
