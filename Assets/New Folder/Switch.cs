using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private Door _Door; // Reference to the PintuMerah script
    private bool _isPlayerInRange = false;

    void Update()
    {
        if (_isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            _Door._isDoorOpen = !_Door._isDoorOpen; // Toggle the door state
            _Door.enabled = _Door._isDoorOpen; // Enable/Disable the PintuMerah script
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _isPlayerInRange = false;
        }
    }
}
