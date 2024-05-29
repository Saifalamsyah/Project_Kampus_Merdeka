using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Faded : MonoBehaviour
{
    public CanvasGroup CanvasGrp;
    public bool fadedin = false;
    public bool fadedout = false;

    public float TimeToFade;

    // Update is called once per frame
    void Update()
    {
        if (fadedin == true)
        {
            if(CanvasGrp.alpha < 1)
            {
                CanvasGrp.alpha += TimeToFade * Time.deltaTime;

                if(CanvasGrp.alpha >= 1)
                {
                    fadedin = false;
                }
            }
        }

        if (fadedout == true)
        {
            if (CanvasGrp.alpha >= 0)
            {
                CanvasGrp.alpha += TimeToFade * Time.deltaTime;

                if (CanvasGrp.alpha == 0)
                {
                    fadedout = false;
                }
            }
        }
    }

    public void FadedIn()
    {
        fadedin = true;
    }

    public void FadedOut()
    {
        fadedout = true;
    }
}
