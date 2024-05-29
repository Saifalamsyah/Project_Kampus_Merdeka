using System.Collections;
using UnityEngine;

public class Switch2 : MonoBehaviour
{
    [SerializeField] private Pintu2 _doorBehavior;

    [SerializeField] private bool _isDoorOpenSwitch;
    [SerializeField] private bool _isDoorCloseSwitch;

    private float _switchSizeY;
    private Vector3 _switchUpPos;
    private Vector3 _switchDownPos;
    private float _switchSpeed = 1f;
    private float _switchDelay = 0.2f;
    private bool _isPressingSwitch = false;
    private bool _playerNearby = false;

    void Awake()
    {
        _switchSizeY = transform.localScale.y / 2;

        _switchUpPos = transform.position;
        _switchDownPos = new Vector3(transform.position.x, transform.position.y - _switchSizeY, transform.position.z);

        if (_doorBehavior == null)
        {
            Debug.LogError("PintuMerah reference is missing on " + gameObject.name);
        }
    }

    void Update()
    {
        if (_isPressingSwitch)
        {
            MoveSwitchDown();
        }
        else
        {
            MoveSwitchUp();
        }

        if (_playerNearby && Input.GetKeyDown(KeyCode.E))
        {
            ToggleSwitch();
        }
    }

    void MoveSwitchDown()
    {
        if (transform.position != _switchDownPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchDownPos, _switchSpeed * Time.deltaTime);
        }
    }

    void MoveSwitchUp()
    {
        if (transform.position != _switchUpPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, _switchUpPos, _switchSpeed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerNearby = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerNearby = false;
            if (gameObject.activeInHierarchy) // Ensure the game object is active before starting coroutine
            {
                StartCoroutine(SwitchUpDelay(_switchDelay));
            }
        }
    }

    IEnumerator SwitchUpDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        _isPressingSwitch = false;
    }

    void ToggleSwitch()
    {
        if (_doorBehavior == null) return;

        _isPressingSwitch = !_isPressingSwitch;

        Debug.Log("Toggling switch. _isDoorOpenSwitch: " + _isDoorOpenSwitch + ", _isDoorCloseSwitch: " + _isDoorCloseSwitch + ", _doorBehavior._isDoorOpen: " + _doorBehavior._isDoorOpen);

        if (_isDoorOpenSwitch && !_doorBehavior._isDoorOpen)
        {
            _doorBehavior._isDoorOpen = true;
        }
        else if (_isDoorCloseSwitch && _doorBehavior._isDoorOpen)
        {
            _doorBehavior._isDoorOpen = false;
        }
    }
}
