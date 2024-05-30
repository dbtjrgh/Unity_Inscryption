using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSetting : MonoBehaviour
{
    public GameObject targetObject; // ��Ȱ��ȭ�� ������Ʈ
    public GameObject spriteObject; // ��������Ʈ�� ������ ������Ʈ
    public Sprite newSprite; // �������� ������ �� ������ ��������Ʈ
    public float moveSpeed = 2f; // ������Ʈ �̵� �ӵ�

    // targetCollider�� static�� �ƴ� private�� ����Ǿ� �� ������Ʈ�� �ڽ��� targetCollider�� �����ϵ���

    private Sprite originalSprite; // ���� ��������Ʈ
    private Animator animator;
    private Collider targetCollider;
    private Renderer targetRenderer;
    private SpriteRenderer spriteRenderer;
    private bool shouldMove = false;
    private bool hasStartedMoving = false;

    private Vector3 targetPosition;

    void Start()
    {
        animator = GetComponent<Animator>();

        if (targetObject != null)
        {
            targetCollider = targetObject.GetComponent<Collider>();

            if (targetCollider == null)
            {
                Debug.LogError("Target object must have a Collider component.");
            }

            targetRenderer = targetObject.GetComponent<Renderer>();
            SetObjectActive(false); // ������ �� ��Ȱ��ȭ�� ���·� ����
        }

        if (spriteObject != null)
        {
            spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                originalSprite = spriteRenderer.sprite; // ���� ��������Ʈ ����
            }
        }
    }

    void Update()
    {
        if (animator != null && IsAnimatorPlaying())
        {
            CheckCursorOverTarget();
        }

        if (shouldMove)
        {
            // ���� ��ġ���� Ÿ�� ��ġ�� �ε巴�� �̵�
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                shouldMove = false;
                // �̵��� �Ϸ�Ǹ� �ִϸ����͸� �ٽ� Ȱ��ȭ���� �ʰ� ������ �ְ� ����
            }
        }
    }

    bool IsAnimatorPlaying()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);
        return stateInfo.normalizedTime < 1 && !animator.IsInTransition(0) && animator.enabled;
    }

    void CheckCursorOverTarget()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider != null && hit.collider == targetCollider)
            {
                SetObjectActive(true);
                ChangeSprite(true);

                if (Input.GetMouseButtonDown(0))
                {
                    // �̵� �÷��׿� Ÿ�� ��ġ ����
                    if (IsAnimatorPlaying())
                    {
                        shouldMove = true;
                        targetPosition = targetObject.transform.position;
                        animator.enabled = false; // �̵��� �����ϱ� ���� �ִϸ����͸� ��Ȱ��ȭ
                    }
                }
            }
            else
            {
                SetObjectActive(false);
                ChangeSprite(false);
            }
        }
        else
        {
            SetObjectActive(false);
            ChangeSprite(false);
        }
    }

    void SetObjectActive(bool isActive)
    {
        if (targetRenderer != null)
        {
            targetRenderer.enabled = isActive;
        }
    }

    void ChangeSprite(bool isActive)
    {
        if (spriteRenderer != null)
        {
            if (isActive)
            {
                spriteRenderer.sprite = newSprite;
            }
            else
            {
                spriteRenderer.sprite = originalSprite;
            }
        }
    }
    public bool IsMovementComplete()
    {
        return !shouldMove && hasStartedMoving;
    }

    public bool HasStartedMoving()
    {
        return hasStartedMoving;
    }
}
