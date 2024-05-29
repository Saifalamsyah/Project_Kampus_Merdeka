using UnityEngine;

public class HideSpot : MonoBehaviour
{
    private void Start()
    {
        // Ensure the object has the correct tag and collider setup
        if (!CompareTag("HideSpot"))
        {
            Debug.LogWarning("HideSpot object does not have the correct tag assigned.");
        }

        Collider2D collider = GetComponent<Collider2D>();
        if (collider == null || !collider.isTrigger)
        {
            Debug.LogError("HideSpot object needs a Collider2D component with 'Is Trigger' enabled.");
        }
    }
}
