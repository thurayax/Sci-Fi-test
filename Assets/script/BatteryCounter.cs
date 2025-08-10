using UnityEngine;

public class BatteryCounter : MonoBehaviour
{
    public static BatteryCounter Instance { get; private set; }

    [SerializeField] private int count = 0;
    public int Count => count;

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    public void Add(int amount = 1)
    {
        count += amount;
        Debug.Log($"Battery Count = {count}");
    }
}
