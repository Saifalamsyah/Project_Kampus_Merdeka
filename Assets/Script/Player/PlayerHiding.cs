using UnityEngine;

public class PlayerHiding : MonoBehaviour
{
    private bool isHiding = false;
    private bool isNearHideSpot = false;
    private Transform hideSpot;
    private Vector3 originalPosition;
    private Movement playerMovement;

    private void Start()
    {
        // Get the PlayerMovement component attached to the player
        playerMovement = GetComponent<Movement>();
        if (playerMovement == null)
        {
            Debug.LogError("PlayerMovement component not found on the player.");
        }
    }
    void Update()
    {
        if (isNearHideSpot && Input.GetKeyDown(KeyCode.E))
        {
            if (isHiding)
            {
                ExitHideSpot();
            }
            else
            {
                EnterHideSpot();
            }
        }
    }

    private void EnterHideSpot()
    {
        // Check if hideSpot is not null before attempting to hide
        if (hideSpot == null)
        {
            Debug.LogWarning("hideSpot is null. Cannot enter hide spot.");
            return;
        }

        isHiding = true;

        // Check if SpriteRenderer and Collider2D are attached to the player
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D collider = GetComponent<Collider2D>();

        if (spriteRenderer == null || collider == null)
        {
            Debug.LogError("Missing components: SpriteRenderer or Collider2D is not attached to the player.");
            return;
        }

        // Save the original position before hiding
        originalPosition = transform.position;

        // Disable player renderer and collider
        spriteRenderer.enabled = false;
        collider.enabled = false;

        // Move player to hide spot position
        transform.position = hideSpot.position;

        // Disable the PlayerMovement script
        if (playerMovement != null)
        {
            playerMovement.enabled = false;
        }
        Debug.Log("Entered hide spot: " + hideSpot.name);
    }

    private void ExitHideSpot()
    {
        // Check if hideSpot is not null before attempting to exit hiding
        if (hideSpot == null)
        {
            Debug.LogWarning("hideSpot is null. Cannot exit hide spot properly.");
            return;
        }

        isHiding = false;

        // Check if SpriteRenderer and Collider2D are attached to the player
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        Collider2D collider = GetComponent<Collider2D>();

        if (spriteRenderer == null || collider == null)
        {
            Debug.LogError("Missing components: SpriteRenderer or Collider2D is not attached to the player.");
            return;
        }

        // Enable player renderer and collider
        spriteRenderer.enabled = true;
        collider.enabled = true;

        // Move player back to original position
        transform.position = originalPosition;

        // Enable the PlayerMovement script
        if (playerMovement != null)
        {
            playerMovement.enabled = true;
        }

        Debug.Log("Exited hide spot.");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("HideSpot"))
        {
            isNearHideSpot = true;
            hideSpot = collision.transform;
            Debug.Log("Player is near hide spot: " + hideSpot.name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("HideSpot"))
        {
            isNearHideSpot = true;
            hideSpot = collision.transform;
            Debug.Log("Player left the hide spot area.");
        }
    }
}
