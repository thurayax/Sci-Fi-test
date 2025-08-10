using UnityEngine;

public class BatteryPickup : MonoBehaviour
{
    [SerializeField] private float interactDistance = 10f;
    [SerializeField] private LayerMask interactMask = ~0;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(
                new Vector3(Screen.width / 2f, Screen.height / 2f)
            );

            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask))
            {
                if (hit.collider.CompareTag("Battery"))
                {
                    BatteryCounter.Instance.Add(1);
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
