using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform topTransform;
    public Transform bottomTransform;
    public Transform leftTransform;
    public Transform rightTransform;
    public Transform centerTransform;

    public Camera mainCamera;

    private enum CameraPosition { Bottom, Center, Top, Left, Right }
    private CameraPosition currentPosition;

    private Transform targetTransform;
    private bool isMoving = false;
    private float moveSpeed = 2.0f;

    void Start()
    {
        if (mainCamera == null)
        {
            mainCamera = Camera.main;  // Fallback to main camera if not assigned
        }

        // Start at the bottom position
        currentPosition = CameraPosition.Bottom;
        targetTransform = bottomTransform;

        // Set initial camera position and rotation
        mainCamera.transform.position = bottomTransform.position;
        mainCamera.transform.rotation = bottomTransform.rotation;
    }

    void Update()
    {
        HandleCameraMovement();

        if (isMoving)
        {
            mainCamera.transform.position = Vector3.Lerp(mainCamera.transform.position, targetTransform.position, moveSpeed * Time.deltaTime);
            mainCamera.transform.rotation = Quaternion.Lerp(mainCamera.transform.rotation, targetTransform.rotation, moveSpeed * Time.deltaTime);

            if (Vector3.Distance(mainCamera.transform.position, targetTransform.position) < 0.01f &&
                Quaternion.Angle(mainCamera.transform.rotation, targetTransform.rotation) < 0.1f)
            {
                mainCamera.transform.position = targetTransform.position;
                mainCamera.transform.rotation = targetTransform.rotation;
                isMoving = false;
            }
        }
    }

    void HandleCameraMovement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            MoveDown();
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            MoveLeft();
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            MoveRight();
        }
    }

    void MoveUp()
    {
        if (currentPosition == CameraPosition.Bottom)
        {
            MoveCamera(centerTransform);
            currentPosition = CameraPosition.Center;
        }
        else if (currentPosition == CameraPosition.Center)
        {
            MoveCamera(topTransform);
            currentPosition = CameraPosition.Top;
        }
    }

    void MoveDown()
    {
        if (currentPosition == CameraPosition.Top)
        {
            MoveCamera(centerTransform);
            currentPosition = CameraPosition.Center;
        }
        else if (currentPosition == CameraPosition.Center)
        {
            MoveCamera(bottomTransform);
            currentPosition = CameraPosition.Bottom;
        }
    }

    void MoveLeft()
    {
        if (currentPosition == CameraPosition.Center)
        {
            MoveCamera(leftTransform);
            currentPosition = CameraPosition.Left;
        }
        else if (currentPosition == CameraPosition.Right)
        {
            MoveCamera(centerTransform);
            currentPosition = CameraPosition.Center;
        }
    }

    void MoveRight()
    {
        if (currentPosition == CameraPosition.Center)
        {
            MoveCamera(rightTransform);
            currentPosition = CameraPosition.Right;
        }
        else if (currentPosition == CameraPosition.Left)
        {
            MoveCamera(centerTransform);
            currentPosition = CameraPosition.Center;
        }
    }

    void MoveCamera(Transform newTransform)
    {
        targetTransform = newTransform;
        isMoving = true;
    }
}