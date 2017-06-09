using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour {

    private StarDisplay starDisplay;
    [Range(0,1000)]
    public int cost;

    void Start ()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    private void AddStarCoins(int amount)
    {
        starDisplay.AddStars(amount);
    }
	
}
