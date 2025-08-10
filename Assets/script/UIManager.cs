using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private TextMeshProUGUI hintText;
    private float messageTimer = 0f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    void Update()
    {
        if (messageTimer > 0)
        {
            messageTimer -= Time.deltaTime;
            if (messageTimer <= 0)
            {
                hintText.text = "";
            }
        }
    }

    public void ShowMessage(string msg, float duration = 2f)
    {
        hintText.text = msg;
        messageTimer = duration;
    }
}
