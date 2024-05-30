using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorSetting : MonoBehaviour
{
    public GameObject targetObject; // 비활성화된 오브젝트
    public GameObject spriteObject; // 스프라이트를 변경할 오브젝트
    public Sprite newSprite; // 렌더러가 켜졌을 때 변경할 스프라이트
    public float moveSpeed = 2f; // 오브젝트 이동 속도

    // targetCollider가 static이 아닌 private로 선언되어 각 오브젝트가 자신의 targetCollider를 관리하도록

    private Sprite originalSprite; // 원래 스프라이트
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
            SetObjectActive(false); // 시작할 때 비활성화된 상태로 설정
        }

        if (spriteObject != null)
        {
            spriteRenderer = spriteObject.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                originalSprite = spriteRenderer.sprite; // 원래 스프라이트 저장
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
            // 현재 위치에서 타겟 위치로 부드럽게 이동
            transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                shouldMove = false;
                // 이동이 완료되면 애니메이터를 다시 활성화하지 않고 가만히 있게 설정
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
                    // 이동 플래그와 타겟 위치 설정
                    if (IsAnimatorPlaying())
                    {
                        shouldMove = true;
                        targetPosition = targetObject.transform.position;
                        animator.enabled = false; // 이동을 시작하기 전에 애니메이터를 비활성화
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
