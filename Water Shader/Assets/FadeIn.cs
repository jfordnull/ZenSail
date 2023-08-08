using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{

    [SerializeField] private CanvasGroup UIgroup;
    private bool fadeIn = true;
    // Start is called before the first frame update
    // Update is called once per frame

    private void Update()
    {
        if (fadeIn)
        {
            if (UIgroup.alpha > .8f)
            {
                UIgroup.alpha -= (Time.deltaTime * .025f);
            }
            else
            {
                UIgroup.alpha -= Time.deltaTime;
            }
            
            if (UIgroup.alpha <= 0)
            {
                fadeIn = false;
            }
        }
    }
}