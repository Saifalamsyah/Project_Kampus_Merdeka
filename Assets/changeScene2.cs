using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class changeScene2 : MonoBehaviour
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
        SceneManager.LoadScene("Level 1");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            StartCoroutine(_changeScene());
        }
    }
}