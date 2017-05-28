using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour {

    private float currentSpeed;
    private GameObject currentTarget;
   
    private Animator animComponent;


	// Use this for initialization
	void Start () {
        Rigidbody2D component = gameObject.AddComponent<Rigidbody2D>();
        component.isKinematic = true;

        animComponent = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.left * currentSpeed * Time.deltaTime);

        if (!currentTarget) {
            animComponent.SetBool("IsAttacking", false);
        }
	}


    public void attack (GameObject target)
    {
        currentTarget = target;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(name + " On TriggerEnter");
        currentTarget = col.gameObject;
    }


    // Called from the Animator
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    // Called from the Animator
    public void DamageCurrentTarget(float damage)
    {
        Debug.Log(name + " inflicts " + damage + " damage.");

        // Inflict damage to currentTarget
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();

            if (health)
                health.DealDamage(damage);
        }
    }



}
