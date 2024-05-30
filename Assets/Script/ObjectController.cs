using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Animator animator;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private static GameObject currentlyClickedObject = null; // 현재 클릭된 오브젝트 추적
    private static ObjectController currentlyActiveController = null; // 현재 활성화된 컨트롤러 추적

    [SerializeField]
    private GameObject objectToActivate; // 인스펙터에서 설정할 활성화할 오브젝트
    [SerializeField]
    private string animationStateName = "Idle"; // 인스펙터에서 설정할 애니메이션 상태 이름

    void Start()
    {
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // 초기에는 비활성화 상태로 설정
        }

        if (animator != null)
        {
            animator.enabled = false; // 초기에는 애니메이터 비활성화
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
                if (currentlyClickedObject == null || currentlyClickedObject == gameObject)
                {
                    if (objectToActivate != null)
                    {
                        objectToActivate.SetActive(true); // 커서가 오브젝트 위에 있을 때 활성화
                    }
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (currentlyClickedObject != null && currentlyClickedObject != gameObject)
                    {
                        StopCurrentAnimation(); // 다른 오브젝트 초기화
                    }

                    currentlyClickedObject = gameObject;
                    currentlyActiveController = this;

                    if (animator != null)
                    {
                        animator.enabled = true; // 클릭 시 애니메이터 활성화
                        animator.Play(animationStateName, 0, 0); // 애니메이션을 처음부터 재생

                    }

                    if (objectToActivate != null)
                    {
                        objectToActivate.SetActive(true); // 클릭 시 활성화
                    }
                }
            }
            else
            {
                if (currentlyClickedObject != gameObject && objectToActivate != null)
                {
                    objectToActivate.SetActive(false); // 커서가 오브젝트 위에 없을 때 비활성화
                }
            }
        }
        else
        {
            if (currentlyClickedObject != gameObject && objectToActivate != null)
            {
                objectToActivate.SetActive(false); // 커서가 오브젝트 위에 없을 때 비활성화
            }
        }

        // 화면의 다른 곳을 클릭하면 현재 활성화된 오브젝트 초기화
        if (Input.GetMouseButtonDown(0) && currentlyClickedObject != null && !hit.transform == transform)
        {
            StopCurrentAnimation();
        }
    }

    void StopCurrentAnimation()
    {
        if (currentlyActiveController != null)
        {
            currentlyActiveController.StopAnimation();
        }
    }

    public void StopAnimation()
    {
        if (animator != null)
        {
            animator.enabled = false;
        }

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // 오브젝트 비활성화
        }

        // 오브젝트를 초기 위치와 회전으로 되돌림
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        currentlyClickedObject = null;
        currentlyActiveController = null;
    }
}
