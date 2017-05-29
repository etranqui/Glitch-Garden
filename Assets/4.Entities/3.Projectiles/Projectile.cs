using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    [Range(0.0f, 20f)]
    public float speed = 5f;
    [Range(0.0f, 100f)]
    public float projectileDamage = 20f;

    // Use this for initia7lization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
	}


    // Deal Damage to Attacker on collision
    private void OnTriggerEnter2D(Collider2D collision)
    {        
        Health healthCmp = collision.gameObject.GetComponent<Health>();
        if (healthCmp)
        {
            healthCmp.DealDamage(projectileDamage);
            Destroy(gameObject);
        }
    }

} 
