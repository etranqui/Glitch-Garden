using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour {

    private LevelManager lvlManager;

	// Use this for initialization
	void Start () {
        // Retrieve LevelManager
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
	}	

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Trigger GameOver condition
        lvlManager.GameOver();
    }
}
