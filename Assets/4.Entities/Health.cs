using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [Range(1.0f, 500.0f)]
    public float HP = 100.0f;

	public void DealDamage(float damage)
    {
        HP -= damage;
        Debug.Log(name + "takes " + damage + " damage ");
       
        if (HP <= 0)
        {
            // TODO: set death animation
            DestroyGameObject();
            
        }
    }


    public void DestroyGameObject()
    {
        Destroy(gameObject);
    }
}
