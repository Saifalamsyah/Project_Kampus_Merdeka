using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public bool isDoorOpen = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Membuat objek ini tidak dihancurkan saat pergantian scene
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
