using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {

    static MusicManager singleton = null;

    public AudioClip[] playList;

    private AudioSource audioSourceComp;

	// Use this for initialization
	void Awake () {

        if (singleton != null && singleton != this)
        {
            Destroy(gameObject);
        }
        else
        {
            GameObject.DontDestroyOnLoad(gameObject);
            singleton = this;

            audioSourceComp = GetComponent<AudioSource>();            
        }
	}


    void Start ()
    {

        if (audioSourceComp && playList[SceneManager.GetActiveScene().buildIndex])
        {
            audioSourceComp.clip = playList[SceneManager.GetActiveScene().buildIndex];
            audioSourceComp.loop = true;
            audioSourceComp.Play();

        }
    }
	
	void OnLevelWasLoaded(int level)
    {
        if (playList[level])
        {
            audioSourceComp.clip = playList[level];
            audioSourceComp.loop = true;
            audioSourceComp.Play();
        }
       
    }


    public void SetVolume(float volume)
    {
        audioSourceComp.volume = volume;
    }
}
