using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarDisplay : MonoBehaviour {

    private Text textComponent;
    private int starAmount = 100;
    public enum Status {SUCCESS, FAILURE};

    void Start ()
    {
        textComponent = gameObject.GetComponent<Text>();
        UpdateText();
    }

	public void AddStars(int amount)
    {
        starAmount += amount;
        UpdateText();
    }
	
    public Status UseStars(int amount)
    {
        if (starAmount >= amount)
        {
            starAmount -= amount;
            UpdateText();
            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    private void UpdateText()
    {
        textComponent.text = starAmount.ToString();
    }
}
