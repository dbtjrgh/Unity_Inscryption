using UnityEngine;

public class ActivateObjectOnEvent : MonoBehaviour
{
    public GameObject objectToActivate;

    // �ִϸ��̼� �̺�Ʈ���� ȣ��� �޼���
    public void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true);
        }
    }
}
