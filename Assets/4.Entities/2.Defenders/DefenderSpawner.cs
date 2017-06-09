using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent; 
    private StarDisplay starDisplay;

	// Use this for initialization
	void Start () {

        // Get Defender parent empty GO
        defenderParent = GameObject.Find("DefendersParent");
        if (defenderParent == null)
        {
            defenderParent = new GameObject("DefendersParent");
        }

        // Get Star Display Score reference
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {

        Defender defender = Button.selectedDefender.GetComponent<Defender>();
        if (starDisplay.UseStars(defender.cost) == StarDisplay.Status.SUCCESS)
        {

            // Determine mouse position in world unit
            Vector2 pos = SnapToGrid(Camera.main.ScreenToWorldPoint(Input.mousePosition));

            // Instanciate Tower
            if (Button.selectedDefender)
                Instantiate(Button.selectedDefender, pos, Quaternion.identity, defenderParent.transform);
        }
        else
        {
            Debug.Log("Insufficient Stars...");
        }
        
    }

    private Vector2 SnapToGrid(Vector3 pos)
    {
        return new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
    }

}
