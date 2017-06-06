using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour {

    private GameObject defenderParent;

	// Use this for initialization
	void Start () {

        defenderParent = GameObject.Find("DefendersParent");

        if (defenderParent == null)
        {
            defenderParent = new GameObject("DefendersParent");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnMouseDown()
    {
        Vector2 pos = SnapToGrid(Camera.main.ScreenToWorldPoint(Input.mousePosition));
        if (Button.selectedDefender)
            Instantiate(Button.selectedDefender, pos, Quaternion.identity, defenderParent.transform);
        
    }

    private Vector2 SnapToGrid(Vector3 pos)
    {
        return new Vector2(Mathf.RoundToInt(pos.x), Mathf.RoundToInt(pos.y));
    }

}
