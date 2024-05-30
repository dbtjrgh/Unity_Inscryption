using UnityEngine;

public class ObjectController : MonoBehaviour
{
    private Animator animator;
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private static GameObject currentlyClickedObject = null; // ���� Ŭ���� ������Ʈ ����
    private static ObjectController currentlyActiveController = null; // ���� Ȱ��ȭ�� ��Ʈ�ѷ� ����

    [SerializeField]
    private GameObject objectToActivate; // �ν����Ϳ��� ������ Ȱ��ȭ�� ������Ʈ
    [SerializeField]
    private string animationStateName = "Idle"; // �ν����Ϳ��� ������ �ִϸ��̼� ���� �̸�

    void Start()
    {
        animator = GetComponent<Animator>();
        initialPosition = transform.position;
        initialRotation = transform.rotation;

        if (objectToActivate != null)
        {
            objectToActivate.SetActive(false); // �ʱ⿡�� ��Ȱ��ȭ ���·� ����
        }

        if (animator != null)
        {
            animator.enabled = false; // �ʱ⿡�� �ִϸ����� ��Ȱ��ȭ
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
                        objectToActivate.SetActive(true); // Ŀ���� ������Ʈ ���� ���� �� Ȱ��ȭ
                    }
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (currentlyClickedObject != null && currentlyClickedObject != gameObject)
                    {
                        StopCurrentAnimation(); // �ٸ� ������Ʈ �ʱ�ȭ
                    }

                    currentlyClickedObject = gameObject;
                    currentlyActiveController = this;

                    if (animator != null)
                    {
                        animator.enabled = true; // Ŭ�� �� �ִϸ����� Ȱ��ȭ
                        animator.Play(animationStateName, 0, 0); // �ִϸ��̼��� ó������ ���

                    }

                    if (objectToActivate != null)
                    {
                        objectToActivate.SetActive(true); // Ŭ�� �� Ȱ��ȭ
                    }
                }
            }
            else
            {
                if (currentlyClickedObject != gameObject && objectToActivate != null)
                {
                    objectToActivate.SetActive(false); // Ŀ���� ������Ʈ ���� ���� �� ��Ȱ��ȭ
                }
            }
        }
        else
        {
            if (currentlyClickedObject != gameObject && objectToActivate != null)
            {
                objectToActivate.SetActive(false); // Ŀ���� ������Ʈ ���� ���� �� ��Ȱ��ȭ
            }
        }

        // ȭ���� �ٸ� ���� Ŭ���ϸ� ���� Ȱ��ȭ�� ������Ʈ �ʱ�ȭ
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
            objectToActivate.SetActive(false); // ������Ʈ ��Ȱ��ȭ
        }

        // ������Ʈ�� �ʱ� ��ġ�� ȸ������ �ǵ���
        transform.position = initialPosition;
        transform.rotation = initialRotation;

        currentlyClickedObject = null;
        currentlyActiveController = null;
    }
}
