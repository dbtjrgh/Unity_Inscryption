using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverActivator : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToActivate; // 활성화할 오브젝트를 인스펙터에서 설정

    void Start()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // 초기에는 비활성화 상태로 설정
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
                    objectToActivate.SetActive(true); // 커서가 오브젝트 위에 있을 때 활성화
                }
            }
            else
            {
                if (objectToActivate != null)
                {
                    objectToActivate.SetActive(false); // 커서가 오브젝트 위에 없을 때 비활성화
                }
            }
        }
        else
        {
            if (objectToActivate != null)
            {
                objectToActivate.SetActive(false); // 커서가 오브젝트 위에 없을 때 비활성화
            }
        }
    }
}
