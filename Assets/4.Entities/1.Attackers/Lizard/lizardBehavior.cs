using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Attacker))]
public class lizardBehavior : MonoBehaviour {

    [SerializeField]
    private Attacker atkComponent;
    [SerializeField]
    private Animator animComponent;

	// Use this for initialization
	void Start () {
        atkComponent = gameObject.GetComponent<Attacker>();
        animComponent = gameObject.GetComponent<Animator>();
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void attack()
    {
        animComponent.SetBool("IsAttacking", true);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        GameObject obj = col.gameObject;

        // Exit if collider is NOT a defender
        if (!obj.GetComponent<Defender>())
            return;

        attack();
    }
}
