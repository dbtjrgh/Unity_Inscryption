using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToActivate; // Ȱ��ȭ�� ������Ʈ�� �ν����Ϳ��� ����

    void Start()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // �ʱ⿡�� ��Ȱ��ȭ ���·� ����
        }
    }

    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.transform == transform)
            {
                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(true); // Ŀ���� ������Ʈ ���� ���� �� Ȱ��ȭ
                }
            }
            else
            {
                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(false); // Ŀ���� ������Ʈ ���� ���� �� ��Ȱ��ȭ
                }
            }
        }
        else
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false); // Ŀ���� ������Ʈ ���� ���� �� ��Ȱ��ȭ
            }
        }
    }
}
