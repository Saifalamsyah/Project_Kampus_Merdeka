using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeSceneMansion : MonoBehaviour
{

    Faded fade;

    void Start()
    {
        fade = FindObjectOfType<Faded>();
    }


    public IEnumerator _changeScene()
    {
        fade.FadedIn();
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Mansion");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(_changeScene());
        }
    }
}