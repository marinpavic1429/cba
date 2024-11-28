using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IntroImage : MonoBehaviour
{

    private float duration;
    private float currentAlpha;

    void Start()
    {
        duration = 4.5f;
        currentAlpha = 1.0f;
    }
    void Update()
    {
        currentAlpha -= 1 / duration * Time.deltaTime;
        if (currentAlpha > 0)
        {
            Color color = gameObject.GetComponent<Image>().color;
            gameObject.GetComponent<Image>().color = new Color(color.r, color.g, color.b, currentAlpha);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
