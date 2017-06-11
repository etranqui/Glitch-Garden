using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour {

    private Slider slider;
    private LevelManager lvlManager;

    [Tooltip("time in seconds to complete level.")]
    public float timeGoal;
    private float time;
    private bool isEndOfLevel = false;
    private AudioSource audioComponent;
    private GameObject winLabel;

    // Use this for initialization
    void Start()
    {
        // Retrieve external components
        slider = GetComponent<Slider>();
        lvlManager = GameObject.FindObjectOfType<LevelManager>();
        audioComponent = GetComponent<AudioSource>();
        winLabel = GameObject.Find("Win Condition");
        if (!winLabel)
        {
            Debug.Log("Missing Stage Cleared label");
        } else
        {
            winLabel.SetActive(false);
        }

        // initialize timer
        time = timeGoal;       
    }
	
	// Update is called once per frame
	void Update () {
		
        if (!isEndOfLevel)
        {
            time -= Time.deltaTime;
            if (time < 0)
            {
                time = 0;
                isEndOfLevel = true;

                // Finish current level
                audioComponent.Play();
                winLabel.SetActive(true);
                Invoke("LoadNextLevel", 5);
            }
           
            float progress;
            progress = time / timeGoal;
            slider.value = progress;
        }
	}

    private void LoadNextLevel()
    {
        lvlManager.LoadNextLevel();
    }
}




