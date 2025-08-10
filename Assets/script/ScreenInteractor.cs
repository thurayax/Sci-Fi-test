using UnityEngine;

public class ScreenInteractor : MonoBehaviour
{
    [SerializeField] private float interactDistance = 3f;
    [SerializeField] private LayerMask interactMask = ~0; 
    [SerializeField] private int batteriesNeeded = 3;
    [SerializeField] GameObject level1Door;


    [SerializeField] private UnityEngine.UI.Text hintText;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
            if (Physics.Raycast(ray, out RaycastHit hit, interactDistance, interactMask) && hit.collider.CompareTag("Screen"))
            {
                if (BatteryCounter.Instance.Count >= batteriesNeeded)
                {
                    Destroy(level1Door);
                    UIManager.Instance.ShowMessage("Door unlocked. Proceed!", 3f);
                }
                else UIManager.Instance.ShowMessage($"You need {batteriesNeeded - BatteryCounter.Instance.Count} more batteries.", 3f);
            }
        }
    }

}
