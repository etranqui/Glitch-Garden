using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {

    [SerializeField]
    private GameObject projectilePrefab;
    private GameObject projectileParent;
    [SerializeField]
    private GameObject projectileSpawn;



    private void Start()
    {
        // Look for existing empty game object as projectile folder. If not, create it
        projectileParent = GameObject.Find("Projectiles");
        if (projectileParent == null)
        {
            projectileParent = new GameObject("Projectiles");
        }
    }


    private void FireProjectile()
    {
        // Create new projectile, set parent empty GO and spawn location transform
        GameObject newProjectile = Instantiate(projectilePrefab) as GameObject;
        newProjectile.transform.parent = projectileParent.transform;
        newProjectile.transform.position = projectileSpawn.transform.position;    
    }

 
}
