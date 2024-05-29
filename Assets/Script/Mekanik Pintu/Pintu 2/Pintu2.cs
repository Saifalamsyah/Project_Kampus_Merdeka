using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pintu2 : MonoBehaviour
{
    public bool _isDoorOpen = false;
    private Vector3 _doorClosedPos;
    private Vector3 _doorOpenPos;
    [SerializeField] private float _doorSpeed = 10f; // Buat serialize field untuk kecepatan pintu

    void Awake()
    {
        _doorClosedPos = transform.position;
        _doorOpenPos = new Vector3(transform.position.x, transform.position.y + 10f, transform.position.z);
    }

    void Update()
    {
        if (_isDoorOpen)
        {
            OpenDoor();
        }
        else
        {
            CloseDoor();
        }
    }

    void OpenDoor()
    {
        if (transform.position != _doorOpenPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _doorOpenPos, _doorSpeed * Time.deltaTime);
        }
    }

    void CloseDoor()
    {
        if (transform.position != _doorClosedPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _doorClosedPos, _doorSpeed * Time.deltaTime);
        }
    }
}
