using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Destroy projectiles when out of bound
public class Shredder : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D collider)
    {
        Destroy(collider.gameObject);
        Debug.Log("Destroy: " + collider.name);
    }

}
