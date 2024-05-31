using UnityEngine;

public class CursorManager : MonoBehaviour
{
    private static CursorManager _instance;

    public static CursorManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("CursorManager");
                _instance = go.AddComponent<CursorManager>();
                DontDestroyOnLoad(go);
            }
            return _instance;
        }
    }

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        HideCursor();
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            HideCursor();
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ShowCursor();
        }
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void ShowCursor()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
    }
}
