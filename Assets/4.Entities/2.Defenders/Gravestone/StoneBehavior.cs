using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneBehavior : MonoBehaviour {

    private Animator animComponent;

	// Use this for initialization
	void Start () {
        animComponent = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void OnTriggerStay2D(Collider2D collision)
    {
        animComponent.SetTrigger("Under_Attack");
    }
    
}
