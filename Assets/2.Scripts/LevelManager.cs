using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float transitionTime = 0f;
    private FadeFX fadeFX;


    void Start()
    {
        fadeFX = GameObject.FindObjectOfType<FadeFX>();
        if(fadeFX)
        {
            fadeFX.FadeIn();
        }

        if (transitionTime != 0)
        {
            Invoke("FadeNextLevel", transitionTime);
        }
            
    }

    public void LoadLevel(string name)
    {
        SceneManager.LoadScene(name);
    }

    public void LoadLevel(int level)
    {
        SceneManager.LoadScene(level);
    }


    public void FadeNextLevel()
    {
        if (fadeFX)
        {
            Invoke("LoadNextLevel", fadeFX.duration);

            fadeFX.FadeOut();
        }
        else
        {
            Invoke("LoadNextLevel", transitionTime);
        }
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(SceneManager.sceneCountInBuildSettings - 1);
    }


    public void Quit()
    {
        Application.Quit();
    }


}
