using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class FoxBehaviour : MonoBehaviour {

    private Attacker atkComponent;
    private Animator animComponent;


    // Use this for initialization
    void Start () {
        atkComponent = gameObject.GetComponent<Attacker>();
        animComponent = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;

        // Exit if NOT colliding with a Defender
        if (!obj.GetComponent<Defender>())
            return;

        // If colliding with a Stone, Jump over
        if (obj.GetComponent<StoneBehavior>())
        {
            // Trigger Jump
            animComponent.SetTrigger("JumpTrigger");
        } else // Default to attacking Defender
        {
            animComponent.SetBool("IsAttacking", true);
            atkComponent.attack(col.gameObject);
        }
    }
}
