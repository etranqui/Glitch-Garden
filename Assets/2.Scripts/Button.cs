using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    
    public GameObject defenderPrefab;
    public Text textComponent;

    private Button[] buttonArray;
    static public GameObject selectedDefender;

	// Use this for initialization
	void Start () {
        // Retrieve external components
        buttonArray = GameObject.FindObjectsOfType<Button>();

        // Retrieve internal components
        textComponent = GetComponentInChildren<Text>();
        if (textComponent)
        {
            textComponent.text = defenderPrefab.GetComponent<Defender>().cost.ToString();
        } else
        {
            Debug.LogWarning("Missing Cost Text component on " + name);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    // Capture on click event
    private void OnMouseDown()
    {
        
        foreach(Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        GetComponent<SpriteRenderer>().color = Color.white;
        selectedDefender = defenderPrefab;
        Debug.Log(selectedDefender + "Selected");
    }
}
