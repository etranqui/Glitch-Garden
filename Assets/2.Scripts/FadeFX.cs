using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeFX : MonoBehaviour {

    public float duration;
    public bool isFadeOut;
    private Image fadePanel;
    private Color currentColor;
    private float startTime;

	// Use this for initialization
	void Start () {
        fadePanel = GetComponent<Image>();
        currentColor = fadePanel.color;
	}
	
	// Update is called once per frame
	void Update () {
		if ((Time.time - startTime) < duration)
        {
            float alphaChange = Time.deltaTime / duration;

            if (!isFadeOut)
                currentColor.a -= alphaChange;
            else
                currentColor.a += alphaChange;

            fadePanel.color = currentColor;
        }
        else
        {
            // Only disable object if it's a fadeIn
            if (!isFadeOut)
                gameObject.SetActive(false);
        }
	}


    public void FadeIn()
    {
        Color startColor = Color.black;
        GetComponent<Image>().color = startColor;
        isFadeOut = false;
        startTime = Time.time;
        gameObject.SetActive(true);
    }

    public void FadeOut()
    {
        Color startColor = Color.black;
        startColor.a = 0;
        GetComponent<Image>().color = startColor;
        isFadeOut = true;
        startTime = Time.time;
        gameObject.SetActive(true);
    }
}
